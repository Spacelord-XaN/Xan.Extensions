using System.ComponentModel.DataAnnotations;
using Xan.Extensions.Reflection;

namespace Xan.Extensions.Tests.Reflection.EnumInfoTests;

public class Get
{
    private enum MyEnum
    {
        B_One = 1,
        A_Two = 2,
        [Display(Name = "C three")]
        C_Three = 3
    }

    [Fact]
    public void ReturnsEnumValueInfo()
    {
        //  Arrange

        //  Act
        IEnumerable<EnumValueInfo> valueInfos = EnumInfo.Get<MyEnum>();

        //  Assert
        valueInfos.Should().BeEquivalentTo([
            new  EnumValueInfo("A_Two", "A_Two"),
            new  EnumValueInfo("B_One", "B_One"),
            new  EnumValueInfo("C three", "C_Three"),
        ]);
    }
}
