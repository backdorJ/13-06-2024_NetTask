using MediatR;
using Microsoft.AspNetCore.Mvc;
using Variant1.Core.Requests.Product.AddToOrder;
using Variant1.Core.Requests.Product.GetProducts;
using Variant1.Core.Requests.Product.PostProduct;
using Variant1.Core.Requests.Product.PutProduct;
using Variant1.Core.Requests.Product.RemoveProduct;
using Variant1.Cotracts.Requests.Product.GetProducts;
using Variant1.Cotracts.Requests.Product.PostProduct;
using Variant1.Cotracts.Requests.Product.PutProduct;

namespace Variant1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(201)]
    [ProducesResponseType(500)]
    public async Task<Guid> AddProductAsync(
        [FromServices] IMediator mediator,
        [FromBody] PostProductRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new PostProductCommand(request), cancellationToken);
    
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(201)]
    [ProducesResponseType(500)]
    public async Task<GetProductsResponse> GetProductsAsync(
        [FromServices] IMediator mediator,
        [FromQuery] GetProductsRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetProductQuery(request), cancellationToken);
    
    [HttpPut("{productId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task PutProductAsync(
        [FromServices] IMediator mediator,
        [FromBody] PutProductRequest request,
        [FromRoute] Guid productId,
        CancellationToken cancellationToken)
        => await mediator.Send(new PutProductCommand(request, productId), cancellationToken);
    
    [HttpDelete("{productId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task PutProductAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid productId,
        CancellationToken cancellationToken)
        => await mediator.Send(new RemoveProductCommand(productId), cancellationToken);
    
    [HttpPost("order")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task AddToOrder(
        [FromServices] IMediator mediator,
        [FromBody] List<Guid> productIds,
        CancellationToken cancellationToken)
        => await mediator.Send(new AddToOrderCommand(productIds), cancellationToken);
}