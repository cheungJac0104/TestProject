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
            
            if (context.User.IsInRole(PolicyEnum.ClientPolicyRequire.Val()))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class ClientAuthorizeAttribute : AuthorizeAttribute
    {
        public ClientAuthorizeAttribute() : base(PolicyEnum.ClientPolicy.Val())
        {
        }
    }


}

