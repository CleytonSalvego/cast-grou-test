namespace Client.Config
{
    public static class RazorPagerConfiguration
    {
        public static void AddRazorPagerConfiguration(this IServiceCollection services)
        {

            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            services.AddMvc()
               .AddRazorPagesOptions(options =>
               {
                   options.Conventions.AddPageRoute("/Account/AccountPage/index", "");
               });
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.RootDirectory = "/Pages";
                });
        }
    }
}
