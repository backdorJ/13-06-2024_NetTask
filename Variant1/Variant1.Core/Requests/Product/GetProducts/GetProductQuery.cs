using MediatR;
using Variant1.Core.Abstractions;
using Variant1.Cotracts.Requests.Product.GetProducts;

namespace Variant1.Core.Requests.Product.GetProducts;

public class GetProductQuery : GetProductsRequest, IRequest<GetProductsResponse>, IPaginationFilter
{
    public GetProductQuery(GetProductsRequest request)
        : base(request)
    {
    }
}