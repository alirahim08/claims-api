using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceProviders.Api.Configuration;
using InsuranceProviders.Domain.Services;
using InsuranceProviders.Repositories;
using InsuranceProviders.Repositories.MySql;
using InsuranceProviders.Services;
using InsuranceProviders.Services.Search.Lucene;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace InsuranceProviders.Api
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection")
                .Replace("\\", "");
            
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddTransient<IDbRepositiory, MySqlRepository>(conn =>
                new MySqlRepository(connectionString));
            services.AddTransient<IInsuranceProviderRepository, InsuranceProviderRepository>();
            services.AddTransient<IInsuranceProviderSearchService>(x =>
            {
                var appSettings = x.GetService<IOptions<AppSettings>>();
                return new InsuranceProviderSearchService(appSettings?.Value.IndexPath);
            });
             
            services.AddTransient<IInsuranceProviderService, InsuranceProviderService>();

            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactSearchService, ContactSearchService>();
            services.AddTransient<IContactService, ContactService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "InsuranceProviders.Api", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InsuranceProviders.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}