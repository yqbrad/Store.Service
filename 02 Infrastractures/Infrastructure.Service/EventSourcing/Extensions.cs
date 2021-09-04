﻿using Framework.Domain.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Infrastructure.Service.EventSourcing
{
    public static class Extensions
    {
        public static void AddEventSourcing(this IServiceCollection services, IConfiguration configuration)
        {
            var option = new EventSourcingOptions();
            var section = configuration.GetSection("EventStore");
            section.Bind(option);
            services.Configure<EventSourcingOptions>(section);
            services.AddSingleton<IEventSource, EventSourceInitializer>();
        }
    }
}