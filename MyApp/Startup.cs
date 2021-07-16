using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Common;
using MyApp.Controllers;
using MyApp.Data;
using System;

namespace MyApp
{
    public static class ConfigServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<MyService>();
            services.AddTransient<MySecondService>();
            services.AddTransient<MyRepository>();
            services.AddTransient<ITimeService, TimeService>();
        }

    }
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlite("Data Source=app.sqlite"));

            //ConfigServices.Register(services);
            services.AddServices();

            services.AddMvc();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
