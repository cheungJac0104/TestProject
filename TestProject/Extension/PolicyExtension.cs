using System;
using Microsoft.AspNetCore.Authorization;
using static TestProject.Policies.PoliciesEnum;
using TestProject.Policies;

namespace TestProject.Extension
{
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

                options.AddPolicy(PolicyEnum.AdminPolicy.Val(), policy =>
                {
                    policy.Requirements.Add(new ClientPolicyRequirement(PolicyEnum.AdminPolicyRequire.Val()));
                });

                options.AddPolicy(PolicyEnum.StaffPolicy.Val(), policy =>
                {
                    policy.Requirements.Add(new ClientPolicyRequirement(PolicyEnum.StaffPolicyRequire.Val()));
                });

            });

            services.AddSingleton<IAuthorizationHandler, ClientPolicyHandler>();
        }

        public static void AddStaffPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyEnum.AdminPolicy.Val(), policy =>
                {
                    policy.Requirements.Add(new ClientPolicyRequirement(PolicyEnum.AdminPolicyRequire.Val()));
                });

                options.AddPolicy(PolicyEnum.StaffPolicy.Val(), policy =>
                {
                    policy.Requirements.Add(new ClientPolicyRequirement(PolicyEnum.StaffPolicyRequire.Val()));
                });

            });

            services.AddSingleton<IAuthorizationHandler, ClientPolicyHandler>();
        }
    }


}

