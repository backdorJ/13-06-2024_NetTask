namespace Variant1.Cotracts.Requests.Order.GetOrders;

public class GetOrdersResponse
{
    public GetOrdersResponse(List<GetOrdersResponseItem> entities, int totalCount)
    {
        Entities = entities;
        TotalCount = totalCount;
    }

    public List<GetOrdersResponseItem> Entities { get; set; }

    public int TotalCount { get; set; }
}