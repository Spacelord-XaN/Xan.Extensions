namespace Xan.Extensions.Collections.Generic;

public static class IDictionaryExtensions
{
    public static void Set<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        ArgumentNullException.ThrowIfNull(dictionary);
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(value);

        if (dictionary.ContainsKey(key))
        {
            dictionary[key] = value;
        }
        else
        {
            dictionary.Add(key, value);
        }
    }
}
