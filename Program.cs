using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using SalesWebMVC.Data;
using SalesWebMVC.Models.Services;
using SQLitePCL;

namespace SalesWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Database Connection
            builder.Services.AddDbContext<SalesWebContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("SalesWebContext") 
                ?? throw new InvalidOperationException("Connection string 'SalesWebContext' not found.")));

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
               app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
            

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