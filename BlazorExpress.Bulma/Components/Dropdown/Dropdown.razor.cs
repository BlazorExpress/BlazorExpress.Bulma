namespace BlazorExpress.Bulma;

/// <summary>
/// Dropdown component
/// <para>
/// <see href="https://bulma.io/documentation/components/dropdown/" />
/// </para>
/// </summary>
public partial class Dropdown : BulmaComponentBase
{
    #region Fields and Constants

    private string dropdownContentId => IdUtility.GetNextId();

    private bool isActive;

    #endregion

    #region Methods

    private void OnClick()
    {
        if (!IsHoverable)
            isActive = !isActive;
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Dropdown, true),
            (BulmaCssClass.IsActive, !IsHoverable && IsActive),
            (BulmaCssClass.IsHoverable, IsHoverable),
            (BulmaCssClass.IsRight, IsRight),
            (BulmaCssClass.IsUp, IsUp)
        );

    /// <summary>
    /// Gets or sets the dropdown trigger.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the dropdown trigger.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? DropdownTrigger { get; set; }

    /// <summary>
    /// Gets or sets the dropdown content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the dropdown content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? DropdownContent { get; set; }

    /// <summary>
    /// If <see langword="true"/>, the <see cref="Dropdown" /> will show the menu.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the <code>Dropdown</code> will show the menu.")]
    [Parameter]
    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    /// <summary>
    /// If <see langword="true"/>, the dropdown will be activated on hover.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the <code>Dropdown</code> will be activated on hover.")]
    [Parameter]
    public bool IsHoverable { get; set; }

    /// <summary>
    /// If <see langword="true"/>, the dropdown menu will be aligned to the right side of its parent.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the dropdown menu will be aligned to the right side of its parent.")]
    [Parameter]
    public bool IsRight { get; set; }

    /// <summary>
    /// If <see langword="true"/>, the dropdown menu will be displayed above its parent.
    /// <para>
    /// Deafault value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the dropdown menu will be displayed above its parent.")]
    [Parameter]
    public bool IsUp { get; set; }

    #endregion
}
