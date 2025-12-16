using Pejvak_Product.Services.GroupPrices.Contracts.Dtos;
using Pejvak_Product.Services.Infrastructure;

namespace Pejvak_Product.Services.GroupPrices.Contracts
{
    public interface IGroupPriceQuery : IScope
    {
        Task<GetGroupPriceDto?> GetGroupPrice();
    }
}
