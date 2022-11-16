using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Xan.Extensions.Reflection;

public sealed class EnumInfo
{
    private static readonly Dictionary<Type, List<EnumValueInfo>> _cache = new ();

    public static IEnumerable<EnumValueInfo> Get<TEnum>()
        where TEnum : struct, Enum
    {
        Type type = typeof(TEnum);
        if (_cache.TryGetValue(type, out List<EnumValueInfo>? list))
        {
            return list;
        }

        List<EnumValueInfo> valueInfos = new();
        foreach (TEnum enumValue in Enum.GetValues<TEnum>())
        {
            string enumValueString = enumValue.ToString();
            MemberInfo member = type.GetMember(enumValueString).First();
            string displayText = enumValueString;
            foreach (object attribute in member.GetCustomAttributes(typeof(DisplayAttribute), false))
            {
                if (attribute is DisplayAttribute displayAttribute)
                {
                    if (displayAttribute.Name != null)
                    {
                        displayText = displayAttribute.Name;
                        break;
                    }
                }
            }

            EnumValueInfo valueInfo = new(displayText, enumValueString);
            valueInfos.Add(valueInfo);
        }

        _cache.Add(type, valueInfos);
        return valueInfos;
    }
}
