using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using DotNetCoreBoilerplate.Areas.Identity.Filters;
using DotNetCoreBoilerplate.Areas.Identity.Models;
using DotNetCoreBoilerplate.Areas.Identity.Services;
using DotNetCoreBoilerplate.Common;
using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Identity.Models;
using DotNetCoreBoilerplate.Identity.Models.UserManagment;

namespace DotNetCoreBoilerplate
{
    public class Startup
    {
        private static string ConnectionString;
        public static string UserSessionKey;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            UserSessionKey = "SampleApp";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(ConnectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();

            //Runtime Compilation for View
            services.AddMvc().AddRazorRuntimeCompilation();

            //Configure Identity options and password complexity here
            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;
            });

            services.AddSingleton<IMvcControllerDiscovery, MvcControllerDiscovery>();
            services.AddSingleton<IRolesList, RolesList>();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomAuthorizationFilter));
            });

            //Date And Time Parsing Globel Options
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
                options.EnableEndpointRouting = false;
            });

            //Json Searlization of Complex objects
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            //services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = UserSessionKey;
                options.IdleTimeout = TimeSpan.FromMinutes(200);
                options.Cookie.HttpOnly = true;
                // options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserSessionService, UserSessionService>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                        {
                            new CultureInfo("en-GB"),
                        };
                options.DefaultRequestCulture = new RequestCulture("en-GB");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
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
                app.UseHsts();
            }
            //app.UseStaticFiles(
            //    new StaticFileOptions()
            //    {
            //        FileProvider = new PhysicalFileProvider(Configuration.GetConnectionString("GCXOR")),
            //        RequestPath = new PathString("/GCXOR")
            //    }
            // );

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            app.UseRequestLocalization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areaRoute",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}