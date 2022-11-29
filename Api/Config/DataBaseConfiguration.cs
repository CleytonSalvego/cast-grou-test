using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Config
{
    public static class DataBaseConfiguration
    {

        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}