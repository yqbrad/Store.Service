using System.Collections.Generic;
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
    public class GetAllProductOptionsHandlerAsync : RequestHandlerAsync<GetAllProductOptions, List<ProductOptionDetails>>
    {
        public GetAllProductOptionsHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task<List<ProductOptionDetails>> HandleAsync(GetAllProductOptions req)
        {
            var product = await UnitOfWork.Product.GetIncludeOptionsAsync(req.ProductId);
            if (product is null)
                throw new ProductNotFoundException();

            return product.Options.Select(s => new ProductOptionDetails(s)).ToList();
        }
    }
}