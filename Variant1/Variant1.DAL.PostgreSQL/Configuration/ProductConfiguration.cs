using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Variant1.Core.Entities;

namespace Variant1.DAL.PostgreSQL.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.ProductName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.Description);

        builder.HasMany(x => x.Orders)
            .WithMany(y => y.Products);
    }
}