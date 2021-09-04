using Framework.Domain.BaseModels;
using Framework.Domain.Data;
using Framework.Domain.EventBus;
using Framework.Domain.Events;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructure.Service
{
    public class EventBus : IEventBus
    {
        public IApplicant Applicant { get; }

        private readonly IEventSource _eventSource;
        private readonly IInternalEventDispatcher _internalEventDispatcher;

        public EventBus(IInternalEventDispatcher internalEventDispatcher,
            IEventSource eventSource, IApplicant applicant)
        {
            Applicant = applicant;

            _internalEventDispatcher = internalEventDispatcher;
            _eventSource = eventSource;
        }

        public async Task PublishInternalAsync<TClass, TId>(TClass aggregateRoot)
            where TClass : BaseAggregateRoot<TId>
            where TId : IEquatable<TId>
        {
            await _internalEventDispatcher.DispatchEventAsync(aggregateRoot.GetEvents().ToArray());
            await Log<TClass, TId>(aggregateRoot);
        }

        public async Task PublishExternalAsync<TClass, TId>(TClass aggregateRoot)
            where TClass : BaseAggregateRoot<TId>
            where TId : IEquatable<TId>
        {
            //await _rabbitBusClient.PublishAsync(aggregateRoot.GetEvents());
            await Log<TClass, TId>(aggregateRoot);
        }

        private async Task Log<TClass, TId>(TClass aggregateRoot)
            where TClass : BaseAggregateRoot<TId>
            where TId : IEquatable<TId>
        {
            try
            {
                await _eventSource.SaveAsync(aggregateRoot.GetType().FullName,
                    aggregateRoot.Id.ToString(), aggregateRoot.GetEvents());
            }
            catch (Exception)
            {
                //TODO Log EventSource Not Work
            }
        }
    }
}