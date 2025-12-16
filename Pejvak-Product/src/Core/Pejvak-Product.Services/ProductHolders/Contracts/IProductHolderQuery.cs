using Pejvak_Product.Services.Infrastructure;
using Pejvak_Product.Services.ProductHolders.Contracts.Dtos;

namespace Pejvak_Product.Services.ProductHolders.Contracts
{
    public interface IProductHolderQuery : IScope
    {
        Task<GetProductHolderDto?> GetProductHolder();
    }
}
