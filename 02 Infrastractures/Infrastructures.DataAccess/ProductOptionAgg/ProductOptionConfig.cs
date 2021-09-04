using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DomainModels.ProductOptionAgg.Entities;

namespace Store.Infrastructure.DataAccess.ProductOptionAgg
{
    public class ProductOptionConfig : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {

        }
    }
}