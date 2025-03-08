namespace BlazorExpress.Bulma;

/// <summary>
/// Overlay component
/// </summary>
public partial class Overlay : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames
        => BuildClassNames(
            Class,
            (BulmaCssClass.Overlay, true),
            (BulmaCssClass.IsActive, IsActive));

    [Parameter]
    public bool IsActive { get; set; } = false;

    #endregion
}