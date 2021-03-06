using Framework.Domain.ApplicationServices;
using Framework.Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Store.Infrastructure.Service.Dispatcher
{
    public class InternalEventDispatcher : IInternalEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public InternalEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchEventAsync<T>(T @event)
            where T : IEvent
        {
            if (@event == null)
                throw new ArgumentNullException($"{nameof(@event)} Event can not be null.");

            var eventHandlers = _serviceProvider.GetServices<IEventHandler<T>>();
            foreach (var handler in eventHandlers)
                if (handler != null)
                {
                    try
                    {
                        await handler.HandleAsync(@event);
                    }
                    catch (Exception e)
                    {
                        //await _loggerService.LogAsync(e);
                    }
                }
        }

        public async Task DispatchEventAsync<T>(params T[] events)
            where T : IEvent
        {
            foreach (var @event in events)
            {
                if (@event == null)
                    throw new ArgumentNullException($"{nameof(@event)} Event can not be null.");

                var eventType = @event.GetType();
                var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
                var eventHandlers = _serviceProvider.GetServices(handlerType);
                foreach (var handler in eventHandlers)
                {
                    if (handler == null)
                        continue;

                    try
                    {
                        var method = handler.GetType().GetMethod(nameof(IEventHandler<T>.HandleAsync));
                        var task = (Task)method?.Invoke(handler, new object[] { @event });
                        if (task != null)
                            await task;
                    }
                    catch (Exception e)
                    {
                        //await _loggerService.LogAsync(e);
                    }
                }
            }
        }
    }
}