using Microsoft.AspNetCore.Authorization;
using TestProject;
using TestProject.Policies;
using TestProject.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TestProject.Context;

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
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureCors();

    builder.Services.AddRouting(r => r.LowercaseUrls = true);

    builder.Services.AddHttpContextAccessor();

    // services injection
    builder.Services.AddScoped<IPatientInfoServices, PatientInfoServices>();
    
    builder.Services.AddClientPolicy();
    builder.Services.AddStaffPolicy();
    builder.Services.AddMediKAuthHandler();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseAuthentication();
        

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
