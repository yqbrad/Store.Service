using Framework.Domain.EventBus;
using Framework.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.ApplicationServices.ProductAgg.Request;
using Store.ApplicationServices.ProductOptionAgg.Request;
using Store.Contracts;
using Store.Contracts._Base;
using Store.EndPoints.API.Configuration;
using Store.Infrastructure.DataAccess._Base;
using Store.Infrastructure.DataAccess.ProductAgg;
using Store.Infrastructure.DataAccess.ProductOptionAgg;
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

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductOptionRepository, ProductOptionRepository>();

            services.AddScoped<CreateProductHandlerAsync>();
            services.AddScoped<DeleteProductHandlerAsync>();
            services.AddScoped<GetProductHandlerAsync>();
            services.AddScoped<SearchProductsHandlerAsync>();
            services.AddScoped<UpdateProductHandlerAsync>();
            services.AddScoped<GetAllProductHandlerAsync>();

            services.AddScoped<AddProductOptionHandlerAsync>();
            services.AddScoped<DeleteProductOptionHandlerAsync>();
            services.AddScoped<GetAllProductOptionsHandlerAsync>();
            services.AddScoped<GetProductOptionHandlerAsync>();
            services.AddScoped<UpdateProductOptionHandlerAsync>();
        }
    }
}