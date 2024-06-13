using Variant1.Cotracts.Models;

namespace Variant1.Cotracts.Requests.Product.GetProducts;

public class GetProductsRequest
{
    private int _pageNumber;
    private int _pageSize;

    public GetProductsRequest()
    {
        _pageNumber = PaginationDefaults.PageNumber;
        _pageSize = PaginationDefaults.PageSize;
    }

    public GetProductsRequest(GetProductsRequest request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
    }

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value > 0 ? value : PaginationDefaults.PageNumber;
    }
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > 0 ? value : PaginationDefaults.PageSize;
    }
}