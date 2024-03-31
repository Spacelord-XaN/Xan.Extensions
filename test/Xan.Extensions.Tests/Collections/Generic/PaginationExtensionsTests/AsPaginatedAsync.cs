using Xan.Extensions.Collections.Generic;

namespace Xan.Extensions.Tests.Collections.Generic.PaginationExtensionsTests;

public class AsPaginatedAsync
{
    private class TestEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }

    private readonly Fixture _fixture = new();

    [Fact]
    public async Task ShouldReturnCorrectPageSize()
    {
        //  Arrange
        IEnumerable<TestEntity> testEntities = _fixture.Build<TestEntity>().CreateMany(99);

        //  Act
        IPaginatedList<TestEntity> result = await testEntities.AsPaginatedAsync(10, 2);

        //  Assert
        using (new AssertionScope())
        {
            result.HasNextPage.Should().BeTrue();
            result.HasPreviousPage.Should().BeTrue();
            result.PageIndex.Should().Be(2);
            result.PageSize.Should().Be(10);
            result.TotalItemCount.Should().Be(99);
            result.TotalPageCount.Should().Be(10);
            result.Should().BeEquivalentTo(testEntities.Skip(10).Take(10));
        }
    }

    [Fact]
    public async Task WithSelector_ShouldReturnCorrectPageSize()
    {
        //  Arrange
        IEnumerable<TestEntity> testEntities = _fixture.Build<TestEntity>().CreateMany(99);

        //  Act
        IPaginatedList<string?> result = await testEntities.AsPaginatedAsync(10, 2, entity => entity.Name);

        //  Assert
        using (new AssertionScope())
        {
            result.HasNextPage.Should().BeTrue();
            result.HasPreviousPage.Should().BeTrue();
            result.PageIndex.Should().Be(2);
            result.PageSize.Should().Be(10);
            result.TotalItemCount.Should().Be(99);
            result.TotalPageCount.Should().Be(10);
            result.Should().BeEquivalentTo(testEntities.Skip(10).Take(10).Select(x => x.Name));
        }
    }

    [Fact]
    public async Task WithAsyncSelector_ShouldReturnCorrectPageSize()
    {
        //  Arrange
        IEnumerable<TestEntity> testEntities = _fixture.Build<TestEntity>().CreateMany(99);

        //  Act
        IPaginatedList<string?> result = await testEntities.AsPaginatedAsync(10, 2, async entity => await Task.FromResult(entity.Name));

        //  Assert
        using (new AssertionScope())
        {
            result.HasNextPage.Should().BeTrue();
            result.HasPreviousPage.Should().BeTrue();
            result.PageIndex.Should().Be(2);
            result.PageSize.Should().Be(10);
            result.TotalItemCount.Should().Be(99);
            result.TotalPageCount.Should().Be(10);
            result.Should().BeEquivalentTo(testEntities.Skip(10).Take(10).Select(x => x.Name));
        }
    }
}
