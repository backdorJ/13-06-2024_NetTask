using MediatR;

namespace Variant1.Core.Requests.Order.RemoveOrder;

public class RemoveOrderCommand : IRequest
{
    public RemoveOrderCommand(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; set; }
}