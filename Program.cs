using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using SalesWebMVC.Data;
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
                ?? throw new InvalidOperationException("Connection string 'SWContext' not found.")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<SeedingService>();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
     
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }else
            {
                app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
            }
            

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