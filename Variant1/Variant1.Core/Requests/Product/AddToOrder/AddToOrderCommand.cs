using MediatR;

namespace Variant1.Core.Requests.Product.AddToOrder;

/// <summary>
/// Добавить товары в заказ
/// </summary>
public class AddToOrderCommand : IRequest
{
    public AddToOrderCommand(List<Guid> productIds)
        => ProductIds = productIds;

    public List<Guid> ProductIds { get; set; }
}