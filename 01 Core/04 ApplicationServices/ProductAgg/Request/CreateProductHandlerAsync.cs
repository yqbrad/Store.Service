using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Entities;
using Store.DomainModels.ProductAgg.Exceptions;
using Store.DomainModels.ProductAgg.Requests;
using Store.DomainModels.ProductAgg.ValueObjects;
using System.Threading.Tasks;

namespace Store.ApplicationServices.ProductAgg.Request
{
    public class CreateProductHandlerAsync : RequestHandlerByInAsync<CreateProduct>
    {
        public CreateProductHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task HandleAsync(CreateProduct req)
        {
            var isDuplicateName = await UnitOfWork.Product.IsExist(req.Name?.Trim());
            if (isDuplicateName)
                throw new ProductNameDuplicateException();

            var product = new Product(new ProductName(req.Name),
                new ProductDescription(req.Description),
                new ProductPrice(req.Price),
                new ProductDeliveryPrice(req.DeliveryPrice));

            await UnitOfWork.Product.CreateAsync(product);
            await UnitOfWork.CommitAsync();
        }
    }
}