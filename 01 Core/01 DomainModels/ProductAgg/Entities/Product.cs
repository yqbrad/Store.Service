using Framework.Domain.BaseModels;
using Store.DomainModels.ProductAgg.Events;
using Store.DomainModels.ProductAgg.ValueObjects;
using Store.DomainModels.ProductOptionAgg.Entities;
using System;
using System.Collections.Generic;

namespace Store.DomainModels.ProductAgg.Entities
{
    public class Product : BaseAggregateRoot<Guid>
    {
        public ProductName Name { get; private set; }
        public ProductDescription Description { get; private set; }
        public ProductPrice Price { get; private set; }
        public ProductDeliveryPrice DeliveryPrice { get; private set; }

        public virtual List<ProductOption> Options { get; private set; } = new();

        private Product() { }

        public Product(
            ProductName name,
            ProductDescription description,
            ProductPrice price,
            ProductDeliveryPrice deliveryPrice)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            DeliveryPrice = deliveryPrice;
            AddEvent(new ProductCreated(this));
        }

        public void Update(
            ProductName name,
            ProductDescription description,
            ProductPrice price,
            ProductDeliveryPrice deliveryPrice)
        {
            Name = name;
            Description = description;
            Price = price;
            DeliveryPrice = deliveryPrice;
            AddEvent(new ProductUpdated(this));
        }

        public void Delete()
        {
            AddEvent(new ProductDeleted(this));
        }

        public void AddOption(ProductOption option)
            => Options.Add(option);

        public void AddOption(IEnumerable<ProductOption> options)
            => Options.AddRange(options);

        public void RemoveOption(ProductOption option)
            => Options.Remove(option);
    }
}