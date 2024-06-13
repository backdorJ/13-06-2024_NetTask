namespace Variant1.Cotracts.Requests.Product.PutProduct;

public class PutProductRequest
{
    public PutProductRequest()
    {
    }
    
    public PutProductRequest(PutProductRequest request)
    {
        ProductName = request.ProductName;
        Price = request.Price;
        Description = request.Description;
    }
    
    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }
}