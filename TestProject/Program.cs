using TestProject;
using TestProject.Services;
using Microsoft.EntityFrameworkCore;
using TestProject.Context; 
using TestProject.Middleware;
using TestProject.Middleware.AppSettingsOptions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using TPT.App;
using Autofac.Extensions.DependencyInjection;
using TestProject.Service.Login;
using Autofac.Core;
using System.Configuration;
using TestProject.Infrastructure;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddDbContext<MysqlDBContext>(options => options
              .UseMySql(TestProject.Helper.ConfigurationManager.AppSetting.GetConnectionString("MySql"), MySqlServerVersion.LatestSupportedServerVersion));
    builder.Services.AddDbContext<AppDBContext>(options => options
              .UseFirebird(TestProject.Helper.ConfigurationManager.AppSetting.GetConnectionString("FireBird")));


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureCors();
    // Services

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(opt => {
        opt.SwaggerDoc("v1", new OpenApiInfo() { Title = $"Medikare API v1.0", Version = "1.0"});
        opt.SwaggerDoc("v2", new OpenApiInfo() { Title = $"Medikare API v2.0", Version = "2.0" });

        opt.DocInclusionPredicate((doc, apiDesc) =>
        {
            if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

            var versions = methodInfo.GetCustomAttributes(true)
            .OfType<ApiVersionAttribute>()
            .SelectMany(Attribute => Attribute.Versions).ToList();

            return versions.Any(versions => $"v{versions.ToString()}".StartsWith(doc));
        });
    });

    builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSetting"));

    builder.Services.AddControllers(opt => {

    });
    builder.Services.ConfigureCors();
    builder.Services.AddRouting(r => r.LowercaseUrls = true);

    builder.Services.AddHttpContextAccessor();

    // services injection
    builder.Services.AddScoped<IPatientInfoServices, PatientInfoServices>();
    builder.Services.AddScoped<IPatientQueueServices, PatientQueueServices>();

    builder.Services.AddScoped<ILoginService, LoginService>();



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
