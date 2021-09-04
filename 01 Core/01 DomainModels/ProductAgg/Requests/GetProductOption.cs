using System;
using Framework.Domain.Requests;

namespace Store.DomainModels.ProductAgg.Requests
{
    public class GetProductOption : IRequest
    {
        public Guid ProductId { get; private set; }
        public Guid ProductOptionId { get; private set; }

        public GetProductOption(Guid productId, Guid productOptionId)
        {
            ProductId = productId;
            ProductOptionId = productOptionId;
        }
    }
}