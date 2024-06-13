namespace Variant1.Core.Entities;

/// <summary>
/// Сущность заказа
/// </summary>
public class Order
{
    /// <summary>
    /// Ид заказа
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Номер заказа
    /// </summary>
    public string OrderNumber { get; set; } = default!;

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTime? UpdateAt { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public List<Product> Products { get; set; } = new();
}