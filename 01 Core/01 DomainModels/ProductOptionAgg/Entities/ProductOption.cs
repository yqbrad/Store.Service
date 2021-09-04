﻿using Framework.Domain.BaseModels;
using Store.DomainModels.ProductAgg.Entities;
using Store.DomainModels.ProductOptionAgg.Events;
using Store.DomainModels.ProductOptionAgg.ValueObjects;
using System;

namespace Store.DomainModels.ProductOptionAgg.Entities
{
    public class ProductOption : BaseAggregateRoot<Guid>
    {
        public ProductOptionName Name { get; private set; }
        public ProductOptionDescription Description { get; private set; }

        public Guid ProductId { get; private set; }
        public virtual Product Product { get; private set; }

        private ProductOption() { }

        public ProductOption(
            ProductOptionName name,
            ProductOptionDescription description,
            Product product)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            ProductId = product.Id;
            Product = product;

            AddEvent(new ProductOptionAdded(this));
        }

        public void Update(
            ProductOptionName name,
            ProductOptionDescription description)
        {
            Name = name;
            Description = description;

            AddEvent(new ProductOptionUpdated(this));
        }

        public void Delete()
        {
            AddEvent(new ProductOptionDeleted(this));
        }
    }
}