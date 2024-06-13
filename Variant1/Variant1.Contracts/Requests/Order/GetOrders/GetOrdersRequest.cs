using Variant1.Cotracts.Models;

namespace Variant1.Cotracts.Requests.Order.GetOrders;

public class GetOrdersRequest
{
    private int _pageNumber;
    private int _pageSize;

    public GetOrdersRequest()
    {
        _pageNumber = PaginationDefaults.PageNumber;
        _pageSize = PaginationDefaults.PageSize;
    }

    public GetOrdersRequest(GetOrdersRequest request)
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