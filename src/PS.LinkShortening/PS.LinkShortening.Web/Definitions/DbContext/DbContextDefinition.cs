using Microsoft.EntityFrameworkCore;
using PS.LinkShortening.DAL.Data;
using PS.LinkShortening.Web.Definitions.Base;

namespace PS.LinkShortening.Web.Definitions.DbContext
{
    public class DbContextDefinition : AppDefinitions
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
