using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace TestProject.Middleware
{
	public class MediKAuthSchemeOption : AuthenticationSchemeOptions
	{
		private const string MediKAuthScheme = "MKA";
		public static string Scheme => MediKAuthScheme;
	}

	public class MediKAuthSchemeHandler : AuthenticationHandler<MediKAuthSchemeOption>
	{
        public MediKAuthSchemeHandler(IOptionsMonitor<MediKAuthSchemeOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
            var authHeader = Request.Headers["Authorization"];

            var parts = authHeader.ToString().Split(" ");

            if (parts.Length != 2 || !parts[0].Equals("Bearer"))
            {
                return AuthenticateResult.NoResult();
            }

            var token = parts[1];

            var claims = new[] { new Claim(ClaimTypes.Name, "username"), new Claim(ClaimTypes.Role, "Client"), };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            await Task.CompletedTask;

            return AuthenticateResult.Success(ticket);
        }
	}

    public static class MediKAuthExtension
    {
        public static void AddMediKAuthHandler(this IServiceCollection services)
        {
            services.AddAuthentication()
            .AddScheme<MediKAuthSchemeOption, MediKAuthSchemeHandler>(MediKAuthSchemeOption.Scheme
            , options => {});
        }
    }
}

