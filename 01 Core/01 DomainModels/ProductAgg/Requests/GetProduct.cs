using Framework.Domain.Requests;
using System;

namespace Store.DomainModels.ProductAgg.Requests
{
    public class GetProduct : IRequest
    {
        public Guid Id { get; private set; }

        public GetProduct(Guid id)
        {
            Id = id;
        }
    }
}