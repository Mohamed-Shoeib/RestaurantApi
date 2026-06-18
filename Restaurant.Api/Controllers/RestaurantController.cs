using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants;
using Restaurant.Application.Restaurants.Commands.CreateRestaurant;
using Restaurant.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurant.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;
using System.Threading.Tasks;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto?>> GetById([FromRoute] int id)
        {
            var restuarant = await mediator.Send(new GetRestaurantByIdQuery(id));
            if (restuarant == null)
                return NotFound();
            return Ok(restuarant);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand createRestaurantCommand)
        {
            var AddNewRestaurant = await mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(GetById), new { Id = AddNewRestaurant }, AddNewRestaurant);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            await mediator.Send(new DeleteRestaurantCommand(id));
            return NoContent();
        }
    }
}
