using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace ASPShop
{
    public class Startup
    {
        IWebHostEnvironment _env;
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }
        // Метод для реєстрації сервісів
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<MessageSender>();
            // Добавлення сервісів сесії
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // Обов'язковий метод, який встановлює, як буде оброблятися запрос
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageSender messageSender)
        {
            app.UseSession(); // Добавлення механізму роботи з сесіями
            app.UseFileServer();
            // обробка помилок HTTP
            //app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            //app.Map("/error", ap => ap.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
            //}));
            app.Run(async (context) =>
            {
                if (context.Session.Keys.Contains("name"))
                    await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
                else
                {
                    context.Session.SetString("name", "Roman");
                    await context.Response.WriteAsync("Hello World!");
                }
            });
        }
    }
}
