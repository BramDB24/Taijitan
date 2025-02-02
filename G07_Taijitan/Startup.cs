﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using G07_Taijitan.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Data.Repositories;
using System.Security.Claims;
using G07_Taijitan.Filters;
using G07_Taijitan.Helpers;
using G07_Taijitan.Models.Domain.RepoInterface;

namespace G07_Taijitan
{
    /* change at 2402 policy toegevoegd, appuser toegevoegd, seeding met task ipv methode*/
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DatabaseConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Lid", policy => policy.RequireClaim(ClaimTypes.Role, "Lid"));
                options.AddPolicy("Lesgever", policy => policy.RequireClaim(ClaimTypes.Role, "Lesgever"));
                options.AddPolicy("InSessie", policy => policy.RequireClaim(ClaimTypes.Role, "InSessie"));
            });
            services.AddSession();
            services.AddScoped<GebruikerDataInitializer>();
            services.AddScoped<IGebruikerRepository, GebruikerRepository>();
            services.AddScoped<IOefeningRepository, OefeningRepository>();
            services.AddScoped<ISessieRepository, SessieRepository>();
            services.AddScoped<GebruikerFilter>();
            services.AddScoped<SessieFilter>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new GebruikerEntityProvider());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GebruikerDataInitializer initializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseStatusCodePagesWithRedirects("/Home/Error");

            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Graad}/{action=Index}/{id?}");
            });
            initializer.InitializeData().Wait();
        }
    }
}
