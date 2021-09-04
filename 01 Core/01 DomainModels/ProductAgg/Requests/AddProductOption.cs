using System;
using Framework.Domain.Requests;

namespace Store.DomainModels.ProductAgg.Requests
{
    public class AddProductOption : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid ProductId { get; private set; }
        public void SetProductId(Guid productId) => ProductId = productId;
    }
}