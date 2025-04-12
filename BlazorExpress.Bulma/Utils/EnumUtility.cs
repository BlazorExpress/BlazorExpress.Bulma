namespace BlazorExpress.Bulma;

public class EnumUtility<TEnum> where TEnum : Enum
{
    #region Methods

    /// <summary>
    /// Gets the enum values as a list of enum items.
    /// </summary>
    /// <returns>
    /// Returns a list of <see cref="EnumItem" /> representing the enum values.
    /// </returns>
    public static List<EnumItem> GetEnumItems()
    {
        return Enum.GetValues(typeof(TEnum))
                   .Cast<TEnum>()
                   .Select(e => new EnumItem { Value = Convert.ToInt32(e), Text = GetEnumDescription(e) })
                   .ToList();
    }

    private static string GetEnumDescription(TEnum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString()!);
        var descriptionAttribute = fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false)?.FirstOrDefault() as DescriptionAttribute;

        if (descriptionAttribute is null)
            return value.ToString()!;

        return descriptionAttribute.Description;
    }

    #endregion
}
