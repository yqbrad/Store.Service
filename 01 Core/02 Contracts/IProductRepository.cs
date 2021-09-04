using Store.DomainModels.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Contracts
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);

        Task<Product> GetAsync(Guid id);
        Task<Product> GetIncludeOptionsAsync(Guid id);
        Task<bool> IsExist(string name);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> SearchAsync(string name);
    }
}