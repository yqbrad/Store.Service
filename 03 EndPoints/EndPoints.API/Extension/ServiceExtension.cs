using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Store.EndPoints.API.Configuration;
using Store.EndPoints.API.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Store.EndPoints.API.Extension
{
    public static class ServiceExtension
    {
        public static void AddHealthCheck(this IServiceCollection services,
            IConfiguration configuration, ServiceConfig serviceConfig)
        {
            var uow = new UnitOfWorkConfig(configuration);
            services.AddHealthChecks()
                .AddSqlServer(uow.SqlServerConnectionString, tags: new List<string> { "StoreDB" })
                .AddRedis(serviceConfig.RedisConnectionString, tags: new List<string> { "CacheDB" });
        }

        public static void AddSwagger(this IServiceCollection services, ServiceConfig config)
        {
            if (!config.Swagger.IsEnable)
                return;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(config.Swagger.Version,
                    new OpenApiInfo
                    {
                        Title = config.Swagger.Title,
                        Version = config.Swagger.Version
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.OperationFilter<SwaggerAuthorizeOperationFilter>();
            });
        }

        public static ServiceConfig AddServiceConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            var serviceConfig = new ServiceConfig();
            configuration.GetSection(nameof(ServiceConfig)).Bind(serviceConfig);
            services.AddSingleton(serviceConfig);

            return serviceConfig;
        }

        public static void ConfigSwagger(this IApplicationBuilder app, ServiceConfig config)
        {
            if (!config.Swagger.IsEnable)
                return;

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(config.Swagger.Url, config.Swagger.Name);
                c.RoutePrefix = config.Swagger.RoutePrefix;
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelsExpandDepth(-1);
                c.DisplayRequestDuration();
                c.EnableDeepLinking();
                c.DefaultModelRendering(ModelRendering.Example);
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
            });
        }
    }
}