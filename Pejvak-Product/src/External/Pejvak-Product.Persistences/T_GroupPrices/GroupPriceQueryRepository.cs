using Microsoft.EntityFrameworkCore;
using Pejvak_Product.Persistences.Infrastructure;
using Pejvak_Product.Services.GroupPrices.Contracts;
using Pejvak_Product.Services.GroupPrices.Contracts.Dtos;

namespace Pejvak_Product.Persistences.T_GroupPrices
{
    public class GroupPriceQueryRepository : IGroupPriceQuery
    {
        private readonly EFDataContext _context;

        public GroupPriceQueryRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<GetGroupPriceDto?> GetGroupPrice()
        {
            return await _context.GroupPrices
                .Select(x => new GetGroupPriceDto
                {
                    Id = x.Id,
                    Price = x.Price
                })
                .FirstOrDefaultAsync();
        }
    }
}
