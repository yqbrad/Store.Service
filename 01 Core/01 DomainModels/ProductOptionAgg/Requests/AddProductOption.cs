using Framework.Domain.Requests;

namespace Store.DomainModels.ProductOptionAgg.Requests
{
    public class AddProductOption : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}