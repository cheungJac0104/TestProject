using Microsoft.AspNetCore.Authorization;
using TestProject;
using TestProject.Extension;
using TestProject.Policies;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureCors();
    builder.Services.AddClientPolicy();
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
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseRouting();

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
