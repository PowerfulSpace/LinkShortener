using Microsoft.EntityFrameworkCore;
using PS.LinkShortening.DAL.Data;
using PS.LinkShortening.Web.Definitions.Base;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDefinitions(builder, typeof(Program));


var app = builder.Build();


using(var scope = app.Services.CreateScope())
{
    await DataInitializer.InitializerAsync(scope.ServiceProvider);
}

app.UseDefinitions();