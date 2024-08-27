using E_CommerceAPI.Models;
using E_CommerceMVC.Data;
using E_CommerceMVC.Services.BrandServices;
using E_CommerceMVC.Services.CategoryServices;
using E_CommerceMVC.Services.OrderServices;
using E_CommerceMVC.Services.ProductServices;
using E_CommerceMVC.Services.UserServices;

//using E_CommerceMVC.Services.UserServices;
using Microsoft.AspNetCore.Identity;
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
            builder.Services.AddIdentity<User, IdentityRole>(options=>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            builder.Services.AddScoped<IProductServices,ProductServices>();
            builder.Services.AddScoped<IBrandServices, BrandServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            //builder.Services.AddScoped<ILogger>(); 


            //builder.Services.AddScoped<ICategoryServices, CategoryServices>();

            builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            builder.Services.AddSession();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
