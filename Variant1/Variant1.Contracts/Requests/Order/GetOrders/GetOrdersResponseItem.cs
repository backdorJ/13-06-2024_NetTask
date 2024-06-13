namespace Variant1.Cotracts.Requests.Order.GetOrders;

public class GetOrdersResponseItem
{
    public string? OrderNumber { get; set; }
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
}