using System;
using Microsoft.AspNetCore.Authorization;
using static TestProject.Policies.PoliciesEnum;

namespace TestProject.Policies
{
    public class StaffPolicyRequirement : IAuthorizationRequirement
    {
        public string Identity { get; }

        public StaffPolicyRequirement(string identity)
        {
            Identity = identity;
        }
    }

    public class StaffPolicyHandler : AuthorizationHandler<StaffPolicyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, StaffPolicyRequirement requirement)
        {

            if (context.User.IsInRole(PolicyEnum.StaffPolicyRequire.Val()))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class StaffAuthorizeAttribute : AuthorizeAttribute
    {
        public StaffAuthorizeAttribute() : base(PolicyEnum.StaffPolicy.Val())
        {
        }
    }

    public static class StaffPolicyExtension
    {
        public static void AddStaffPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {

                options.AddPolicy(PolicyEnum.StaffPolicy.Val(), policy =>
                {
                    policy.Requirements.Add(new ClientPolicyRequirement(PolicyEnum.StaffPolicyRequire.Val()));
                });

            });

            services.AddSingleton<IAuthorizationHandler, StaffPolicyHandler>();
        }
    }


}

