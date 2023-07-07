namespace TestProject.Middleware.AppSettingsOptions
{
	public class SwaggerOptions
	{
		public class EndPoint
		{
			public string ApiDescription { get; set; }
			public string UIEndPoint { get; set; }

		}

		public string JsonRoute { get; set; }
		public System.Collections.Generic.List<EndPoint> EndPoints { get; set; }
		public string SwaggerBasicAuthUserId { get; set; }
		public string SwaggerBasicAuthPassword { get; set; }
	}
}

