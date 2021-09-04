using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.DomainModels.ProductOptionAgg.Entities;

namespace Store.Contracts
{
    public interface IProductOptionRepository
    {
        Task AddAsync(ProductOption option);
        void Update(ProductOption option);
        void Delete(ProductOption option);

        Task<ProductOption> GetAsync(Guid id);
        Task<ProductOption> GetIncludeProductAsync(Guid id);
        Task<List<ProductOption>> GetProductOptionsAsync(Guid productId);
    }
}