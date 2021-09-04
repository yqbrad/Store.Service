using System;
using Framework.Domain.Requests;

namespace Store.DomainModels.ProductOptionAgg.Requests
{
    public class DeleteProductOption : IRequest
    {
        public Guid Id { get; private set; }

        public DeleteProductOption(Guid id)
        {
            Id = id;
        }
    }
}