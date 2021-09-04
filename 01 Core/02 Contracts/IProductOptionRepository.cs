using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.DomainModels.ProductOptionAgg.Entities;

namespace Store.Contracts
{
    public interface IProductOptionRepository
    {
        Task AddAsync(ProductOption product);
        Task UpdateAsync(ProductOption product);
        Task DeleteAsync(ProductOption product);

        Task<ProductOption> GetAsync(Guid id);
        Task<ProductOption> GetIncludeProductAsync(Guid id);
        Task<IEnumerable<ProductOption>> GetProductOptionsAsync(Guid productId);
    }
}