
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicies
{
    public class CondimentAuthorizationHandler : AuthorizationHandler<CondimentRequirement>
    {
        ICondimentProvider _condimentProvider;

        public CondimentAuthorizationHandler(ICondimentProvider condimentProvider)
        {
            _condimentProvider = condimentProvider;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CondimentRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated && context.User.HasClaim(c => c.Type == ClaimTypes.Country))
            {
                var country =
                    context.User.FindFirst(
                        c => c.Type == ClaimTypes.Country &&
                        c.Issuer == "urn:PassportControl").Value.ToUpperInvariant();

                switch (country)
                {
                    case "GBR":
                        if (_condimentProvider.GetCondiment() == Condiment.Ketchup)
                        {
                            context.Succeed(requirement);
                        }
                        break;

                    case "BEL":
                        if (_condimentProvider.GetCondiment() == Condiment.Mayo)
                        {
                            context.Succeed(requirement);
                        }
                        break;

                    case "USA":
                        if (_condimentProvider.GetCondiment() != Condiment.Mayo)
                        {
                            context.Succeed(requirement);
                        }
                        break;
                }
            }

            return Task.CompletedTask;
        }
    }
}
