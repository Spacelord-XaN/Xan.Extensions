using Xan.Extensions.Collections;

namespace Xan.Extensions.Tests.Collections.IPaginatedListTests;

public class HasPreviousPage
{
    private readonly Fixture _fixture = new();

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(1)]
    public void ShouldReturnFalse(int pageIndex)
    {
        //  Arrange
        IPaginatedList sut = _fixture.Build<PaginatedListMock>()
            .With(_ => _.PageIndex, pageIndex)
            .Create();

        //  Act
        bool result = sut.HasPreviousPage;

        //  Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(223)]
    [InlineData(int.MaxValue)]
    public void ShouldReturnTrue(int pageIndex)
    {
        //  Arrange
        IPaginatedList sut = _fixture.Build<PaginatedListMock>()
            .With(_ => _.PageIndex, pageIndex)
            .Create();

        //  Act
        bool result = sut.HasPreviousPage;

        //  Assert
        result.Should().BeTrue();
    }
}
