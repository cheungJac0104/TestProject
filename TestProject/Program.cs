using TestProject;
using TestProject.Services;
using Microsoft.EntityFrameworkCore;
using TestProject.Context;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TestProject.Services.Staff;
using TestProject.Infrastructure;
using TestProject.Middleware.AppSettingsOptions;
using TestProject.Middleware;
using Microsoft.Extensions.DependencyInjection;
using TestProject.MessageQueue.Interfaces;
using TestProject.MessageQueue;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddDbContext<MysqlDBContext>(options => options
              .UseMySql(TestProject.Helper.ConfigurationManager.AppSetting.GetConnectionString("MySql"), MySqlServerVersion.LatestSupportedServerVersion));
    builder.Services.AddDbContext<AppDBContext>(options => options
              .UseFirebird(TestProject.Helper.ConfigurationManager.AppSetting.GetConnectionString("FireBird")));

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(opt => {
        opt.SwaggerDoc("v1", new OpenApiInfo() { Title = $"Medikare API v1.0", Version = "1.0"});
        opt.SwaggerDoc("v2", new OpenApiInfo() { Title = $"Medikare API v2.0", Version = "2.0" });

        opt.AddSecurityDefinition("apikey", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = ParameterLocation.Header
        });
        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "apikey"
                    }
                },
                new string[] {}
            }
        });

        opt.DocInclusionPredicate((doc, apiDesc) =>
        {
            if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

            var versions = methodInfo.GetCustomAttributes(true)
            .OfType<ApiVersionAttribute>()
            .SelectMany(Attribute => Attribute.Versions).ToList();

            return versions.Any(versions => $"v{versions}".StartsWith(doc));
        });
    });

    builder.Services.Configure<AppSetting>(builder.Configuration.GetSection(nameof(AppSetting)));

    builder.Services.AddControllers(opt => {

    });
    builder.Services.ConfigureCors();
    builder.Services.AddRouting(r => r.LowercaseUrls = true);

    builder.Services.AddHttpContextAccessor();

    // services injection
    builder.Services.AddScoped<IStaffServices, StaffServices>();

    builder.Services.AddScoped<IRabbitMQHandler, RabbitMQHandler>();


    builder.Services.Configure<RabbitMQOptions>(builder.Configuration.GetSection(nameof(RabbitMQOptions)));

    var jwtOptions = new JwtOptions();
    var jwtConfig = builder.Configuration.GetSection(nameof(JwtOptions));
    builder.Services.Configure<JwtOptions>(jwtConfig);
    jwtConfig.Bind(jwtOptions);
    builder.Services.AddJwtAuthHandler(jwtOptions);



    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        var swaggerOptions = new SwaggerOptions();
        builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

        app.UseSwagger(opt => { opt.RouteTemplate = swaggerOptions.JsonRoute; });
        app.UseSwaggerUI(opt =>
        {
            swaggerOptions.EndPoints?.ForEach(endpoint =>
            {
                opt.SwaggerEndpoint(endpoint.UIEndPoint, endpoint.ApiDescription);
            });
        });
    }

    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
         

        app.UseMiddleware<AuthenticationMiddleware>();

    }
    

    app.MapControllers();

    app.Run();


}
catch (Exception ex)
{
    throw;
}
finally
{

}
