//using HealthChecks.UI.Client;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using AccessHomes.Infrastructure.Middleware;
using Serilog;
using Hangfire;
using AccessHomes.Infrastructure.Filter;

namespace AccessHomes.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "Access Homes API");
                setupAction.RoutePrefix = "OpenAPI";
            });
        }

        public static void ConfigureHangfire(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                DashboardTitle = "Access Homes - Hangfire"
                //Authorization = new[] { new HangfireAuthorizationFilter() }
            });
        }

        public static void ConfigureSwagger(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
        }

        public static void UseHealthCheck(this IApplicationBuilder app)
        {
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
            });
        }
    }
}
