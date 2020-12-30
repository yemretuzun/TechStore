using System;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TechStoreAPI.Services;

namespace TechStoreAPI
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
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TechStoreAPI", Version = "v1", 
                    Contact =  new OpenApiContact(){Name = "Yunus Emre Tüzün", Email = "yemretuzun@gmail.com"},
                    Description = "Bilgisayar mühendisliði projesi olarak yapýlan TechStore web sitesi için hazýrlanmýþ RESTful Web API",
                });

                // Enable XML Comments
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            // Servisleri singleton olarak ekle.
            services.AddSingleton<UserService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<PermissionsService>();
            services.AddSingleton<RoleService>();
            services.AddSingleton<RolePermissionService>();
            services.AddSingleton<CredentialsService>();
            services.AddSingleton<CredentialTypesService>();
            services.AddSingleton<BrandService>();
            services.AddSingleton<CategoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechStoreAPI v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
