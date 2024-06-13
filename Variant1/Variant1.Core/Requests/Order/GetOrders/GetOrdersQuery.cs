using MediatR;
using Variant1.Core.Abstractions;
using Variant1.Cotracts.Requests.Order;
using Variant1.Cotracts.Requests.Order.GetOrders;

namespace Variant1.Core.Requests.Order.GetOrders;

public class GetOrdersQuery : GetOrdersRequest, IRequest<GetOrdersResponse>, IPaginationFilter
{
    public GetOrdersQuery(GetOrdersRequest request)
        : base(request)
    {
    }
}