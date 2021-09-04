using Framework.Domain.EventBus;
using Store.Contracts._Base;

namespace Store.ApplicationServices._Base
{
    public abstract class BaseApplicationService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IEventBus EventBus;

        protected BaseApplicationService(IUnitOfWork unitOfWork, IEventBus eventBus)
        {
            UnitOfWork = unitOfWork;
            EventBus = eventBus;
        }
    }
}