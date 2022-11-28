var builder = WebApplication.CreateBuilder(args);

StartAPI(builder);

void StartAPI(WebApplicationBuilder builder)
{
    ConfigureServices(builder);

    var app = builder.Build();
    app.MapControllers();
    app.UseSwagger();
    app.UseSwaggerConfiguration();
    app.UseCorsConfiguration();
    app.UseHealthChecks("/health");
    app.Run();
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDefaultConfiguration();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddCorsConfiguration();
    builder.Services.AddSwaggerConfiguration();
    builder.Services.AddHealthChecks();
    builder.Services.AddDependencyInjectionConfiguration();
}
