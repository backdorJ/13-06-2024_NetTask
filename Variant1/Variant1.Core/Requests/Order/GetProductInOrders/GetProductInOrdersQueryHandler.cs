using MediatR;
using Microsoft.EntityFrameworkCore;
using Variant1.Core.Abstractions;
using Variant1.Cotracts.Requests.Order.GetProductInOrders;

namespace Variant1.Core.Requests.Order.GetProductInOrders;

public class GetProductInOrdersQueryHandler : IRequestHandler<GetProductInOrdersQuery, List<GetProductInOrdersResponse>>
{
    private readonly IDbContext _dbContext;

    public GetProductInOrdersQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<GetProductInOrdersResponse>> Handle(GetProductInOrdersQuery request, CancellationToken cancellationToken)
    {
        var productsInOrder = await _dbContext.Orders
            .Where(x => x.OrderId == request.OrderId)
            .SelectMany(x => x.Products)
            .Select(x => new GetProductInOrdersResponse
            {
                ProductName = x.ProductName,
                Price = x.Price,
                Description = x.Description
            })
            .ToListAsync(cancellationToken);

        return productsInOrder;
    }
}