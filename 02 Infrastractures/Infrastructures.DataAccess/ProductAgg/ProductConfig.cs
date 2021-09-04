using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DomainModels.ProductAgg.Entities;
using Store.DomainModels.ProductAgg.ValueObjects;

namespace Store.Infrastructure.DataAccess.ProductAgg
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedNever();

            builder.Property(s => s.Name)
                .HasConversion(s => s.Value, s => new ProductName(s))
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode();

            builder.Property(s => s.Description)
                .HasConversion(s => s.Value, s => new ProductDescription(s))
                .IsRequired()
                .IsUnicode();

            builder.Property(s => s.Price)
                .HasConversion(s => s.Value, s => new ProductPrice(s))
                .IsRequired();

            builder.Property(s => s.DeliveryPrice)
                .HasConversion(s => s.Value, s => new ProductDeliveryPrice(s))
                .IsRequired();

            builder.HasMany(s => s.Options)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(s => s.Name)
                .IsUnique();
        }
    }
}