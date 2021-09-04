using Framework.Domain.Requests;
using System;

namespace Store.DomainModels.ProductAgg.Requests
{
    public class CreateProduct : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}