using MediatR;
using Microsoft.EntityFrameworkCore;
using Variant1.Core.Abstractions;

namespace Variant1.Core.Requests.Product.RemoveProduct;

/// <summary>
/// Обработчик для <see cref="RemoveProductCommand"/>
/// </summary>
public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
{
    private readonly IDbContext _dbContext;

    public RemoveProductCommandHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var productToDelete = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
            ?? throw new ApplicationException($"Не найден товар с таким идетификатором: {request.ProductId}");

        _dbContext.Products.Remove(productToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}