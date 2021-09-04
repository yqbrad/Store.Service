using System;
using System.Threading.Tasks;
using Framework.Domain.BaseModels;

namespace Framework.Domain.EventBus
{
    public interface IEventBus
    {
        Task PublishInternalAsync<TClass, TId>(TClass aggregateRoot)
            where TId : IEquatable<TId>
            where TClass : BaseAggregateRoot<TId>;

        Task PublishExternalAsync<TClass, TId>(TClass aggregateRoot)
            where TId : IEquatable<TId>
            where TClass : BaseAggregateRoot<TId>;
    }
}