using System.Linq;
using System.Threading.Tasks;
using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Dtoes;
using Store.DomainModels.ProductAgg.Exceptions;
using Store.DomainModels.ProductAgg.Requests;

namespace Store.ApplicationServices.ProductAgg.Request
{
    public class GetProductOptionHandlerAsync : RequestHandlerAsync<GetProductOption, ProductOptionDetails>
    {
        public GetProductOptionHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task<ProductOptionDetails> HandleAsync(GetProductOption req)
        {
            var product = await UnitOfWork.Product.GetIncludeOptionsAsync(req.ProductId);
            if (product is null)
                throw new ProductNotFoundException();

            var productOption = product.Options.SingleOrDefault(s => s.Id == req.ProductOptionId);
            if (productOption is null)
                throw new ProductOptionNotFoundException();

            return productOption;
        }
    }
}