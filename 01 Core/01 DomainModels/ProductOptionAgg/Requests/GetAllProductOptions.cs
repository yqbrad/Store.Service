using Framework.Domain.Requests;
using System;

namespace Store.DomainModels.ProductOptionAgg.Requests
{
    public class GetAllProductOptions : IRequest
    {
        public Guid ProductId { get; private set; }

        public GetAllProductOptions(Guid productId)
        {
            ProductId = productId;
        }
    }
}