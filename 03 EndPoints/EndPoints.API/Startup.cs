using Framework.Domain.Error;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Contracts._Base;
using Store.EndPoints.API.Configuration;
using Store.EndPoints.API.Extension;
using Store.EndPoints.API.Filters;

namespace Store.EndPoints.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceConfig = services.AddServiceConfig(Configuration);

            services.AddHttpContextAccessor();
            services.Inject(Configuration);
            services.AddResponseCaching();
            services.AddSwagger(serviceConfig);
            services.AddHealthCheck(Configuration);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = serviceConfig.RedisConnectionString;
            });

            services.AddMvc(option =>
            {
                option.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
                option.Filters.Add(new ProducesResponseTypeAttribute(typeof(Error), 499));
                option.Filters.Add<ExceptionFilter>();
                option.EnableEndpointRouting = false;
                option.CacheProfiles.Add("Default", new CacheProfile
                {
                    Duration = serviceConfig.CacheDuration
                });
            }).AddControllersAsServices()
              .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ServiceConfig config)
        {
            // Look at this to middleware order:
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0#middleware-order

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseResponseCaching();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            /*
             * Other middleware
             */

            app.ConfigSwagger(config);

            app.UseHealthChecks(config.HealthCheckRoute, new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            Initialize(app);
        }

        private static void Initialize(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            scope.ServiceProvider.GetRequiredService<IUnitOfWork>().InitiateDatabase();
        }
    }
}