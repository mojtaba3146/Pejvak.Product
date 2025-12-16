using Pejvak_Product.Services.ExtraFeatures.Contracts.Dtos;
using Pejvak_Product.Services.Infrastructure;

namespace Pejvak_Product.Services.ExtraFeatures.Contracts
{
    public interface IExtraFeatureQuery : IScope
    {
        Task<GetExtraFeatureDto?> GetExtraFeature();
    }
}
