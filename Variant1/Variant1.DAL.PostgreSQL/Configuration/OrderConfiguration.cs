using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Variant1.Core.Entities;

namespace Variant1.DAL.PostgreSQL.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.OrderId);

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.UpdateAt);

        builder.Property(p => p.OrderNumber)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasMany(x => x.Products)
            .WithMany(y => y.Orders);
    }
}