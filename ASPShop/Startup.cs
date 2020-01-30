using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ASPShop.Models;
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
        // Метод для реєстрації сервісів
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));
            services.AddMvc();
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<MessageSender>();
            // Добавлення сервісів сесії
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".RomanFerentsApp.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.IsEssential = true;
            });
        }

        // Обов'язковий метод, який встановлює, як буде оброблятися запрос
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageSender messageSender)
        {
            app.UseSession(); // Добавлення механізму роботи з сесіями
            app.UseStaticFiles();
            // обробка помилок HTTP
            //app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            //app.Map("/error", ap => ap.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
            //}));
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
