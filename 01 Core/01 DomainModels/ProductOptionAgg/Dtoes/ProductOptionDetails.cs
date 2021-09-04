using Framework.Domain.Dtoes;
using Store.DomainModels.ProductOptionAgg.Entities;
using System;

namespace Store.DomainModels.ProductOptionAgg.Dtoes
{
    public class ProductOptionDetails : IDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ProductOptionDetails(ProductOption product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
        }

        public static implicit operator ProductOptionDetails(ProductOption product)
            => new(product);
    }
}