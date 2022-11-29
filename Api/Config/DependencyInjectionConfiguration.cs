using Api.Data;
using Api.Interfaces;
using Api.Repository;
using Api.Services;

namespace Api.Config
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICepService, CepService>();
            services.AddScoped<IHttpService, HttpRestSharpService>();
        }
    }
}