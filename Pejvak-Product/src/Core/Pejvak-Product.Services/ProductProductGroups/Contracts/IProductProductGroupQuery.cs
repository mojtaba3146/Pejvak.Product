using Pejvak_Product.Services.Infrastructure;
using Pejvak_Product.Services.ProductProductGroups.Contracts.Dtos;

namespace Pejvak_Product.Services.ProductProductGroups.Contracts
{
    public interface IProductProductGroupQuery : IScope
    {
        Task<GetProductProductGroupDto?> GetProductProductGroup();
    }
}
