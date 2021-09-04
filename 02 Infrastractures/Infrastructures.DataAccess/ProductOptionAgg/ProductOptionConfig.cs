using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DomainModels.ProductOptionAgg.Entities;

namespace Store.Infrastructure.DataAccess.ProductOptionAgg
{
    public class ProductOptionConfig : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedNever();

            builder.Property(s => s.Name)
                .HasConversion(s => s.Value, s => new(s))
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode();

            builder.Property(s => s.Description)
                .HasConversion(s => s.Value, s => new(s))
                .IsRequired()
                .IsUnicode();

            builder.HasIndex(s => s.Name)
                .IsUnique();
        }
    }
}