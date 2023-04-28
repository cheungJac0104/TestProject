using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace TestProject
{
	public class MediKAuthSchemeOption : AuthenticationSchemeOptions
	{
		private const string MediKAuthScheme = "MKA";
		public static string Scheme => MediKAuthScheme;
		public string HeaderName { get; set; }
	}

	public class MediKAuthSchemeHandler : AuthenticationHandler<MediKAuthSchemeOption>
	{
        public MediKAuthSchemeHandler(IOptionsMonitor<MediKAuthSchemeOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
            if (!Request.Headers.TryGetValue(Options.HeaderName, out var headerValue))
            {
                return AuthenticateResult.NoResult();
            }

            // Authenticate the user based on the header value
            // ...

            var claims = new[] { new Claim(ClaimTypes.Name, "username"), new Claim(ClaimTypes.Role, "Client"), };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
	}

    public static class MediKAuthExtension
    {
        public static void AddMediKAuthHandler(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = MediKAuthSchemeOption.Scheme;
            })
    .AddScheme<MediKAuthSchemeOption, MediKAuthSchemeHandler>(MediKAuthSchemeOption.Scheme
    , options => { options.HeaderName = "X-Custom-Header"; });
        }
    }
}

