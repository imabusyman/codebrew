using System.ComponentModel;

namespace CodeBrew.Common.Extensions;

public static class EnumExtensions
{
    #region Public Methods

    public static string GetDescription(this Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[])fi?.GetCustomAttributes(typeof(DescriptionAttribute), false)!;
        return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
    }

    public static string ToLowerInvariant(this Enum value)
    {
        return value.ToString().ToLowerInvariant();
    }

    #endregion Public Methods
}