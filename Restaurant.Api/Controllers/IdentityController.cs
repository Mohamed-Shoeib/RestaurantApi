using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Users.Commands.AssignUserRole;
using Restaurant.Application.Users.Commands.UnAssignUserRole;
using Restaurant.Application.Users.Commands.UpdateUserDetails;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPost("UserRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> assignUserRole(AssignUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("UserRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> unAssignUserRole(UnAssignUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
