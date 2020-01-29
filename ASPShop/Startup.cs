using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        // ����� ��� ��������� ������
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // ����'������� ������, ���� ����������, �� ���� ����������� ������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // �������� ���� ������� ��� ���������� /pages
            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\")),

                RequestPath = new PathString("/pages")
            }); 
            // Html ������� �� �������������
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear(); // ������� ����� ������ �� ���������
            options.DefaultFileNames.Add("index.html"); // ��������� ����� ��� �����
            app.UseDefaultFiles(options); // ��������� ����������
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
