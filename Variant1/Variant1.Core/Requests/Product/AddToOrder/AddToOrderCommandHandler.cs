using MediatR;
using Microsoft.EntityFrameworkCore;
using Variant1.Core.Abstractions;
using Variant1.Core.Entities;
using Variant1.Core.Services.DateTimeProvider;

namespace Variant1.Core.Requests.Product.AddToOrder;

public class AddToOrderCommandHandler : IRequestHandler<AddToOrderCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddToOrderCommandHandler(IDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
    }

    /// <inheritdoc />
    public async Task Handle(AddToOrderCommand request, CancellationToken cancellationToken)
    {
        var productsFromDb = await _dbContext.Products
            .Where(x => request.ProductIds.Any(y => y == x.Id))
            .ToListAsync(cancellationToken);

        if (!productsFromDb.Any())
            throw new ApplicationException("Не было найдено товаров");

        var order = new Entities.Order
        {
            OrderNumber = $"#{Random.Shared.Next(1, 100)}",
            CreatedAt = _dateTimeProvider.CurrentDate,
            UpdateAt = null,
            Products = new List<Entities.Product>(productsFromDb)
        };

        await _dbContext.Orders.AddAsync(order, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}