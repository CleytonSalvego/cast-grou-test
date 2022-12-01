using Client.Interfaces;
using Client.Services;

namespace Client.Config
{
    public static class DependencyInjectionConfiguration
    {
         public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddHttpClient<IAccountService, AccountService>();
        }
    }
}
