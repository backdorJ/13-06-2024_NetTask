namespace Variant1.Core.Entities;

/// <summary>
/// Товар
/// </summary>
public class Product
{
    /// <summary>
    /// Ид сушности
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string ProductName { get; set; } = default!;

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Заказы
    /// </summary>
    public List<Order> Orders { get; set; } = new();
}