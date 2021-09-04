using Microsoft.EntityFrameworkCore;
using Store.Contracts._Base;
using Store.DomainModels.ProductAgg.Entities;
using Store.DomainModels.ProductOptionAgg.Entities;

namespace Store.Infrastructure.DataAccess._Base
{
    public class StoreDbContext : BaseDbContext
    {
        #region DbSets
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductOption> ProductOption { get; set; }
        #endregion

        private readonly IUnitOfWorkConfiguration _configuration;

        public StoreDbContext(DbContextOptions<StoreDbContext> options,
            IUnitOfWorkConfiguration configuration) : base(options)
            => _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.SqlServerConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            //CreateSequence(modelBuilder, nameof(App));
        }

        private void CreateSequence(ModelBuilder modelBuilder, string name)
            => modelBuilder
                .HasSequence<int>(name + "_Sequence", "dbo")
                .StartsAt(1)
                .HasMin(1)
                .IncrementsBy(1);
    }
}