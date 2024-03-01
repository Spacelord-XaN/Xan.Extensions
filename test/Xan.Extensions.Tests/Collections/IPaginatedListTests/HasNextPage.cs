using Xan.Extensions.Collections;

namespace Xan.Extensions.Tests.Collections.IPaginatedListTests;

public class HasNextPage
{
    private readonly Fixture _fixture = new();

    [Theory]
    [InlineData(int.MinValue, int.MinValue)]
    [InlineData(0, 0)]
    [InlineData(10, 10)]
    [InlineData(11, 10)]
    [InlineData(int.MaxValue, int.MinValue)]
    [InlineData(int.MaxValue, int.MaxValue)]
    public void ShouldReturnFalse(int pageIndex, int totalPageCount)
    {
        //  Arrange
        IPaginatedList sut = _fixture.Build<PaginatedListMock>()
            .With(_ => _.PageIndex, pageIndex)
            .With(_ => _.TotalPageCount, totalPageCount)
            .Create();

        //  Act
        bool result = sut.HasNextPage;

        //  Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(int.MinValue, int.MaxValue)]
    [InlineData(0, 1)]
    [InlineData(1, 2)]
    [InlineData(123, 555)]
    [InlineData(123, int.MaxValue)]
    public void ShouldReturnTrue(int pageIndex, int totalPageCount)
    {
        //  Arrange
        IPaginatedList sut = _fixture.Build<PaginatedListMock>()
            .With(_ => _.PageIndex, pageIndex)
            .With(_ => _.TotalPageCount, totalPageCount)
            .Create();

        //  Act
        bool result = sut.HasNextPage;

        //  Assert
        result.Should().BeTrue();
    }
}
