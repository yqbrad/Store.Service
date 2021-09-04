using Framework.Domain.Requests;

namespace Store.DomainModels.ProductAgg.Requests
{
    public class SearchProducts : IRequest
    {
        public string Name { get; set; }
    }
}