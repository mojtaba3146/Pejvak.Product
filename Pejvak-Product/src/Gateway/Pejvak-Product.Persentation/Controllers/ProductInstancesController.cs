using Microsoft.AspNetCore.Mvc;
using Pejvak_Product.Services.ProductInstances.Contracts;
using Pejvak_Product.Services.ProductInstances.Contracts.Dtos;

namespace Pejvak_Product.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInstancesController : ControllerBase
    {
        private readonly IProductInstanceQuery _productInstanceQuery;
        public ProductInstancesController(IProductInstanceQuery productInstanceQuery)
        {
            _productInstanceQuery = productInstanceQuery;
        }

        [HttpGet]
        public async Task<GetProductInstanceDto?> GetProductInstance()
        {
            return await _productInstanceQuery
                .GetProductInstance();
            
        }

    }
}
