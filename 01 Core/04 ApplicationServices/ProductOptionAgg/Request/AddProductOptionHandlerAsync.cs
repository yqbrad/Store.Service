using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Exceptions;
using Store.DomainModels.ProductOptionAgg.Entities;
using Store.DomainModels.ProductOptionAgg.Exceptions;
using Store.DomainModels.ProductOptionAgg.Requests;
using Store.DomainModels.ProductOptionAgg.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ApplicationServices.ProductOptionAgg.Request
{
    public class AddProductOptionHandlerAsync : RequestHandlerByInAsync<AddProductOption>
    {
        public AddProductOptionHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task HandleAsync(AddProductOption req)
        {
            var product = await UnitOfWork.Product.GetIncludeOptionsAsync(req.ProductId);
            if (product is null)
                throw new ProductNotFoundException();

            var isDuplicateOptionName = product.Options.Any(s => s.Name == req.Name.Trim());
            if (isDuplicateOptionName)
                throw new ProductOptionNameDuplicateException();

            var productOption = new ProductOption(
                new ProductOptionName(req.Name),
                new ProductOptionDescription(req.Description),
                product);

            product.AddOption(productOption);
            await UnitOfWork.ProductOption.AddAsync(productOption);
            await UnitOfWork.CommitAsync();
        }
    }
}