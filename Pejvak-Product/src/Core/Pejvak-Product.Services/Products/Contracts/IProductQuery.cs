using Pejvak_Product.Services.Infrastructure;
using Pejvak_Product.Services.Products.Contracts.Dtos;

namespace Pejvak_Product.Services.Products.Contracts
{
    public interface IProductQuery : IScope
    {
        Task<GetProductDto?> GetProduct();
    }
}
