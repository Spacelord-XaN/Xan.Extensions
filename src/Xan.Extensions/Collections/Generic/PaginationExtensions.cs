namespace Xan.Extensions.Collections.Generic;

public static class PaginationExtensions
{
    public static async Task<IPaginatedList<T>> AsPaginatedAsync<T>(this IEnumerable<T> enumerable, int pageSize, int pageIndex)
    {
        ArgumentNullException.ThrowIfNull(enumerable);

        return await enumerable.AsPaginatedAsync(pageSize, pageIndex, x => x);
    }

    public static async Task<IPaginatedList<TResult>> AsPaginatedAsync<TSource, TResult>(this IEnumerable<TSource> enumerable, int pageSize, int pageIndex, Func<TSource, TResult> selector)
    {
        ArgumentNullException.ThrowIfNull(enumerable);
        ArgumentNullException.ThrowIfNull(selector);

        return await enumerable.AsPaginatedAsync(pageSize, pageIndex, async source => await Task.FromResult(selector(source)));
    }

    public static async Task<IPaginatedList<TResult>> AsPaginatedAsync<TSource, TResult>(this IEnumerable<TSource> enumerable, int pageSize, int pageIndex, Func<TSource, Task<TResult>> selectorAsync)
    {
        ArgumentNullException.ThrowIfNull(enumerable);
        ArgumentNullException.ThrowIfNull(selectorAsync);

        if (pageIndex == 0)
        {
            pageIndex = 1;
        }

        int totalItemCount = enumerable.Count();
        int totalPageCount = IPaginated.CalcTotalPages(totalItemCount, pageSize);
        pageIndex = Math.Min(pageIndex, Math.Max(1, totalPageCount));

        IEnumerable<TSource> paginatedEnumerable = enumerable;
        if (pageSize != IPaginated.AllPageSize)
        {
            int skipCount = Math.Max(pageIndex - 1, 0) * pageSize;
            paginatedEnumerable = enumerable.Skip(skipCount).Take(pageSize);
        }
        IReadOnlyList<TSource> sourceItems = paginatedEnumerable.ToArray();
        List<TResult> resultItems = [];
        foreach (TSource sourceItem in sourceItems)
        {
            resultItems.Add(await selectorAsync(sourceItem));
        }
        return new PaginatedList<TResult>(resultItems, pageIndex, pageSize, totalPageCount, totalItemCount);
    }
}
