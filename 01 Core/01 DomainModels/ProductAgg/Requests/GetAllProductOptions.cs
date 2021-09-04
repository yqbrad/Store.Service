using System;
using Framework.Domain.Requests;

namespace Store.DomainModels.ProductAgg.Requests
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