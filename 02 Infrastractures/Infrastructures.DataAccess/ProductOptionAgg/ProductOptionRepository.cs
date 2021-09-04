using Microsoft.EntityFrameworkCore;
using Store.Contracts;
using Store.DomainModels.ProductOptionAgg.Entities;
using Store.Infrastructure.DataAccess._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructure.DataAccess.ProductOptionAgg
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        private readonly StoreDbContext _dbContext;
        public ProductOptionRepository(StoreDbContext dbContext)
            => _dbContext = dbContext;

        public async Task AddAsync(ProductOption option)
            => await _dbContext.ProductOption.AddAsync(option);

        public void Update(ProductOption option)
            => _dbContext.ProductOption.Update(option);

        public void Delete(ProductOption option)
            => _dbContext.ProductOption.Remove(option);

        public Task<ProductOption> GetAsync(Guid id)
            => _dbContext.ProductOption.SingleOrDefaultAsync(s => s.Id == id);

        public Task<ProductOption> GetIncludeProductAsync(Guid id)
            => _dbContext.ProductOption
                .Include(s => s.Product)
                .SingleOrDefaultAsync(s => s.Id == id);

        public Task<List<ProductOption>> GetProductOptionsAsync(Guid productId)
            => _dbContext.ProductOption
                .Where(s => s.ProductId == productId)
                .ToListAsync();
    }
}