using CarAuctionMVC.Application.Context;
using CarAuctionMVC.Application.Dtos;
using CarAuctionMVC.Application.Seeders;
using CarAuctionMVC.Application.Services;
using CarAuctionMVC.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.SetMinimumLevel(LogLevel.Error);
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddDbContext<CarAuctionMVCDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), a => a.MigrationsAssembly("CarAuctionMVC.Application")));

builder.Services.AddScoped<ICarAuctionSeeder, CarAuctionSeeder>();
builder.Services.AddTransient<IAuctionService, AuctionService>();
builder.Services.AddTransient<IValidator<NewAuctionDto>,NewAuctionDtoValidator>();

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
