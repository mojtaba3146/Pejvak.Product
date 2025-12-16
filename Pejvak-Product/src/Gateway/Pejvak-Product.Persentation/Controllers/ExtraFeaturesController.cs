using Microsoft.AspNetCore.Mvc;
using Pejvak_Product.Services.ExtraFeatures.Contracts;
using Pejvak_Product.Services.ExtraFeatures.Contracts.Dtos;

namespace Pejvak_Product.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraFeaturesController : ControllerBase
    {
        private readonly IExtraFeatureQuery _extraFeatureQuery;

        public ExtraFeaturesController(IExtraFeatureQuery extraFeatureQuery)
        {
            _extraFeatureQuery = extraFeatureQuery;
        }

        [HttpGet]
        public async Task<GetExtraFeatureDto?> GetExtraFeature()
        {
            return await _extraFeatureQuery
                .GetExtraFeature();
        }
    }
}
