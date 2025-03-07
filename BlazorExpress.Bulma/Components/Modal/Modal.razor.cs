namespace BlazorExpress.Bulma;

/// <summary>
/// Block component
/// <see href="https://bulma.io/documentation/elements/block/" />
/// </summary>
public partial class Modal : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames => 
        BuildClassNames(
            Class, 
            (BulmaCssClass.Modal, true)
        );

    /// <summary>
    /// Gets or sets the modal content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the modal content.")]
    [Parameter]
    public RenderFragment? ModalContent { get; set; }

    #endregion
}
