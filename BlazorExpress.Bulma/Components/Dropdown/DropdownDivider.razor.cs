namespace BlazorExpress.Bulma;

/// <summary>
/// DropdownDivider component
/// <para>
/// <see href="https://bulma.io/documentation/components/dropdown/" />
/// </para>
/// </summary>
public partial class DropdownDivider : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.DropdownDivider, true)
        );

    #endregion
}
