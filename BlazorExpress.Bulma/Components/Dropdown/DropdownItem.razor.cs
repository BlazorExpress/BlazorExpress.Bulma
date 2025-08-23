namespace BlazorExpress.Bulma;

/// <summary>
/// DropdownItem component
/// <para>
/// <see href="https://bulma.io/documentation/components/dropdown/" />
/// </para>
/// </summary>
public partial class DropdownItem : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.DropdownItem, true),
            (BulmaCssClass.IsActive, IsActive)
        );

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// If <see langword="true"/>, the <see cref="DropdownItem" /> will show the menu.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the <code>DropdownItem</code> will show the menu.")]
    [Parameter]
    public bool IsActive { get; set; }

    #endregion
}
