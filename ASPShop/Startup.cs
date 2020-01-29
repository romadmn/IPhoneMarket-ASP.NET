using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
        }

        // Обов'язковий методЮ, який встановлює, як буде оброблятися запрос
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            int x = 5;
            int y = 8;
            int z = 0;
            app.Use(async (context, next) =>
            {
                z = x * y;
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"x * y = {z}");
            });
        }
    }
}
