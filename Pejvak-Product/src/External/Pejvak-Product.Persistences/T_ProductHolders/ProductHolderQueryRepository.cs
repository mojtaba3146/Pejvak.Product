using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.ProductHolders.Contracts;
using Pejvak_Product.Services.ProductHolders.Contracts.Dtos;

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
    }
}
