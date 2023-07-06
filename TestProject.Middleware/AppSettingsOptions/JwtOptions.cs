namespace TestProject.Middleware.AppSettingsOptions
{
	public class JwtOptions
	{
		public string? Key { get; set; }
		public string? Issuer { get; set; }
		public string? ExpiryMins { get; set; }
		public string? Audience { get; set; }
		public string? RefreshTokenMins { get; set; }
	}
}

