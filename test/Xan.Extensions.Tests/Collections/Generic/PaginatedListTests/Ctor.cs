using Xan.Extensions.Collections.Generic;

namespace Xan.Extensions.Tests.Collections.PaginatedListTests;

public class Ctor
{
    [Theory]
    [AutoData]
    public void IList_ShouldInitCorrectly(List<int> items, int pageIndex, int pageSize, int totalPageCount, int totalItemCount)
    {
        //  Act
        PaginatedList<int> paginatedList = new (items, pageIndex, pageSize, totalPageCount, totalItemCount);

        //  Assert
        using (new AssertionScope())
        {
            paginatedList.Should().BeEquivalentTo(items);
            paginatedList.PageIndex.Should().Be(pageIndex);
            paginatedList.PageSize.Should().Be(pageSize);
            paginatedList.TotalPageCount.Should().Be(totalPageCount);
            paginatedList.TotalItemCount.Should().Be(totalItemCount);
        }
    }

    [Theory]
    [AutoData]
    public void PaginatedList_ShouldInitCorrectly(List<int> items, int pageIndex, int pageSize, int totalPageCount, int totalItemCount)
    {
        //  Arrange
        PaginatedList<int> other= new(items, pageIndex, pageSize, totalPageCount, totalItemCount);

        //  Act
        PaginatedList<int> paginatedList = new(other);

        //  Assert
        using (new AssertionScope())
        {
            paginatedList.Should().BeEquivalentTo(items);
            paginatedList.PageIndex.Should().Be(pageIndex);
            paginatedList.PageSize.Should().Be(pageSize);
            paginatedList.TotalPageCount.Should().Be(totalPageCount);
            paginatedList.TotalItemCount.Should().Be(totalItemCount);
        }
    }
}
