using System;
using Framework.Domain.Events;
using Store.DomainModels.ProductAgg.Entities;

namespace Store.DomainModels.ProductAgg.Events
{
    public class ProductDeleted : IEvent
    {
        public Guid Id { get; private set; }

        public ProductDeleted(Product product)
        {
            Id = product.Id;
        }
    }
}