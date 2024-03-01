using System.Collections;
using Xan.Extensions.Collections;

namespace Xan.Extensions.Tests.Collections.IPaginatedListTests;

public class PaginatedListMock
    : IPaginatedList
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalPageCount { get; set; }

    public int TotalItemCount { get; set; }

    public int Count { get; set; }

    public bool IsSynchronized { get; set; }

    public object SyncRoot { get; } = new object();

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
