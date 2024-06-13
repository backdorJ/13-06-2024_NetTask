using MediatR;
using Variant1.Cotracts.Requests.Order.GetProductInOrders;

namespace Variant1.Core.Requests.Order.GetProductInOrders;

public class GetProductInOrdersQuery : IRequest<List<GetProductInOrdersResponse>>
{
    public GetProductInOrdersQuery(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; set; }
}