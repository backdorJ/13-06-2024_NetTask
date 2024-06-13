namespace Variant1.Cotracts.Requests.Product.GetProducts;

public class GetProductsResponse
{
    public GetProductsResponse(int totalCount, List<GetProductsResponseItem> entities)
    {
        TotalCount = totalCount;
        Entities = entities;
    }

    public int TotalCount { get; set; }
    public List<GetProductsResponseItem> Entities { get; set; }
}