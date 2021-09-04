using Framework.Domain.Requests;

namespace Store.DomainModels.ProductAgg.Requests
{
    public class SearchProducts : IRequest
    {
        public string Name { get; private set; }

        public SearchProducts(string name)
        {
            Name = name;
        }
    }
}