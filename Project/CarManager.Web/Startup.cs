using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarManager.Data;
using CarManager.Models;
using CarManager.Web.Common;
using AutoMapper;
using CarManager.Services.LoggedUser.Interfaces;
using CarManager.Services.LoggedUser;

namespace CarManager.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<CarManagerDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CarManagerConnectionString"),
            dbOptions => dbOptions.MigrationsAssembly("CarManager.Data"))
            );

            //services.AddDefaultIdentity<User>()
            //    .AddEntityFrameworkStores<CarManagerDbContext>();

            services
                .AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<CarManagerDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireLowercase = true,
                    RequireDigit = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };

                // options.SignIn.RequireConfirmedEmail = true;
            });

            //services.AddSingleton<IEmailSender, SendGridEmailSender>();
            //services.Configure<SendGridOptions>(this.Configuration.GetSection("EmailSettings"));

            services.AddAutoMapper();

            RegisterServiceLayer(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
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

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            //public void Configure(
            //    IApplicationBuilder app,
            //    IHostingEnvironment env,
            //    UserManager<User> userManager,
            //    RoleManager<IdentityRole> roleManager)
            //{
            //    if (env.IsDevelopment())
            //    {
            //        app.UseDeveloperExceptionPage();
            //        app.UseDatabaseErrorPage();
            //    }
            //    else
            //    {
            //        app.UseExceptionHandler("/Error");
            //        app.UseHsts();
            //    }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.SeedDatabase();
            }

            app.UseMvc();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<ILoggedUserVehiclesService, LoggedUserVehiclesService>();
        }

    }
}

