using System;
using Microsoft.AspNetCore.Authorization;
using static TestProject.Middleware.Policies.PoliciesEnum;

namespace TestProject.Middleware.Policies
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

            context.Succeed(requirement);

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
                    policy.Requirements.Add(new StaffPolicyRequirement(PolicyEnum.StaffPolicyRequire.Val()));
                });

            });

            services.AddSingleton<IAuthorizationHandler, StaffPolicyHandler>();
        }
    }


}

