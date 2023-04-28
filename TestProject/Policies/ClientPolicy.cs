using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using static TestProject.Policies.PoliciesEnum;

namespace TestProject.Policies
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
            
            //if (context.User.IsInRole(PolicyEnum.ClientPolicyRequire.Val()))
            //{
            //    context.Succeed(requirement);
            //}

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

