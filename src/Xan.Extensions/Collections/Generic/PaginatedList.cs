using System.Collections.ObjectModel;

namespace Xan.Extensions.Collections.Generic;

public class PaginatedList<T>
    : ReadOnlyCollection<T>
    , IPaginatedList<T>
    , IPaginatedList
{
    public PaginatedList(IPaginatedList<T> other)
        : this(other.ToList(), other.PageIndex, other.PageSize, other.TotalPageCount, other.TotalItemCount)
    { }

    public PaginatedList(IList<T> list, int pageIndex, int pageSize, int totalPageCount, int totalItemCount)
        : base(list)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalPageCount = totalPageCount;
        TotalItemCount = totalItemCount;
    }

    public int PageIndex { get; }

    public int PageSize { get; }

    public int TotalPageCount { get; }

    public int TotalItemCount { get; }
}
