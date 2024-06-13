using MediatR;
using Microsoft.EntityFrameworkCore;
using Variant1.Core.Abstractions;
using Variant1.Core.Extensions;
using Variant1.Cotracts.Requests.Product.GetProducts;

namespace Variant1.Core.Requests.Product.GetProducts;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductsResponse>
{
    private readonly IDbContext _dbContext;

    public GetProductQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<GetProductsResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.Products.CountAsync(cancellationToken);

        var products = await _dbContext.Products
            .Select(x => new GetProductsResponseItem
            {
                ProductName = x.ProductName,
                Price = x.Price,
                Description = x.Description
            })
            .OrderBy(x => x.ProductName)
            .SkipTake(request)
            .ToListAsync(cancellationToken);

        return new GetProductsResponse(totalCount, products);
    }
}