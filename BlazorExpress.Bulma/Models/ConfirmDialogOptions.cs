namespace BlazorExpress.Bulma;

public class ConfirmDialogOptions
{
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("The title of the dialog.")]
    public string? TitleCssClass { get; set; }

    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("body CSS class.")]
    public string? BodyCssClass { get; set; }

    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("foot CSS class.")]
    public string? FootCssClass { get; set; }

    [AddedVersion("1.0.0")]
    [DefaultValue("Yes")]
    [Description("Yes button text.")]
    public string YesButtonText { get; set; } = "Yes";

    [AddedVersion("1.0.0")]
    [DefaultValue(ButtonColor.Primary)]
    [Description("Yes button color.")]
    public ButtonColor YesButtonColor { get; set; } = ButtonColor.Primary;

    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Yes button CSS class.")]
    public string? YesButtonCssClass { get; set; }

    [AddedVersion("1.0.0")]
    [DefaultValue("No")]
    [Description("No button text.")]
    public string NoButtonText { get; set; } = "No";

    [AddedVersion("1.0.0")]
    [DefaultValue(ButtonColor.None)]
    [Description("No button color.")]
    public ButtonColor NoButtonColor { get; set; } = ButtonColor.None;

    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("No button CSS class.")]
    public string? NoButtonCssClass { get; set; }
}
