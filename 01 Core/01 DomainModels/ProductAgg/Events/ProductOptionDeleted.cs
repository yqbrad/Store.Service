using System;
using Framework.Domain.Events;
using Store.DomainModels.ProductAgg.Entities;

namespace Store.DomainModels.ProductAgg.Events
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