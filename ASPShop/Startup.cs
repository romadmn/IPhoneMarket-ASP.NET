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
        }

        // Обов'язковий методЮ, який встановлює, як буде оброблятися запрос
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMessageSender messageSender)
        {
            app.UseFileServer();
            // обробка помилок HTTP
            //app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            //app.Map("/error", ap => ap.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
            //}));
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageSender.Send("Hello world!"));
            });
        }
    }
}
