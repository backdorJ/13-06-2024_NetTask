using MediatR;
using Variant1.Cotracts.Requests.Product.PutProduct;

namespace Variant1.Core.Requests.Product.PutProduct;

/// <summary>
/// Обработчик на изменение товара
/// </summary>
public class PutProductCommand : PutProductRequest, IRequest
{
    /// <inheritdoc />
    public PutProductCommand(PutProductRequest request, Guid productId)
        : base(request)
        => ProductId = productId;

    /// <summary>
    /// Ид товара
    /// </summary>
    public Guid ProductId { get; set; }
}