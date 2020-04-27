using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, HasScopeRequirement requirement)
    {
        //kick out users without the correct scope claim
        if(!context.User
                .HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;//.hasClaim would be false, making the if statement true, returning task completed
        var scopes = context.User
                .FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer)
                .Value.Split(' ');//split scopes string into an array

        if (scopes.Any(s => s == requirement.Scope))//succeeds if scoped array has required scope
                context.Succeed(requirement);

                return Task.CompletedTask;
    }
    
}