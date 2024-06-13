namespace Variant1.Cotracts.Requests.Product.PostProduct;

public class PostProductRequest
{
    public PostProductRequest()
    {
    }

    public PostProductRequest(PostProductRequest request)
    {
        ProductName = request.ProductName;
        Price = request.Price;
        Description = request.Description;
    }
    
    public string ProductName { get; set; } = default!;

    public decimal Price { get; set; }

    public string? Description { get; set; }
}