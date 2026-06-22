using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Users.Commands.AssignUserRole;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Users.Commands.UnAssignUserRole
{
    public class UnAssignUserRoleCommandHandler(ILogger<UnAssignUserRoleCommandHandler> logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        : IRequestHandler<UnAssignUserRoleCommand>
    {
        public async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("unassigning user role {@Request}", request);

            var user = await userManager.FindByEmailAsync(request.UserEmail) ?? 
                throw new NotFoundException(nameof(User),request.UserEmail);
            var role = await roleManager.FindByNameAsync(request.RoleName) ??
                throw new NotFoundException(nameof(IdentityRole),request.RoleName);

            await userManager.RemoveFromRoleAsync(user, role.Name!);
        }
    }
}
