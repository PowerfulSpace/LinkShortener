using Microsoft.EntityFrameworkCore;
using PS.LinkShortening.DAL.Data;
using PS.LinkShortening.Web.Definitions.Base;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDefinitions(builder, typeof(Program));


var app = builder.Build();
app.UseDefinitions();

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}
