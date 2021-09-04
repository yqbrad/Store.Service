using Framework.Domain.Dtoes;
using Store.DomainModels.ProductAgg.Entities;
using System;

namespace Store.DomainModels.ProductAgg.Dtoes
{
    public class ProductDetails : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }

        public ProductDetails() { }

        public ProductDetails(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            DeliveryPrice = product.DeliveryPrice;
        }

        public static implicit operator ProductDetails(Product product)
            => new(product);
    }
}