using Xan.Extensions.Collections;

namespace Xan.Extensions.Tests.Collections.IPaginatedTests;

public class CalcTotalPages
{
    [Theory]
    [InlineAutoData(0)]
    [InlineData(55, 42)]
    public void ReturnsOne(int pageSize, int totalItemCount)
    {
        // Arrange

        // Act
        int totalPages = IPaginated.CalcTotalPages(totalItemCount, pageSize);

        // Assert
        totalPages.Should().Be(1);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(4, 16, 4)]
    [InlineData(3, 17, 6)]
    public void ReturnsCorrectPageCount(int pageSize, int totalItemCount, int expectedResult)
    {
        // Arrange

        // Act
        int totalPages = IPaginated.CalcTotalPages(totalItemCount, pageSize);

        // Assert
        totalPages.Should().Be(expectedResult);
    }
}
