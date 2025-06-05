using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Services.Restaurant.Dtos;

namespace Restaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController(IRestaurantService service) : ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await service.GetAllRestaurantsAsync());
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var res = await service.GetRestaurantByIdAsync(id);
        if (res is null)
        {
            return NotFound();
        }
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurantAsync(CreateRestaurantDto restaurant)
    {
        var res = await service.CreateRestaurantAsync(restaurant);
        return CreatedAtAction(nameof(GetById) , new {id = res},null);
        
    }


}