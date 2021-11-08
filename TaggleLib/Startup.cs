using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaggleLib.Services;

namespace TaggleLib
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
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            services.AddTransient<JsonRepository>();
            services.AddTransient<SQLServerRepository>();
            services.AddTransient<OracleRepository>();
            services.AddTransient<ServiceResolverHelper.ServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "JSON":
                        return serviceProvider.GetService<JsonRepository>();
                    case "SQL":
                        return serviceProvider.GetService<SQLServerRepository>();
                    case "ORACLE":
                        return serviceProvider.GetService<OracleRepository>();
                    default:
                        return serviceProvider.GetService<JsonRepository>();
                }
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
