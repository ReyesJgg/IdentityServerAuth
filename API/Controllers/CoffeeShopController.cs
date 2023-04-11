using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopController : ControllerBase
    {
        private readonly ICoffeeShopServices _coffeeShopServices;

        public CoffeeShopController(ICoffeeShopServices coffeeShopServices)
        {
            _coffeeShopServices = coffeeShopServices;
        }

        [HttpGet]
        public async Task<IActionResult> List() {
            var coffeeShops = await _coffeeShopServices.List();
            return Ok(coffeeShops);
        }
    }
}
