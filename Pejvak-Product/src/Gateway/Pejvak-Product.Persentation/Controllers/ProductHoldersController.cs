using Microsoft.AspNetCore.Mvc;
using Pejvak_Product.Services.ProductHolders.Contracts;
using Pejvak_Product.Services.ProductHolders.Contracts.Dtos;

namespace Pejvak_Product.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductHoldersController : ControllerBase
    {
        private readonly IProductHolderQuery _productHolderQuery;

        public ProductHoldersController(IProductHolderQuery productHolderQuery)
        {
            _productHolderQuery = productHolderQuery;
        }

        [HttpGet]
        public async Task<GetProductHolderDto?> GetProductHolder()
        {
            return await _productHolderQuery
                .GetProductHolder();
        }

        [HttpGet("available-features/{userId}")]
        public async Task<List<GetUserAvailableFeaturesDto>> GetUserAvailableFeatures(int userId)
        {
            return await _productHolderQuery
                .GetUserAvailableFeatures(userId);
        }
    }
}
