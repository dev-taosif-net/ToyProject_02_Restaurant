using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Interfaces;

namespace Restaurant.API.Controllers;

[ApiController]
[Route("api/{controller}")]
public class RestaurantController(IRestaurantService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult>   GetAll()
    {
        return Ok(await service.GetAllRestaurantsAsync());
    }

}