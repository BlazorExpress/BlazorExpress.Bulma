namespace BlazorExpress.Bulma;

public class ConfirmDialogOptions
{
    public string? TitleCssClass { get; set; }
    public string? BodyCssClass { get; set; }
    public string? FootCssClass { get; set; }
    public string YesButtonText { get; set; } = "Yes";
    public ButtonColor YesButtonColor { get; set; } = ButtonColor.Primary;
    public string? YesButtonCssClass { get; set; }
    public string NoButtonText { get; set; } = "No";
    public ButtonColor NoButtonColor { get; set; } = ButtonColor.None;
    public string? NoButtonCssClass { get; set; }
}
