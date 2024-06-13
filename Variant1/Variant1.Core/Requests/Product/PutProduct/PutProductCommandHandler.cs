using MediatR;
using Microsoft.EntityFrameworkCore;
using Variant1.Core.Abstractions;

namespace Variant1.Core.Requests.Product.PutProduct;

/// <summary>
/// Обработчик для <see cref="PutProductCommand"/>
/// </summary>
public class PutProductCommandHandler : IRequestHandler<PutProductCommand>
{
    private readonly IDbContext _dbContext;

    public PutProductCommandHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task Handle(PutProductCommand request, CancellationToken cancellationToken)
    {
        var productFromDb = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
            ?? throw new ApplicationException($"Не найден товар с ИД: {request.ProductId}");

        if (!string.IsNullOrWhiteSpace(request.ProductName))
            productFromDb.ProductName = request.ProductName;

        if (!string.IsNullOrWhiteSpace(request.Description))
            productFromDb.Description = request.Description;

        if (request.Price != null)
            productFromDb.Price = request.Price.Value;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}