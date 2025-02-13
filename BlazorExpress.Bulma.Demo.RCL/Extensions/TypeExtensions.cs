namespace BlazorExpress.Bulma.Demo.RCL;

/// <summary>
/// Various extension methods for <see cref="Type" />.
/// </summary>
public static class TypeExtensions
{
    #region Methods

    /// <summary>
    /// Get added version of a property.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyName"></param>
    /// <returns>string</returns>
    public static string GetPropertyAddedVersion(this Type type, string propertyName)
    {
        if (type is null || string.IsNullOrWhiteSpace(propertyName))
            return string.Empty;

        var property = type.GetProperty(propertyName);
        if (property is null)
            return string.Empty;

        var addedVersionAttribute = property.GetCustomAttributes(typeof(AddedVersionAttribute), false)
            .FirstOrDefault() as AddedVersionAttribute;

        return addedVersionAttribute?.Version!;
    }

    /// <summary>
    /// Get default value of a property.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyName"></param>
    /// <returns>string</returns>
    public static string GetPropertyDefaultValue(this Type type, string propertyName)
    {
        if (type is null || string.IsNullOrWhiteSpace(propertyName))
            return string.Empty;

        var property = type.GetProperty(propertyName);
        if (property is null)
            return string.Empty;

        var defaultValueAttribute = property.GetCustomAttributes(typeof(DefaultValueAttribute), false)
            .FirstOrDefault() as DefaultValueAttribute;

        return defaultValueAttribute?.Value?.ToString() ?? "null";
    }

    public static string GetPropertyDescription(this Type type, string propertyName)
    {
        if (type is null || string.IsNullOrWhiteSpace(propertyName))
            return string.Empty;

        var property = type.GetProperty(propertyName);
        if (property is null)
            return string.Empty;

        var descriptionAttribute = property.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;

        return descriptionAttribute?.Description ?? string.Empty;
    }

    /// <summary>
    /// Get property type name.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyName"></param>
    /// <returns>string</returns>
    public static string GetPropertyTypeName(this Type type, string propertyName)
    {
        if (type is null || string.IsNullOrWhiteSpace(propertyName))
            return string.Empty;

        var propertyType = type.GetProperty(propertyName)?.PropertyType;
        if (propertyType is null)
            return string.Empty;

        var propertyTypeName = propertyType?.ToString();
        if (string.IsNullOrWhiteSpace(propertyTypeName))
            return string.Empty;

        if (propertyTypeName.Contains(StringConstants.PropertyTypeNameInt16, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameInt16CSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameInt32, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameInt32CSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameInt64, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameInt64CSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameChar, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameCharCSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameString, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameStringCSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameSingle, StringComparison.InvariantCulture)) // float
            propertyTypeName = StringConstants.PropertyTypeNameSingleCSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameDecimal, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameDecimalCSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameDouble, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameDoubleCSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameDateOnly, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameDateOnlyCSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameDateTime, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameDateTimeCSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameBoolean, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameBooleanCSharpTypeKeyword;

        else if (propertyType!.IsEnum)
            propertyTypeName = StringConstants.PropertyTypeNameEnumCSharpTypeKeyword;

        else if (propertyTypeName.Contains(StringConstants.PropertyTypeNameGuid, StringComparison.InvariantCulture))
            propertyTypeName = StringConstants.PropertyTypeNameGuidCSharpTypeKeyword;

        return propertyType!.IsNullableType() ? $"{propertyTypeName}?" : propertyTypeName;
    }

    /// <summary>
    /// Get property type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyName"></param>
    /// <returns>Type?</returns>
    public static Type? GetPropertyType(this Type type, string propertyName)
    {
        if (type is null || string.IsNullOrWhiteSpace(propertyName))
            return null;

        return type.GetProperty(propertyName)?.PropertyType;
    }

    /// <summary>
    /// Returns true if the property is required. Otherwise, false.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyName"></param>
    /// <returns>bool</returns>
    public static bool IsPropertyRequired(this Type type, string propertyName)
    {
        if (type is null || string.IsNullOrWhiteSpace(propertyName))
            return false;

        var property = type.GetProperty(propertyName);
        if (property is null)
            return false;

        var editorRequiredAttribute = property.GetCustomAttributes(typeof(EditorRequiredAttribute), false)
            .FirstOrDefault() as EditorRequiredAttribute;

        return editorRequiredAttribute is not null;
    }

    /// <summary>
    /// Get added version of a method.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <returns>string</returns>
    public static string GetMethodAddedVersion(this Type type, string methodName)
    {
        if (type is null || string.IsNullOrWhiteSpace(methodName))
            return string.Empty;

        var method = type.GetMethod(methodName);
        if (method is null)
            return string.Empty;

        var addedVersionAttribute = method.GetCustomAttributes(typeof(AddedVersionAttribute), false)
            .FirstOrDefault() as AddedVersionAttribute;

        return addedVersionAttribute?.Version!;
    }

    #endregion
}
