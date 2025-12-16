using Microsoft.AspNetCore.Mvc;
using Pejvak_Product.Services.ProductInstanceProperties.Contracts;
using Pejvak_Product.Services.ProductInstanceProperties.Contracts.Dtos;

namespace Pejvak_Product.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInstancePropertiesController : ControllerBase
    {
        private readonly IProductInstancePropertyQuery _productInstancePropertyQuery;

        public ProductInstancePropertiesController(IProductInstancePropertyQuery productInstancePropertyQuery)
        {
            _productInstancePropertyQuery = productInstancePropertyQuery;
        }

        [HttpGet]
        public async Task<GetProductInstancePropertyDto?> GetProductInstanceProperty()
        {
            return await _productInstancePropertyQuery
                .GetProductInstanceProperty();
        }
    }
}
