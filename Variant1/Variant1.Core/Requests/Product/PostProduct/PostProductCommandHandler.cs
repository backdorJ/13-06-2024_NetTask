using MediatR;
using Variant1.Core.Abstractions;

namespace Variant1.Core.Requests.Product.PostProduct;

/// <summary>
/// Обработчик для <see cref="PostProductCommand"/>
/// </summary>
public class PostProductCommandHandler : IRequestHandler<PostProductCommand, Guid>
{
    private readonly IDbContext _dbContext;

    public PostProductCommandHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(PostProductCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.ProductName))
            throw new ApplicationException($"Необходимо заполнить обязательное поле {request.ProductName}");

        if (request.Price < 0)
            throw new ApplicationException("Цена на товар должна быть больше 0");

        var product = new Entities.Product
        {
            ProductName = request.ProductName,
            Price = request.Price,
            Description = request.Description
        };

        await _dbContext.Products.AddAsync(product, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}