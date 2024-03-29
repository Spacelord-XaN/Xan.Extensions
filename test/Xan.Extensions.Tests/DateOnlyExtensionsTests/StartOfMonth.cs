﻿namespace Xan.Extensions.Tests.DateOnlyExtensionsTests;

public class StartOfMonth
{
    [Fact]
    public void ReturnsDateTimeWithCorrectTime()
    {
        //  Arrange
        DateOnly date = new(2023, 04, 05);

        //  Act
        DateTime result = date.StartOfMonth();

        //  Assert
        result.Year.Should().Be(date.Year);
        result.Month.Should().Be(date.Month);
        result.Day.Should().Be(1);
        result.Hour.Should().Be(0);
        result.Minute.Should().Be(0);
        result.Second.Should().Be(0);
        result.Millisecond.Should().Be(0);
    }
}
