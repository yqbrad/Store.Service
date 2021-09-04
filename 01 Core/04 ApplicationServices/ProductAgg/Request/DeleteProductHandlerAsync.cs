using Framework.Domain.EventBus;
using Store.ApplicationServices._Base;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Exceptions;
using Store.DomainModels.ProductAgg.Requests;
using System.Threading.Tasks;

namespace Store.ApplicationServices.ProductAgg.Request
{
    public class DeleteProductHandlerAsync : RequestHandlerByInAsync<DeleteProduct>
    {
        public DeleteProductHandlerAsync(IUnitOfWork unitOfWork, IEventBus eventBus)
            : base(unitOfWork, eventBus) { }

        public override async Task HandleAsync(DeleteProduct req)
        {
            var product = await UnitOfWork.Product.GetAsync(req.Id);
            if (product is null)
                throw new ProductNotFoundException();

            product.Delete();
            UnitOfWork.Product.Delete(product);
            await UnitOfWork.CommitAsync();
        }
    }
}