using Framework.Domain.Events;
using Store.DomainModels.ProductAgg.Entities;
using System;

namespace Store.DomainModels.ProductAgg.Events
{
    public class ProductCreated : IEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal DeliveryPrice { get; private set; }

        public ProductCreated(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            DeliveryPrice = product.DeliveryPrice;
        }
    }
}
