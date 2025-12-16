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
            //short isDeleted = 0;
            //return await _context.ProductHolders
            //    .Where(_ => _.UserId == userId && _.IsDeleted == isDeleted)
            //    .Join(_context.ProductInstances.Where(_ => _.IsDeleted == isDeleted),
            //        ph => ph.ProductInstanceId,
            //        pi => pi.Id,
            //        (ph, pi) => new { ph, pi })
            //    .Join(_context.Products.Where(_ => _.IsDeleted == isDeleted),
            //        temp => temp.pi.ProductId,
            //        p => p.Id,
            //        (temp, p) => new GetUserAvailableFeaturesDto
            //        {
            //            ProductHolderId = temp.ph.Id,
            //            ProductInstanceId = temp.pi.Id,
            //            UserId = temp.ph.UserId,
            //            ProductId = temp.pi.ProductId,
            //            ProductName = p.Name,
            //            AgentId = temp.pi.AgentId,
            //            LockSerial = temp.pi.LockSerial,
            //            ProductDate = temp.pi.ProductDate,
            //            StartDate = temp.ph.StartDate,
            //            EndDate = temp.ph.EndDate
            //        })
            //    .ToListAsync();

            ///////////////////////////////////////////////////////////////////

            //var userIdParam = new SqlParameter("@UserId", userId);

            //var result = await _context.Database
            //    .SqlQueryRaw<GetUserAvailableFeaturesDto>(
            //        "EXEC SP_GetUserAvailableFeatures @UserId",
            //        userIdParam)
            //    .ToListAsync();

            //return result;

            var userIdParam = new SqlParameter("@UserId", userId);
            var isDeletedParam = new SqlParameter
            {
                ParameterName = "@IsDeleted",
                SqlDbType = SqlDbType.SmallInt,
                Value = (short)0
            };

            var sql = @"
                SELECT 
                    ph.id AS ProductHolderId,
                    pi.id AS ProductInstanceId,
                    ph.userId AS UserId,
                    pi.productId AS ProductId,
                    p.name AS ProductName,
                    pi.agentId AS AgentId,
                    pi.lockSerial AS LockSerial,
                    pi.ProductDate AS ProductDate,
                    ph.startDate AS StartDate,
                    ph.endDate AS EndDate
                FROM 
                    T_ProductHolder ph
                INNER JOIN 
                    T_ProductInstance pi ON ph.productInstanceId = pi.id 
                    AND pi.isDeleted = @IsDeleted
                INNER JOIN 
                    T_Product p ON pi.productId = p.id 
                    AND p.isDeleted = @IsDeleted
                WHERE 
                    ph.userId = @UserId 
                    AND ph.isDeleted = @IsDeleted";

            var result = await _context.Database
                .SqlQueryRaw<GetUserAvailableFeaturesDto>(sql, userIdParam, isDeletedParam)
                .ToListAsync();

            return result;
        }
    }
}
