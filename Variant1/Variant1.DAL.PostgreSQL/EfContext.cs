using Microsoft.EntityFrameworkCore;
using Variant1.Core.Abstractions;
using Variant1.Core.Entities;

namespace Variant1.DAL.PostgreSQL;

public class EfContext : DbContext, IDbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }

    /// <inheritdoc />
    public DbSet<Product> Products { get; set; }

    /// <inheritdoc />
    public DbSet<Order> Orders { get; set; }
}