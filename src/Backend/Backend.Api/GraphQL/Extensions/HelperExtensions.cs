namespace Wotan.Backend.Api.GraphQL.Extensions;

public static class HelperExtensions
{
    public static TEnum CastTo<TEnum>(this string value)
        where TEnum : struct, Enum
        => Enum.TryParse(value, out TEnum parsedValue)
            ? parsedValue
            : default;
}