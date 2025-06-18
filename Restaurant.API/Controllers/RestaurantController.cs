using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants.Commands.Create;
using Restaurant.Application.Restaurants.Commands.Delete;
using Restaurant.Application.Restaurants.Commands.Update;
using Restaurant.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new GetAllRestaurantQuery()) );
    }

    [HttpGet]
    [Route($"{nameof(GetById)}/{{id}}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var res = await mediator.Send(new GetRestaurantByIdQuery(id)) ;
        if (res is null)
        {
            return NotFound();
        }
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand restaurant)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var res = await mediator.Send(restaurant);
        return CreatedAtAction(nameof(GetById) , new {id = res},null);
        
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateRestaurant(UpdateRestaurantCommand restaurant)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var res = await mediator.Send(restaurant);
        return res == false ? NotFound() : Ok();

    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        var res = await mediator.Send(new DeleteRestaurantCommand(id)) ;
        return res ? NoContent() : BadRequest();
    }
    
    
}