using Microsoft.AspNetCore.Mvc;
using Pejvak_Product.Services.ProductProductGroups.Contracts;
using Pejvak_Product.Services.ProductProductGroups.Contracts.Dtos;

namespace Pejvak_Product.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProductGroupsController : ControllerBase
    {
        private readonly IProductProductGroupQuery _productGroupQuery;

        public ProductProductGroupsController(IProductProductGroupQuery productProductGroupQuery)
        {
            _productGroupQuery = productProductGroupQuery;
        }

        [HttpGet]
        public async Task<GetProductProductGroupDto?> GetProductProductGroup()
        {
            return await _productGroupQuery
                .GetProductProductGroup();
        }
    }
}
