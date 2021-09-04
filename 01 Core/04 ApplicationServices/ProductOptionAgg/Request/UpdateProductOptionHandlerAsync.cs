using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Exceptions;
using Store.DomainModels.ProductOptionAgg.Exceptions;
using Store.DomainModels.ProductOptionAgg.Requests;
using Store.DomainModels.ProductOptionAgg.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ApplicationServices.ProductOptionAgg.Request
{
    public class UpdateProductOptionHandlerAsync : RequestHandlerByInAsync<UpdateProductOption>
    {
        public UpdateProductOptionHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task HandleAsync(UpdateProductOption req)
        {
            var product = await UnitOfWork.Product.GetIncludeOptionsAsync(req.ProductId);
            if (product is null)
                throw new ProductNotFoundException();

            var productOption = product.Options.SingleOrDefault(s => s.Id == req.ProductOptionId);
            if (productOption is null)
                throw new ProductOptionNotFoundException();

            productOption.Update(new ProductOptionName(req.Name),
                new ProductOptionDescription(req.Description));
            UnitOfWork.ProductOption.Update(productOption);
            await UnitOfWork.CommitAsync();
        }
    }
}