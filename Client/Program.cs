using Client.Config;

var builder = WebApplication.CreateBuilder(args);

StartAPI(builder);

void StartAPI(WebApplicationBuilder builder)
{
    ConfigureServices(builder);
    var app = builder.Build();
    if (!app.Environment.IsDevelopment())
    {

       
        app.UseExceptionHandler("/Error");
        app.UseHsts();  
    }
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.MapRazorPages();
    app.Run();

}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddRazorPages();
    builder.Services.AddRazorPagerConfiguration();
    builder.Services.AddDependencyInjectionConfiguration();
}
