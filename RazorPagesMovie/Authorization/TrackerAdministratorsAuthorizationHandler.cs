using System.Threading.Tasks;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace RazorPagesMovie.Authorization
{
    public class TrackerAdministratorsAuthorizationHandler
                    : AuthorizationHandler<OperationAuthorizationRequirement, Tracker>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                     Tracker resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.TrackerAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}