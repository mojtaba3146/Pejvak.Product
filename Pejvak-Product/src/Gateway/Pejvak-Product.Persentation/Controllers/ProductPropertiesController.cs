using Microsoft.AspNetCore.Mvc;
using Pejvak_Product.Services.ProductProperties.Contracts;
using Pejvak_Product.Services.ProductProperties.Contracts.Dtos;

namespace Pejvak_Product.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPropertiesController : ControllerBase
    {
        private readonly IProductPropertyQuery _productPropertyQuery;

        public ProductPropertiesController(IProductPropertyQuery productPropertyQuery)
        {
            _productPropertyQuery = productPropertyQuery;
        }

        [HttpGet]
        public async Task<GetProductPropertyDto?> GetProductProperty()
        {
            return await _productPropertyQuery
                .GetProductProperty();
        }
    }
}
