using Pejvak_Product.Services.Infrastructure;
using Pejvak_Product.Services.ProductInstanceProperties.Contracts.Dtos;

namespace Pejvak_Product.Services.ProductInstanceProperties.Contracts
{
    public interface IProductInstancePropertyQuery : IScope
    {
        Task<GetProductInstancePropertyDto?> GetProductInstanceProperty();
    }
}
