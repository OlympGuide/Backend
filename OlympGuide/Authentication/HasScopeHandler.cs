﻿using Microsoft.AspNetCore.Authorization;

namespace OlympGuide.Authentication
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(
          AuthorizationHandlerContext context,
          HasScopeRequirement requirement
        )
        {
            // If user does not have the scope claim, get out of here
            if (!context.User.HasClaim(c => c.Type == "permissions" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            // Split the scopes string into an array
            var permissions = context.User
              .FindAll(c => c.Type == "permissions" && c.Issuer == requirement.Issuer).ToList();

            // Succeed if the scope array contains the required scope
            if (permissions.Any(p => p.Value == requirement.Scope))
                context.Succeed(requirement);
            else if(permissions.Any(p => p.Value.Equals("access:admin")))
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}
