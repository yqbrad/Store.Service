using Store.DomainModels.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Contracts
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        void Update(Product product);
        void Delete(Product product);

        Task<Product> GetAsync(Guid id);
        Task<Product> GetIncludeOptionsAsync(Guid id);
        Task<bool> IsExist(string name);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> SearchAsync(string name);
    }
}