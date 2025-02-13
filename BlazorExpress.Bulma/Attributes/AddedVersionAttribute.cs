namespace BlazorExpress.Bulma;

/// <summary>
/// Attribute to specify the version when a property was added.
/// </summary>
public class AddedVersionAttribute : Attribute
{
    public string Version { get; }

    public AddedVersionAttribute(string version)
    {
        Version = version;
    }
}
