using System;
using Framework.Domain.Events;
using Store.DomainModels.ProductAgg.Entities;

namespace Store.DomainModels.ProductAgg.Events
{
    public class ProductOptionAdded : IEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ProductOptionAdded(ProductOption option)
        {
            Id = option.Id;
            Name = option.Name;
            Description = option.Description;
        }
    }
}
