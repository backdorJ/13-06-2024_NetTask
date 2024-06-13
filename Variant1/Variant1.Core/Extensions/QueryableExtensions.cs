using Variant1.Core.Abstractions;

namespace Variant1.Core.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> SkipTake<T>(this IQueryable<T> query, IPaginationFilter filter)
        => query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize);
}