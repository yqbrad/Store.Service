using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Dtoes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ApplicationServices.ProductAgg.Request
{
    public class GetAllProductHandlerAsync : RequestHandlerByOutAsync<List<ProductDetails>>
    {
        public GetAllProductHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task<List<ProductDetails>> HandleAsync()
        {
            var products = await UnitOfWork.Product.GetAllAsync();
            return products.Select(s => new ProductDetails(s)).ToList();
        }
    }
}
