using Framework.Domain.Requests;
using System;

namespace Store.DomainModels.ProductOptionAgg.Requests
{
    public class AddProductOption : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid ProductId { get; private set; }
        public void SetProductId(Guid productId) => ProductId = productId;
    }
}