using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.Products.Contracts;
using Pejvak_Product.Services.Products.Contracts.Dtos;

namespace Pejvak_Product.Persistences.T_Products
{
    public class ProductQueryRepository : IProductQuery
    {
        private readonly EFDataContext _context;

        public ProductQueryRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<GetProductDto?> GetProduct()
        {
            return await _context.Products
                .Select(_ => new GetProductDto
                {
                    Id = _.Id,
                    Name = _.Name,
                }).FirstOrDefaultAsync();

        }
    }
}
