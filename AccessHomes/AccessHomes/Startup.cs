using AspNetCoreRateLimit;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AccessHomes.Domain.Settings;
using AccessHomes.Infrastructure.Extension;
using AccessHomes.Service;
using Serilog;
using System.IO;
using Hangfire;
using System;
using CloudinaryDotNet;
using System.Linq;

namespace AccessHomes
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;
        private AppSettings AppSettings { get; set; }

        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configRoot = builder.Build();

            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            


            services.AddDbContext(Configuration, configRoot);
          
            services.AddController();

            services.AddIdentityService(Configuration);

            services.AddTransientServices();

            services.AddAutoMapper();

            services.AddScopedServices(Configuration);

            services.AddSwaggerOpenAPI();

            services.AddServiceLayer();

            services.AddHangfire(Configuration, configRoot);

            services.AddVersion();

            services.AddHTTPPolicies(Configuration);

            services.AddRequestRateLimiter(Configuration);
            
            services.AddHealthCheck(AppSettings, Configuration);
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
                 options.WithOrigins("http://localhost:3000")
                 .AllowAnyHeader()
                 .AllowAnyMethod());

            app.ConfigureCustomExceptionMiddleware();

            log.AddSerilog();

            //app.ConfigureHealthCheck();


            app.UseRouting();

            app.UseIpRateLimiting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.ConfigureSwagger();
            app.ConfigureHangfire();
            app.UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
                },
            }).UseHealthChecksUI(setup =>
              {
                  setup.ApiPath = "/healthcheck";
                  setup.UIPath = "/healthcheck-ui";
                  //setup.AddCustomStylesheet("Customization/custom.css");
              });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });
        }
    }
}
