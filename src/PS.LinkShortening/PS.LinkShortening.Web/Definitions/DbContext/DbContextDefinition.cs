using Microsoft.EntityFrameworkCore;
using PS.LinkShortening.DAL.Data;
using PS.LinkShortening.Web.Definitions.Base;

namespace PS.LinkShortening.Web.Definitions.DbContext
{
    public class DbContextDefinition : AppDefinitions
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseMySql(configuration.GetConnectionString("MysqlConntextion"), new MySqlServerVersion(new Version(8, 0, 20))));
        }
    }
}
