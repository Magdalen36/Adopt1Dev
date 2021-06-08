
using Adopt1Dev.ASP.Models;
using Adopt1Dev.ASP.Models.Form;
using Adopt1Dev.ASP.Services;
using Adopt1Dev.ASP.Tools;
using Adopt1Dev.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Adopt1Dev.ASP
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
            services.AddControllersWithViews();

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => false;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            //Sessions
            services.AddDistributedMemoryCache(); //Fortement recommandé, mais ne fonctionne qu'en single server
            services.AddSession(
                options => {
                    options.IdleTimeout = TimeSpan.FromMinutes(15);
                    options.Cookie.Name = "Adopt1DevCookie";                    
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                   // options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                }
            );

            //Injection pour permettre l'utilisation des sessions dans les classes non mvc
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<DataContext>();

            services.AddScoped<IService<UserModel, UserForm>, UserService>();
            services.AddScoped<IService<SkillModel, SkillForm>, SkillService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Etape 1 pour utiliser des sessions
            app.UseSession();
            //Permet à notre classe de gestion de session de résoudre


            //les services
            SessionUtils.Services = app.ApplicationServices;

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
