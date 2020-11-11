using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MyFirstAspNetCoreApplication.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFirstAspNetCoreApplication.Service;
using System.Net.Http;
using MyFirstAspNetCoreApplication.Filters;
using MyFirstAspNetCoreApplication.ModelBinders;

namespace MyFirstAspNetCoreApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews(configure =>
            {
                configure.Filters.Add(new MyAuthFilter());
                configure.Filters.Add(new MyResultFilterAttribute());
                configure.Filters.Add(new MyExceptionFilter());
                configure.Filters.Add(new MyResourceFilter());
                configure.ModelBinderProviders.Insert(0, new ExtractYearModelBinderProvider());
            });
            services.AddRazorPages();

            // singleton / scoped / transient
            services.AddTransient<IInstanceCounter, InstanceCounter>();
            services.AddSingleton<AddHeaderActionFilterAttribute>();
            services.AddTransient<IShortStringService, ShortStringService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Action<HttpContext, RequestDelegate> RequestDelegate
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "blog",
                    pattern: "blog/{year}/{month}/{day}");
                endpoints.MapRazorPages();
            });

        }
    }
}
