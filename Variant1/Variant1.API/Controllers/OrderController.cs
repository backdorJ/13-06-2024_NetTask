using MediatR;
using Microsoft.AspNetCore.Mvc;
using Variant1.Core.Requests.Order.GetOrders;
using Variant1.Core.Requests.Order.GetProductInOrders;
using Variant1.Core.Requests.Order.RemoveOrder;
using Variant1.Cotracts.Requests.Order.GetOrders;
using Variant1.Cotracts.Requests.Order.GetProductInOrders;

namespace Variant1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public async Task<GetOrdersResponse> GetOrders(
        [FromServices] IMediator mediator,
        [FromQuery] GetOrdersRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetOrdersQuery(request), cancellationToken);
    
    [HttpGet("{orderId}")]
    public async Task<List<GetProductInOrdersResponse>> GetProductsIdOrder(
        [FromServices] IMediator mediator,
        [FromRoute] Guid orderId,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetProductInOrdersQuery(orderId), cancellationToken);

    [HttpDelete("{orderId}")]
    public async Task RemoveOrder(
        [FromServices] IMediator mediator,
        [FromRoute] Guid orderId,
        CancellationToken cancellationToken)
        => await mediator.Send(new RemoveOrderCommand(orderId), cancellationToken);
}