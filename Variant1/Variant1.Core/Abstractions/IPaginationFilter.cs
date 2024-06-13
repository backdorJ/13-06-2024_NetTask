namespace Variant1.Core.Abstractions;

public interface IPaginationFilter
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}