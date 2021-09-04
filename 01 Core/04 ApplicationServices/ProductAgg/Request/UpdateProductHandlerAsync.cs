using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Exceptions;
using Store.DomainModels.ProductAgg.Requests;
using Store.DomainModels.ProductAgg.ValueObjects;
using System.Threading.Tasks;

namespace Store.ApplicationServices.ProductAgg.Request
{
    public class UpdateProductHandlerAsync : RequestHandlerByInAsync<UpdateProduct>
    {
        public UpdateProductHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task HandleAsync(UpdateProduct req)
        {
            var product = await UnitOfWork.Product.GetAsync(req.Id);
            if (product is null)
                throw new ProductNotFoundException();

            product.Update(new ProductName(req.Name),
                new ProductDescription(req.Description),
                new ProductPrice(req.Price),
                new ProductDeliveryPrice(req.DeliveryPrice));

            UnitOfWork.Product.Update(product);
            await UnitOfWork.CommitAsync();
        }
    }
}