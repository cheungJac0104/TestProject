namespace TestProject
{
	public static class ConfigureExtensions
	{
		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyOrigin());
			});
		}


	}
}

