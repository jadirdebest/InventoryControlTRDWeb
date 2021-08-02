using InventoryControlTRD.CrossCutting.Extensions.Ioc;
using InventoryControlTRD.Infrastructure.Configurations;
using InventoryControlTRDWeb.Application.MapperConfig;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace InventoryControlTRDWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddEssentialsServices();
            services.AddAutoMapper(x => x.AddProfile(new MapperProfiles()));

            services.AddDistributedMemoryCache();

            string dbConnectionString = this.Configuration.GetConnectionString("SqlConnectionString");
            services.AddSingleton((sp) => new ConnectionProvider(dbConnectionString));


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.AccessDeniedPath = "/Client/Login/DeniedLogon";
                opt.LoginPath = "/Client/Login/Logon";
                opt.LogoutPath = "";
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=exists}/{controller=Product}/{action=List}/{id?}");
            });
        }
    }
}
