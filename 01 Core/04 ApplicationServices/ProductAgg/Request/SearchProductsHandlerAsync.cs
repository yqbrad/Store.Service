using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Dtoes;
using Store.DomainModels.ProductAgg.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ApplicationServices.ProductAgg.Request
{
    public class SearchProductsHandlerAsync : RequestHandlerAsync<SearchProducts, List<ProductDetails>>
    {
        public SearchProductsHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task<List<ProductDetails>> HandleAsync(SearchProducts req)
        {
            var products = await UnitOfWork.Product.SearchAsync(req.Name);
            return products.Select(s => new ProductDetails(s)).ToList();
        }
    }
}