using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.ProductProductGroups.Contracts;
using Pejvak_Product.Services.ProductProductGroups.Contracts.Dtos;

namespace Pejvak_Product.Persistences.T_ProductProductGroups
{
    public class ProductProductGroupQueryRepository : IProductProductGroupQuery
    {
        private readonly EFDataContext _context;

        public ProductProductGroupQueryRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<GetProductProductGroupDto?> GetProductProductGroup()
        {
            var result = await _context.ProductProductGroups
                .Select(x => new
                {
                    x.Id,
                    x.ProductIds
                })
                .FirstOrDefaultAsync();

            if (result == null)
                return null;

            return new GetProductProductGroupDto
            {
                Id = result.Id,
                ProductIds = result.ProductIds,
                ProductIntIds = result.ProductIds
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => int.Parse(id.Trim()))
                    .ToList()
            };
        }
    }
}
