using Xan.Extensions.Collections;

namespace Xan.Extensions.Tests.Collections.IPaginatedTests;

public class PaginatedMock
    : IPaginated
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalPageCount { get; set; }

    public int TotalItemCount { get; set; }
}
