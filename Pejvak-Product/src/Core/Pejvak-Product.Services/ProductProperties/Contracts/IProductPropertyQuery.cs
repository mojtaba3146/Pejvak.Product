using Pejvak_Product.Services.Infrastructure;
using Pejvak_Product.Services.ProductProperties.Contracts.Dtos;

namespace Pejvak_Product.Services.ProductProperties.Contracts
{
    public interface IProductPropertyQuery : IScope
    {
        Task<GetProductPropertyDto?> GetProductProperty();
    }
}
