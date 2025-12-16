using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.ProductInstanceProperties.Contracts;
using Pejvak_Product.Services.ProductInstanceProperties.Contracts.Dtos;

namespace Pejvak_Product.Persistences.T_ProductInstanceProperties
{
    public class ProductInstancePropertyQueryRepository : IProductInstancePropertyQuery
    {
        private readonly EFDataContext _context;

        public ProductInstancePropertyQueryRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<GetProductInstancePropertyDto?> GetProductInstanceProperty()
        {
           return await _context.ProductInstanceProperties
                .Select(x => new GetProductInstancePropertyDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Version = x.Version,
                    Properties = x.Properties
                })
                .FirstOrDefaultAsync();
        }
    }
}
