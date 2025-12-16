using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.ProductInstances.Contracts;
using Pejvak_Product.Services.ProductInstances.Contracts.Dtos;

namespace Pejvak_Product.Persistences.T_ProductInstances
{
    public class ProductInstanceQueryRepository : IProductInstanceQuery
    {
        private readonly EFDataContext _context;

        public ProductInstanceQueryRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<GetProductInstanceDto?> GetProductInstance()
        {
            return await _context.ProductInstances
                .Select(x => new GetProductInstanceDto
                {
                    Id = x.Id,
                    Serial = x.LockSerial != null ? x.LockSerial : string.Empty
                })
                .FirstOrDefaultAsync();
        }
    }
}
