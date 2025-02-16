namespace BlazorExpress.Bulma.Demo.RCL;

/// <summary>
/// Various extension methods for <see cref="Type" />.
/// </summary>
public static class TypeExtensions
{
    #region Methods

    /// <summary>
    /// Get component parameters.
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Returns list of component parameters</returns>
    private static IEnumerable<PropertyInfo>? GetComponentParameters(this Type type)
    {
        if (type is null)
            return null;

        var properties = type.GetProperties();
        return properties?.Where(p => p.GetCustomAttributes(typeof(ParameterAttribute), false).Any() && p.Name != "AdditionalAttributes")?.OrderBy(p => p.Name);
    }

    /// <summary>
    /// Get component parameters and excludes event callbacks.
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Returns list of component parameters</returns>
    public static HashSet<PropertyInfo> GetComponentParametersOnly(this Type type)
    {
        var parameters = type.GetComponentParameters();
        if (parameters is null)
            return new HashSet<PropertyInfo>();

        return parameters
            .Where(p => !p.IsEventCallbackProperty())
            .ToHashSet();
    }

    /// <summary>
    /// Get component event callbacks.
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Returns list of component event callbacks.</returns>
    public static HashSet<PropertyInfo> GetComponentEventCallbacks(this Type type)
    {
        HashSet<string> eventCallbacks = new();

        var parameters = type.GetComponentParameters();
        if (parameters is null)
            return new HashSet<PropertyInfo>();

        return parameters
            .Where(p => p.IsEventCallbackProperty())
            .ToHashSet();
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

    /// <summary>
    /// Get method description.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <returns>string</returns>
    public static string GetMethodDescription(this Type type, string methodName)
    {
        if (type is null || string.IsNullOrWhiteSpace(methodName))
            return string.Empty;

        var method = type.GetMethod(methodName);
        if (method is null)
            return string.Empty;

        var descriptionAttribute = method.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;

        return descriptionAttribute?.Description ?? string.Empty;
    }

    /// <summary>
    /// Get method return type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="methodName"></param>
    /// <returns>string</returns>
    public static string GetMethodReturnType(this Type type, string methodName)
    {
        if (type is null || string.IsNullOrWhiteSpace(methodName))
            return string.Empty;

        var method = type.GetMethod(methodName);
        if (method is null)
            return string.Empty;

        return method.ReturnType.ToString();
    }

    /// <summary>
    /// Get property type name.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyName"></param>
    /// <returns>string</returns>
    public static string GetCSharpTypeName(this Type type)
    {
        if (type is null)
            return string.Empty;

        var typeName = type.Name;
        if (string.IsNullOrWhiteSpace(typeName))
            return string.Empty;

        if (typeName.Contains(StringConstants.PropertyTypeNameInt16, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameInt16CSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameInt32, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameInt32CSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameInt64, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameInt64CSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameChar, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameCharCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameStringComparison, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameStringComparisonCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameString, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameStringCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameSingle, StringComparison.InvariantCulture)) // float
            typeName = StringConstants.PropertyTypeNameSingleCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameDecimal, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameDecimalCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameDouble, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameDoubleCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameDateOnly, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameDateOnlyCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameDateTime, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameDateTimeCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameBoolean, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameBooleanCSharpTypeKeyword;

        //else if (propertyType!.IsEnum)
        //    propertyTypeName = StringConstants.PropertyTypeNameEnumCSharpTypeKeyword;

        else if (typeName.Contains(StringConstants.PropertyTypeNameGuid, StringComparison.InvariantCulture))
            typeName = StringConstants.PropertyTypeNameGuidCSharpTypeKeyword;

        return typeName;
    }

    #endregion
}
