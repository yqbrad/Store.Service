using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Dtoes;
using Store.DomainModels.ProductAgg.Exceptions;
using Store.DomainModels.ProductAgg.Requests;
using System.Threading.Tasks;

namespace Store.ApplicationServices.ProductAgg.Request
{
    public class GetProductHandlerAsync : RequestHandlerAsync<GetProduct, ProductDetails>
    {
        public GetProductHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task<ProductDetails> HandleAsync(GetProduct req)
        {
            var product = await UnitOfWork.Product.GetAsync(req.Id);
            if (product is null)
                throw new ProductNotFoundException();

            return product;
        }
    }
}