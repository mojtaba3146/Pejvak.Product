using Microsoft.AspNetCore.Mvc;
using Pejvak_Product.Services.GroupPrices.Contracts;
using Pejvak_Product.Services.GroupPrices.Contracts.Dtos;

namespace Pejvak_Product.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPricesController : ControllerBase
    {
        private readonly IGroupPriceQuery _groupPriceQuery;
        public GroupPricesController(IGroupPriceQuery groupPriceQuery)
        {
            _groupPriceQuery = groupPriceQuery;
        }

        [HttpGet]
        public async Task<GetGroupPriceDto?> GetGroupPrice()
        {
            return await _groupPriceQuery
                .GetGroupPrice();
        }
    }
}
