using Microsoft.EntityFrameworkCore;
using Store.Contracts;
using Store.DomainModels.ProductAgg.Entities;
using Store.Infrastructure.DataAccess._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Infrastructure.DataAccess.ProductAgg
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;
        public ProductRepository(StoreDbContext dbContext)
            => _dbContext = dbContext;

        public async Task CreateAsync(Product product)
            => await _dbContext.Product.AddAsync(product);

        public void Update(Product product)
            => _dbContext.Product.Update(product);

        public void Delete(Product product)
            => _dbContext.Product.Remove(product);

        public Task<Product> GetAsync(Guid id)
            => _dbContext.Product.SingleOrDefaultAsync(s => s.Id == id);

        public Task<Product> GetIncludeOptionsAsync(Guid id)
            => _dbContext.Product.Include(s => s.Options)
                .SingleOrDefaultAsync(s => s.Id == id);

        public Task<bool> IsExist(string name)
            => _dbContext.Product.AnyAsync(s => s.Name == name);

        public Task<List<Product>> GetAllAsync()
            => _dbContext.Product.ToListAsync();

        public Task<List<Product>> SearchAsync(string name)
        {
            Expression<Func<Product, bool>> searchCondition = x
                => ((string)x.Name).Contains(name);

            return _dbContext.Product.Where(searchCondition).ToListAsync();
        }
    }
}