
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PS.LinkShortening.DAL.Data
{
    public static class DataInitializer
    {
        public static async Task InitializerAsync(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            var isExists = await context!.Database.EnsureCreatedAsync();

            if (isExists)
            {
                return;
            }

            await context!.Database.MigrateAsync();

            await context.SaveChangesAsync();
        }
    }



}
