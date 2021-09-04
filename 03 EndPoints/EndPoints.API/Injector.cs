﻿using Framework.Domain.EventBus;
using Framework.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Contracts._Base;
using Store.EndPoints.API.Configuration;
using Store.Infrastructure.DataAccess._Base;
using Store.Infrastructure.Service;
using Store.Infrastructure.Service.Dispatcher;
using Store.Infrastructure.Service.EventSourcing;

namespace Store.EndPoints.API
{
    public static class Injector
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUnitOfWorkConfiguration, UnitOfWorkConfig>();
            services.AddDbContext<StoreDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork<StoreDbContext>>();
            services.AddEventSourcing(configuration);

            services.AddSingleton<IInternalEventDispatcher, InternalEventDispatcher>();
            services.AddScoped<IEventBus, EventBus>();

        }
    }
}