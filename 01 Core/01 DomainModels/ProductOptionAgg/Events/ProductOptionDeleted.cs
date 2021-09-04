using Framework.Domain.Events;
using Store.DomainModels.ProductOptionAgg.Entities;
using System;

namespace Store.DomainModels.ProductOptionAgg.Events
{
    public class ProductOptionDeleted : IEvent
    {
        public Guid Id { get; private set; }

        public ProductOptionDeleted(ProductOption option)
        {
            Id = option.Id;
        }
    }
}