using Microsoft.EntityFrameworkCore;
using Variant1.Core.Entities;

namespace Variant1.Core.Abstractions;

public interface IDbContext
{
    /// <summary>
    /// Товары
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Заказы
    /// </summary>
    public DbSet<Order> Orders { get; set; }

    /// <summary>
    /// Сохранение данных
    /// </summary>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}