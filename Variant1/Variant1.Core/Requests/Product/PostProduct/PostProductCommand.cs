using MediatR;
using Variant1.Cotracts.Requests.Product.PostProduct;

namespace Variant1.Core.Requests.Product.PostProduct;

/// <summary>
/// Команда на создание товара
/// </summary>
public class PostProductCommand : PostProductRequest, IRequest<Guid>
{
    public PostProductCommand(PostProductRequest request)
        : base(request)
    {
    }
}