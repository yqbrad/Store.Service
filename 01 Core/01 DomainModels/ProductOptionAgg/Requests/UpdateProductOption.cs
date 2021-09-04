using System;
using Framework.Domain.Requests;

namespace Store.DomainModels.ProductOptionAgg.Requests
{
    public class UpdateProductOption : IRequest
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void SetId(Guid id) => Id = id;
    }
}