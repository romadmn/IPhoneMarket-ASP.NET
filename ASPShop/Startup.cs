using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data;
using ASPShop.Data.Models;
using ASPShop.Data.Repository;
using ASPShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace ASPShop
{
    public class Startup
    {
        IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // ����� ��� ��������� ������
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAllProducts, ProductRepository>(); // ����� ���� � ��������� �� �����
            services.AddTransient<IProductsCategory, CategoryRepository>(); // ����� ���� � ��������� �� �����
            services.AddTransient<IAllOrders, OrderRepository>(); // ����� ���� � ��������� �� �����
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MarketContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
            //services.AddTransient<IMessageSender, EmailMessageSender>();
            //services.AddTransient<MessageSender>();
            // ���������� ������ ���
            services.AddMemoryCache();
            services.AddSession();
        }

        // ����'������� �����, ���� ����������, �� ���� ����������� ������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession(); // ���������� �������� ������ � ������
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "categoryFilter",
                    template: "Home/{action}/{category?}", defaults: new { controller = "Home", action = "Products"});
            });
        }

    }
}
