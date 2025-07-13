namespace BlazorExpress.Bulma;

/// <summary>
/// Modifies the URL matching behavior for a Microsoft.AspNetCore.Components.Routing.NavLink.
/// </summary>
public enum MenuItemMatch
{
    /// <summary>
    /// Specifies that the Microsoft.AspNetCore.Components.Routing.NavLink should be 
    /// active when it matches any prefix of the current URL.
    /// </summary>
    Prefix = 0,

    /// <summary>
    /// Specifies that the Microsoft.AspNetCore.Components.Routing.NavLink should be
    /// active when it matches the entire current URL.
    /// </summary>
    All = 1
}
