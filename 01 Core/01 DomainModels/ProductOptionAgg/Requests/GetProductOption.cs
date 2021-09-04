using System;
using Framework.Domain.Requests;

namespace Store.DomainModels.ProductOptionAgg.Requests
{
    public class GetProductOption : IRequest
    {
        public Guid Id { get; private set; }

        public GetProductOption(Guid id)
        {
            Id = id;
        }
    }
}