using MediatR;
using Microsoft.EntityFrameworkCore;
using Variant1.Core.Abstractions;

namespace Variant1.Core.Requests.Order.RemoveOrder;

public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
{
    private readonly IDbContext _dbContext;

    public RemoveOrderCommandHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        var orderFromDb = await _dbContext.Orders
            .FirstOrDefaultAsync(x => x.OrderId == request.OrderId, cancellationToken)
            ?? throw new ApplicationException($"Заказ не найден {request.OrderId}");

        _dbContext.Orders.Remove(orderFromDb);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}