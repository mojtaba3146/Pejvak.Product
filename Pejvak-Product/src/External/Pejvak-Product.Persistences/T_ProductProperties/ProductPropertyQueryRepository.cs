using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.ProductProperties.Contracts;
using Pejvak_Product.Services.ProductProperties.Contracts.Dtos;

namespace Pejvak_Product.Persistences.T_ProductProperties
{
    public class ProductPropertyQueryRepository : IProductPropertyQuery
    {
        private readonly EFDataContext _context;

        public ProductPropertyQueryRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<GetProductPropertyDto?> GetProductProperty()
        {
            return await _context.ProductProperties
                .Select(x => new GetProductPropertyDto
                {
                    Id = x.Id,
                    PropertyTitle = x.PropertyTitle
                })
                .FirstOrDefaultAsync();
        }
    }
}
