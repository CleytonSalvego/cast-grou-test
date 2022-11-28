using System.Text.Json.Serialization;

namespace Api.Config
{
    public static class DefaultConfiguration
    {
        public static void AddDefaultConfiguration(this IServiceCollection services)
        {
            services
                .AddMemoryCache()
                .AddControllers()
                .AddJsonOptions(x =>
                 {
                     x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                     x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                 })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
        }
    }
}
