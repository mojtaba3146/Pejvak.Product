using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.ProductHolders.Contracts;
using Pejvak_Product.Services.ProductHolders.Contracts.Dtos;
using System.Data;

namespace Pejvak_Product.Persistences.T_ProductHolders
{
    public class ProductHolderQueryRepository : IProductHolderQuery
    {
        private readonly EFDataContext _context;

        public ProductHolderQueryRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<GetProductHolderDto?> GetProductHolder()
        {
            return await _context.ProductHolders
                .Select(_ => new GetProductHolderDto
                {
                    Id = _.Id,
                    UserId = _.UserId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<GetUserAvailableFeaturesDto>> GetUserAvailableFeatures(int userId)
        {
            short isDeleted = 0;
            short isActive = 1;

            var results = await _context.ProductHolders
                .Where(_ => _.UserId == userId && _.IsDeleted == isDeleted)
                .Join(_context.ProductInstances.Where(_ => _.IsDeleted == isDeleted),
                    ph => ph.ProductInstanceId,
                    pi => pi.Id,
                    (ph, pi) => new { ph, pi })
                .Join(_context.Products.Where(_ => _.IsDeleted == isDeleted),
                    temp => temp.pi.ProductId,
                    p => p.Id,
                    (temp, p) => new GetUserAvailableFeaturesDto
                    {
                        ProductHolderId = temp.ph.Id,
                        ProductInstanceId = temp.pi.Id,
                        UserId = temp.ph.UserId,
                        ProductId = temp.pi.ProductId,
                        ProductName = p.Name,
                        AgentId = temp.pi.AgentId,
                        LockSerial = temp.pi.LockSerial,
                        ProductDate = temp.pi.ProductDate,
                        StartDate = temp.ph.StartDate,
                        EndDate = temp.ph.EndDate
                    })
                .AsNoTracking()
                .ToListAsync();

            if (!results.Any())
            {
                return results;
            }

            var productInstanceIds = results
                .Select(_ => _.ProductInstanceId)
                .Distinct()
                .ToList();

            var productIds = results
               .Where(_ => _.ProductId.HasValue)
               .Select(_ => _.ProductId!.Value)
               .Distinct()
               .ToList();

            if (!productIds.Any())
            {
                return results;
            }

            var allExtraFeatures = await  _context.ExtraFeatures
                .Where(ef => productInstanceIds.Contains(ef.ProductInstanceId!.Value)
                    && ef.IsDeleted == isDeleted
                    && ef.Confirmed == 1)
                .Select(ef => new { ef.ProductInstanceId, ef.ExtraFeatures })
                .AsNoTracking()
                .ToListAsync();

            var allProductProductGroups = await _context.ProductProductGroups
               .Where(_ => _.IsDeleted == isDeleted)
               .Select(_ => new { _.ProductIds, _.PropertyId })
               .AsNoTracking()
               .ToListAsync();

            var allProductInstanceProperties = await _context.ProductInstanceProperties
                .Where(pip => productIds.Contains(pip.ProductId!.Value)
                    && pip.IsDeleted == isDeleted
                    && pip.IsActive == isActive)
                .Select(pip => new ProductInstancePropertyDto
                {
                    Id = pip.Id,
                    ProductId = pip.ProductId!.Value,
                    Properties = pip.Properties,
                    FatherId = pip.FatherId
                })
                .AsNoTracking()
                .ToListAsync();


            var productInstanceToBoughtPropertyIds = new Dictionary<int, List<int>>();
            var allBoughtPropertyIds = new HashSet<int>();

            foreach (var extraFeature in allExtraFeatures)
            {
                if (extraFeature.ProductInstanceId.HasValue && !string.IsNullOrWhiteSpace(extraFeature.ExtraFeatures))
                {
                    var propertyIds = ParsePropertyIds(extraFeature.ExtraFeatures);

                    if (productIds.Count > 0)
                    {
                        var productInstanceId = extraFeature.ProductInstanceId.Value;

                        if (!productInstanceToBoughtPropertyIds.TryGetValue(productInstanceId, out var list))
                        {
                            list = new List<int>();
                            productInstanceToBoughtPropertyIds[productInstanceId] = list;
                        }

                        list.AddRange(propertyIds);
                        allBoughtPropertyIds.UnionWith(propertyIds);
                    }
                }
            }

            var productIdStrings = productIds.Select(id => id.ToString()).ToList();
            var productIdToPropertyIds = new Dictionary<int, List<int>>();

            foreach (var productId in productIds)
            {
                var productIdStr = productId.ToString();
                var propertyIds = allProductProductGroups
                    .Where(_ => MatchesProductId(_.ProductIds, productIdStr))
                    .Select(_ => _.PropertyId)
                    .Distinct()
                    .ToList();

                if (propertyIds.Count > 0)
                {
                    productIdToPropertyIds[productId] = propertyIds;
                }
            }

            var productIdToDefaultPropertyIds = new Dictionary<int, List<int>>();

            foreach (var productId in productIds)
            {
                var defaultPropertyIds = ResolveDefaultProperties(productId, allProductInstanceProperties);
                if (defaultPropertyIds.Count > 0)
                {
                    productIdToDefaultPropertyIds[productId] = defaultPropertyIds;
                }
            }

            var allUniquePropertyIds = new HashSet<int>();

            foreach (var list in productIdToPropertyIds.Values)
                allUniquePropertyIds.UnionWith(list);

            foreach (var list in productIdToDefaultPropertyIds.Values)
                allUniquePropertyIds.UnionWith(list);

            allUniquePropertyIds.UnionWith(allBoughtPropertyIds);

            if (allUniquePropertyIds.Count == 0)
            {
                return results;
            }

            var properties = await _context.ProductProperties
                .Where(prop => allUniquePropertyIds.Contains(prop.Id) && prop.IsDeleted == isDeleted)
                .Join(_context.GroupPrices.Where(gp => gp.IsDeleted == isDeleted && gp.IsActive == isActive),
                    prop => prop.Id,
                    gp => gp.PropertyId,
                    (prop, groupPrices) => new 
                    {
                        PropertyId = prop.Id,
                        PropertyTitle = prop.PropertyTitle,
                        PropertyUnicode = prop.UniqueCode,
                        Price =(groupPrices.Price ?? 0) ,
                        PriceDescription =  groupPrices.Description
                    })
                .AsNoTracking()
                .ToListAsync();

            var propertyLookup = properties
                .GroupBy(p => p.PropertyId)
                .ToDictionary(
                    g => g.Key,
                    g => g.First()
                );

            foreach (var result in results)
            {
                if (productInstanceToBoughtPropertyIds.TryGetValue(result.ProductInstanceId, out var boughtPropertyIds))
                {
                    result.UserBoughtProductProperties = boughtPropertyIds
                        .Distinct()
                        .Where(propertyLookup.ContainsKey)
                        .Select(id =>
                        {
                            var prop = propertyLookup[id];
                            return new GetUserBoughtProductPropertiesDto
                            {
                                PropertyId = prop.PropertyId,
                                PropertyTitle = prop.PropertyTitle
                            };
                        })
                        .ToList();
                }

                if (!result.ProductId.HasValue)
                    continue;

                var productId = result.ProductId.Value;

                if (productIdToPropertyIds.TryGetValue(productId, out var regularPropertyIds))
                {
                    result.ProductProperties = regularPropertyIds
                       .Where(propertyLookup.ContainsKey)
                       .Select(id => new GetProductPropertiesDto
                       {
                           PropertyId = propertyLookup[id].PropertyId,
                           PropertyTitle = propertyLookup[id].PropertyTitle,
                           PropertyUnicode = propertyLookup[id].PropertyUnicode,
                           Price = propertyLookup[id].Price,
                           PriceDescription = propertyLookup[id].PriceDescription
                       })
                       .ToList();
                }

                if (productIdToDefaultPropertyIds.TryGetValue(productId, out var defaultPropertyIds))
                {
                    result.DefaultProductProperties = defaultPropertyIds
                        .Where(propertyLookup.ContainsKey)
                        .Select(id => new GetDefaultProductPropertiesDto
                        {
                            PropertyId = propertyLookup[id].PropertyId,
                            PropertyTitle = propertyLookup[id].PropertyTitle,
                            PropertyUnicode = propertyLookup[id].PropertyUnicode,
                            Price = propertyLookup[id].Price,
                            PriceDescription = propertyLookup[id].PriceDescription
                        })
                        .ToList();
                }

                var defaultPropertyIdSet = result.DefaultProductProperties
                    .Select(p => p.PropertyId)
                    .ToHashSet();

                var boughtPropertyIdSet = result.UserBoughtProductProperties
                    .Select(p => p.PropertyId)
                    .ToHashSet();

                result.AllAvailableProductProperties = result.ProductProperties
                    .Where(p => !defaultPropertyIdSet.Contains(p.PropertyId)
                             && !boughtPropertyIdSet.Contains(p.PropertyId))
                    .Select(p => new GetAllAvailableProductPropertiesDto
                    {
                        PropertyId = p.PropertyId,
                        PropertyTitle = p.PropertyTitle,
                        Price = p.Price
                    })
                    .ToList();
            }

            return results;
        }

        private static List<int> ParsePropertyIds(string propertyString)
        {
            var result = new List<int>();
            var span = propertyString.AsSpan();

            foreach (var range in span.Split(','))
            {
                var trimmed = span[range].Trim();
                if (trimmed.Length > 0 && int.TryParse(trimmed, out var id))
                {
                    result.Add(id);
                }
            }

            return result;
        }

        private static bool MatchesProductId(string productIds, string productIdStr)
        {
            if (string.IsNullOrEmpty(productIds))
                return false;

            if (productIds == productIdStr)
                return true;

            var span = productIds.AsSpan();
            var searchSpan = productIdStr.AsSpan();

            if (span.StartsWith(searchSpan) && span.Length > searchSpan.Length && span[searchSpan.Length] == ',')
                return true;

            if (span.EndsWith(searchSpan) && span.Length > searchSpan.Length && span[span.Length - searchSpan.Length - 1] == ',')
                return true;

            var searchPattern = $",{productIdStr},";
            return productIds.Contains(searchPattern);
        }

        private List<int> ResolveDefaultProperties(
            int productId,
            List<ProductInstancePropertyDto> allProductInstanceProperties)
        {
            var recordsById = allProductInstanceProperties
                .Where(p => p.ProductId == productId)
                .ToDictionary(p => p.Id);

            if (!recordsById.Any())
                return new List<int>();

            var rootRecords = recordsById.Values
                .Where(r => r.FatherId == null || r.FatherId == 0 || r.FatherId == -1)
                .ToList();

            var propertyStates = new Dictionary<int, (bool IsRemoved, int Level)>();

            void ProcessRecord(ProductInstancePropertyDto record, int level)
            {
                if (!string.IsNullOrWhiteSpace(record.Properties))
                {
                    var propertyStrings = record.Properties
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => p.Trim())
                        .ToList();

                    foreach (var propStr in propertyStrings)
                    {
                        if (string.IsNullOrWhiteSpace(propStr))
                            continue;

                        bool isRemoved = false;
                        string cleanPropStr = propStr;

                        if (propStr.EndsWith("-"))
                        {
                            isRemoved = true;
                            cleanPropStr = propStr.Substring(0, propStr.Length - 1).Trim();
                        }
                        else if (propStr.EndsWith("+"))
                        {
                            cleanPropStr = propStr.Substring(0, propStr.Length - 1).Trim();
                        }

                        if (int.TryParse(cleanPropStr, out int propertyId))
                        {
                            if (!propertyStates.ContainsKey(propertyId) ||
                                propertyStates[propertyId].Level < level)
                            {
                                propertyStates[propertyId] = (isRemoved, level);
                            }
                        }
                    }
                }

                var children = recordsById.Values
                    .Where(r => r.FatherId == record.Id)
                    .ToList();

                foreach (var child in children)
                {
                    ProcessRecord(child, level + 1);
                }
            }

            foreach (var rootRecord in rootRecords)
            {
                ProcessRecord(rootRecord, 0);
            }

            return propertyStates
                .Where(kvp => !kvp.Value.IsRemoved)
                .Select(kvp => kvp.Key)
                .Distinct()
                .ToList();
        }

        private class ProductInstancePropertyDto
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string? Properties { get; set; }
            public int? FatherId { get; set; }
        }
    }
}


internal class UserAvailableFeaturesRawResult
{
    public int ProductHolderId { get; set; }
    public int ProductInstanceId { get; set; }
    public int? UserId { get; set; }
    public int? ProductId { get; set; }
    public string? ProductName { get; set; }
    public int? AgentId { get; set; }
    public string? LockSerial { get; set; }
    public DateTime? ProductDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? PropertyId { get; set; }
    public string? PropertyTitle { get; set; }
    public string? PropertyUnicode { get; set; }
    public long Price { get; set; }
    public string? PriceDescription { get; set; }
}