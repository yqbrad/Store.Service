using Framework.Domain.Requests;
using System;

namespace Store.DomainModels.ProductAgg.Requests
{
    public class UpdateProduct : IRequest
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }

        public void SetId(Guid id) => Id = id;
    }
}