using Xan.Extensions.Collections.Generic;

namespace Xan.Extensions.Tests.Collections.Generic.IDictionaryExtensionsTests;

public class Set
{
    [Theory]
    [AutoData]
    public void KeyDoesNotExist_ShouldAdd(string key, string value)
    {
        //  Arrange
        IDictionary<string, string> dictionary = X.StrictFake<IDictionary<string, string>>();
        A.CallTo(() => dictionary.ContainsKey(key)).Returns(false);
        A.CallTo(() => dictionary.Add(key, value)).DoesNothing();

        //  Act
        dictionary.Set(key, value);

        //  Assert
        A.CallTo(() => dictionary.Add(key, value)).MustHaveHappenedOnceExactly();
        A.CallTo(() => dictionary.ContainsKey(key)).MustHaveHappenedOnceExactly();
    }

    [Theory]
    [AutoData]
    public void KeyDoesExist_ShouldSet(string key, string value)
    {
        //  Arrange
        IDictionary<string, string> dictionary = X.StrictFake<IDictionary<string, string>>();
        A.CallTo(() => dictionary.ContainsKey(key)).Returns(true);
        A.CallToSet(() => dictionary[key]).DoesNothing();

        //  Act
        dictionary.Set(key, value);

        //  Assert
        A.CallTo(() => dictionary.ContainsKey(key)).MustHaveHappenedOnceExactly();
        A.CallToSet(() => dictionary[key]).MustHaveHappenedOnceExactly();
    }
}
