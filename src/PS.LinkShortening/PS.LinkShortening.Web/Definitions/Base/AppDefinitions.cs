using PS.LinkShortening.Web.Definitions.Base.Interfaces;

namespace PS.LinkShortening.Web.Definitions.Base
{
    public abstract class AppDefinitions : IAppDefinitions
    {
        public virtual void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
        }

        public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
