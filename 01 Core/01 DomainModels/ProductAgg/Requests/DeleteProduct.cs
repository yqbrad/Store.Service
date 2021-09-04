using System;
using Framework.Domain.Requests;

namespace Store.DomainModels.ProductAgg.Requests
{
    public class DeleteProduct : IRequest
    {
        public Guid Id { get; private set; }

        public DeleteProduct(Guid id)
        {
            Id = id;
        }
    }
}