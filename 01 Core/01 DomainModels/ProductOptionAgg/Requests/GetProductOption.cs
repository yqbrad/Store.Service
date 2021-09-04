using Framework.Domain.Requests;
using System;

namespace Store.DomainModels.ProductOptionAgg.Requests
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