using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

//https://jasonwatmore.com/net-7-csharp-jwt-authentication-tutorial-without-aspnet-core-identity

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class BackendAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var role = (string)context.HttpContext.Items["userRole"];
        if (role == null || role != "backend")
        {
            // not logged in
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}