using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using static TestProject.Middleware.Policies.PoliciesEnum;

namespace TestProject.Middleware.Policies
{
    public class ClientPolicyRequirement : IAuthorizationRequirement
    {
        public string Identity { get; }

        public ClientPolicyRequirement(string identity)
        {
            Identity = identity;
        }
    }

    public class ClientPolicyHandler : AuthorizationHandler<ClientPolicyRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClientPolicyRequirement requirement)
        {

            var claimIdentity = context.User.Identity as ClaimsIdentity;

            claimIdentity?.AddClaim(new Claim(ClaimTypes.NameIdentifier, requirement.Identity));

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }

    public class ClientAuthorizeAttribute : AuthorizeAttribute
    {
        public ClientAuthorizeAttribute() : base(PolicyEnum.ClientPolicy.Val())
        {
        }
    }

    public static class ClientPolicyExtension
    {
        public static void AddClientPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyEnum.ClientPolicy.Val(), policy =>
                {
                    policy.Requirements.Add(new ClientPolicyRequirement(PolicyEnum.ClientPolicyRequire.Val()));
                });

            });

            services.AddSingleton<IAuthorizationHandler, ClientPolicyHandler>();
        }
    }


    }

