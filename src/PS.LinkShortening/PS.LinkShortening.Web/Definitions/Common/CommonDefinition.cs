using PS.LinkShortening.Service.Models.Settings;
using PS.LinkShortening.Web.Definitions.Base;

namespace PS.LinkShortening.Web.Definitions.Common
{
    public class CommonDefinition : AppDefinitions
    {

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<AppSettings>(configuration);
            var config = configuration.Get<AppSettings>();

            services.AddMemoryCache(options =>
            {
                options.SizeLimit = config.Cache.ItemLimit;
            });

            services.AddControllersWithViews();
                //.AddRazorRuntimeCompilation();
        }

        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

     

    }
}
