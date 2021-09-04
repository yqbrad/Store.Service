using Framework.Domain.Requests;
using System;

namespace Store.DomainModels.ProductOptionAgg.Requests
{
    public class UpdateProductOption : IRequest
    {
        public Guid ProductId { get; private set; }
        public Guid ProductOptionId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void SetProductId(Guid productId) => ProductId = productId;
        public void SetOptionId(Guid optionId) => ProductOptionId = optionId;
    }
}