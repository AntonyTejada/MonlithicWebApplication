using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonolithicWebApplication.Business.Entities;
using MonolithicWebApplication.Infraestructure.API;
using MonolithicWebApplication.Infraestructure.Data;
using MonolithicWebApplication.Infraestructure.Extensions;
using MonolithicWebApplication.Infraestructure.Repositories;

namespace MonolithicWebApplication
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
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<ProductRepository, ProductRepository>();
            services.AddHttpClient<IExternalProductProviderClient, ExternalProductProviderClient>();
            services.AddIdentity<IdentityUser, IdentityRole>( options => {
                options.Password.RequireDigit = true;
                }).AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDatabaseProvider();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                /*endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{controller=Admin}/{action=Products}/{id?}");*/
            });
        }
    }
}
