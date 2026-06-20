using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Dishes;
using Restaurant.Application.Dishes.Commands.CreateDish;
using Restaurant.Application.Dishes.Commands.DeleteDish;
using Restaurant.Application.Dishes.Queries;
using Restaurant.Application.Dishes.Queries.GetAllDishes;
using Restaurant.Application.Dishes.Queries.GetDishByIdForRestaurant;

namespace Restaurant.Api.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            var dishId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { restaurantId, dishId }, null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishes([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetAllDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetById([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDishes([FromRoute] int restaurantId)
        {
            await mediator.Send(new DeleteDishesForRestaurantCommand(restaurantId));
            return NoContent();
        }
    }
}
