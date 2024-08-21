using E_CommerceMVC.Data;
using E_CommerceMVC.Services.BrandServices;
using E_CommerceMVC.Services.CategoryServices;
using E_CommerceMVC.Services.OrderServices;
using E_CommerceMVC.Services.ProductServices;
using E_CommerceMVC.Services.UserServices;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("No Connection String was found.");

            builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(ConnectionStrings));

            builder.Services.AddScoped<IProductServices,ProductServices>();
            builder.Services.AddScoped<IBrandServices, BrandServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();


            //builder.Services.AddScoped<ICategoryServices, CategoryServices>();

            builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            builder.Services.AddSession(o =>
                o.IdleTimeout = TimeSpan.FromMinutes(1800)
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
