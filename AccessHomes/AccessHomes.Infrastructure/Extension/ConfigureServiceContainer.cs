using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using AccessHomes.Domain.Settings;
using AccessHomes.Infrastructure.Configs;
using FluentValidation.AspNetCore;
using AccessHomes.Service.Contract;
using AccessHomes.Service.Implementation;
using AccessHomes.Persistence;
using System;
using System.Collections.Generic;
using FluentValidation;
using AccessHomes.Service.DTO.Request;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Polly.Extensions.Http;
using Polly;
using System.Net;
using System.Net.Http.Headers;
using Hangfire;
using Hangfire.SqlServer;
using AccessHomes.Domain.Utils;
using System.Configuration;
using CloudinaryDotNet;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace AccessHomes.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
             IConfiguration configuration, IConfigurationRoot configRoot)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("SQLDBConnectionString") ?? configRoot["ConnectionStrings:SQLDBConnectionString"]
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        public static void AddHangfire(this IServiceCollection serviceCollection, 
            IConfiguration config, IConfigurationRoot configRoot)
        {
            var hangfireDbContext = serviceCollection.BuildServiceProvider().GetService<IApplicationDbContext>();

            serviceCollection.AddHangfire(configuration => configuration
          .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(config.GetConnectionString("SQLDBConnectionString") ?? configRoot["ConnectionStrings:SQLDBConnectionString"], new SqlServerStorageOptions
          {
              CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
              SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
              QueuePollInterval = TimeSpan.FromSeconds(15),
              UseRecommendedIsolationLevel = true,
              UsePageLocksOnDequeue = true,
              DisableGlobalLocks = true,
          }));

            serviceCollection.AddHangfireServer(options =>
            {
                options.ServerName = String.Format("{0}.{1}", Environment.MachineName, Guid.NewGuid().ToString());
                options.WorkerCount = 1;
                options.Queues = new[] {
                      HangfireQueues.Default,
                    };
            });

            serviceCollection.AddHangfireServer(options =>
            {
                options.ServerName = String.Format("{0}.{1}", Environment.MachineName, HangfireQueues.ReminderEmails.ToString());
                options.WorkerCount = 1;
                options.Queues = new[] {
                      HangfireQueues.ReminderEmails,
                    };
            });
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDateTimeService, DateTimeService>();
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<IDBFactory, DBFactory>();
            serviceCollection.AddTransient<IClientFactory, ClientFactory>();
            serviceCollection.AddTransient<IRepository, Repository>();
            serviceCollection.AddTransient<INotificationService, NotificationService>();
        }

        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(MappingProfileConfiguration));
            //serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            serviceCollection.AddScoped<IPropertiesRepo, PropertiesRepo>();
            serviceCollection.AddScoped<IAttachmentsRepo, AttachmentsRepo>();
            serviceCollection.AddScoped<IAmenitiesRepo, AmenitiesRepo>();
            serviceCollection.AddScoped<IPhotoService, PhotoService>();
            serviceCollection.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));


        }

        
        public static void AddValidation(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IValidator<CreatePersonRequest>, CreatePersonRequestValidator>();
            serviceCollection.AddTransient<IValidator<UpdatePersonRequest>, UpdatePersonRequestValidator>();

            //Disable Automatic Model State Validation built-in to ASP.NET Core
            serviceCollection.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
        }

        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "Access Homes WebAPI",
                        Version = "1",
                        Description = "Access Homes aims to create an ecosystem of property owners/tenants in Nigeria.",
                        Contact = new OpenApiContact()
                        {
                            Email = "aff@africafintechfoundry.com",
                            Name = "Seyi Balogun",
                            Url = new Uri("https://github.com/adesokanayo/accesshomes/tree/main/AccessHomes")
                        }
                    });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });

        }

        public static void AddController(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddControllers()
                           .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(s => {
                               s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                           })
                           .AddFluentValidation();
        }

        public static void AddVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }

        public static void AddHTTPPolicies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var policyConfigs = new HttpClientPolicyConfiguration();
            configuration.Bind("HttpClientPolicies", policyConfigs);

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(policyConfigs.RetryTimeoutInSeconds));

            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(r => r.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(policyConfigs.RetryCount, _ => TimeSpan.FromMilliseconds(policyConfigs.RetryDelayInMs));

            var circuitBreakerPolicy = HttpPolicyExtensions
               .HandleTransientHttpError()
               .CircuitBreakerAsync(policyConfigs.MaxAttemptBeforeBreak, TimeSpan.FromSeconds(policyConfigs.BreakDurationInSeconds));

            var noOpPolicy = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

            serviceCollection.AddHttpClient<IClientFactory, ClientFactory>(client =>
            {
                //client.BaseAddress = new Uri(configuration["ApiResourceBaseUrls:SampleApi"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(policyConfigs.HandlerTimeoutInMinutes))
            .AddPolicyHandler(request => request.Method == System.Net.Http.HttpMethod.Get ? retryPolicy : noOpPolicy)
            .AddPolicyHandler(timeoutPolicy)
            .AddPolicyHandler(circuitBreakerPolicy);
        }

        public static void AddHealthCheck(this IServiceCollection serviceCollection, AppSettings appSettings, IConfiguration configuration)
        {
            serviceCollection.AddHealthChecks()
                .AddUrlGroup(new Uri(appSettings.ApplicationDetail.ContactWebsite), name: "My personal website", failureStatus: HealthStatus.Degraded)
                .AddSqlServer(configuration.GetConnectionString("SQLDBConnectionString"));

            serviceCollection.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Basic Health Check", $"/healthz");
            }).AddInMemoryStorage();
        } 

        public static void AddRequestRateLimiter(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // needed to load configuration from appsettings.json
            serviceCollection.AddOptions();
            // needed to store rate limit counters and ip rules
            serviceCollection.AddMemoryCache();

            //load general configuration from appsettings.json
            serviceCollection.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

            // inject counter and rules stores
            serviceCollection.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            serviceCollection.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            // https://github.com/aspnet/Hosting/issues/793
            // the IHttpContextAccessor service is not registered by default.
            // the clientId/clientIp resolvers use it.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // configuration (resolvers, counter key builders)
            serviceCollection.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
