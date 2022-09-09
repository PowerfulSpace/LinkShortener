using PS.LinkShortening.DAL.Interfaces;
using PS.LinkShortening.DAL.Repositories;
using PS.LinkShortening.Service.Implementations;
using PS.LinkShortening.Service.Interfaces;
using PS.LinkShortening.Web.Definitions.Base;

namespace PS.LinkShortening.Web.Definitions.DependencyInjection
{
    public class DependencyInjectionDefinitions : AppDefinitions
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILink, LinkRepository>();
            services.AddScoped<ILinkService, LinkService>();
        }
    }
}
