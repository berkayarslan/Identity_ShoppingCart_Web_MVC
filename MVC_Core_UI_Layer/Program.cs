using ApplicationLayer.Mapper;
using ApplicationLayer.Services.CategoryServices;
using ApplicationLayer.Services.ProductServices;
using ApplicationLayer.Services.ShoppingCartServices;
using ApplicationLayer.Services.UserServices;
using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using InfrastructureLayer;
using InfrastructureLayer.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_UI_Layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ProductDbContext>();


            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ProductDbContext>()
                .AddRoles<AppRole>();

            //AutoMapper
            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(ProductProjectMapper)));


            //Service'ler IoC
            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IProductService, ProductService>();

            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();

            builder.Services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}