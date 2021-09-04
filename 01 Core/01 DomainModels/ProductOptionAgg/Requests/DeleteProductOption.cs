using Framework.Domain.Requests;
using System;

namespace Store.DomainModels.ProductOptionAgg.Requests
{
    public class DeleteProductOption : IRequest
    {
        public Guid ProductOptionId { get; private set; }
        public Guid ProductId { get; private set; }

        public DeleteProductOption(Guid productId, Guid productOptionId)
        {
            ProductId = productId;
            ProductOptionId = productOptionId;
        }
    }
}