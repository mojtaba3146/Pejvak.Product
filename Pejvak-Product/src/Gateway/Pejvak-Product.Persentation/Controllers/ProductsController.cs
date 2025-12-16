using Microsoft.AspNetCore.Mvc;
using Pejvak_Product.Services.Products.Contracts;
using Pejvak_Product.Services.Products.Contracts.Dtos;

namespace Pejvak_Product.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductQuery _productQuery;

        public ProductsController(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        [HttpGet]
        public async Task<GetProductDto?> GetProduct()
        {
            return await _productQuery
                .GetProduct();
        }
    }
}
