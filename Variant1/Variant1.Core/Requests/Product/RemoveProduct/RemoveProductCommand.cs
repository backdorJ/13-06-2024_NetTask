using MediatR;

namespace Variant1.Core.Requests.Product.RemoveProduct;

public class RemoveProductCommand : IRequest
{
    public RemoveProductCommand(Guid productId)
    {
        ProductId = productId;
    }

    /// <summary>
    /// ИД товара
    /// </summary>
    public Guid ProductId { get; set; }
}