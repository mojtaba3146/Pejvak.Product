using Pejvak_Product.Services.Infrastructure;
using Pejvak_Product.Services.ProductInstances.Contracts.Dtos;

namespace Pejvak_Product.Services.ProductInstances.Contracts
{
    public interface IProductInstanceQuery : IScope
    {
        Task<GetProductInstanceDto?> GetProductInstance();
    }
}
