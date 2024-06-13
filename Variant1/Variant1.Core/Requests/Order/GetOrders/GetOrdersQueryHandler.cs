using MediatR;
using Microsoft.EntityFrameworkCore;
using Variant1.Core.Abstractions;
using Variant1.Core.Extensions;
using Variant1.Cotracts.Requests.Order;
using Variant1.Cotracts.Requests.Order.GetOrders;

namespace Variant1.Core.Requests.Order.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, GetOrdersResponse>
{
    private readonly IDbContext _dbContext;

    public GetOrdersQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<GetOrdersResponse> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.Orders.CountAsync(cancellationToken);

        var products = await _dbContext.Orders
            .Select(x => new GetOrdersResponseItem
            {
                OrderNumber = x.OrderNumber,
                CreateAt = x.CreatedAt,
                UpdateAt = x.UpdateAt
            })
            .OrderBy(x => x.CreateAt)
            .SkipTake(request)
            .ToListAsync(cancellationToken);

        return new GetOrdersResponse(products, totalCount);
    }
}