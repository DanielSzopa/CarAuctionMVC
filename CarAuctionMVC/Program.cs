using CarAuctionMVC.Application.Context;
using CarAuctionMVC.Application.Seeders;
using CarAuctionMVC.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CarAuctionMVCDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), a => a.MigrationsAssembly("CarAuctionMVC.Application")));

builder.Services.AddScoped<ICarAuctionSeeder, CarAuctionSeeder>();
builder.Services.AddScoped<IAuctionService, AuctionService>();

var app = builder.Build();

var scope =  app.Services.CreateAsyncScope();
var seeder = scope.ServiceProvider.GetRequiredService<ICarAuctionSeeder>();
await seeder.SeedData();

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
