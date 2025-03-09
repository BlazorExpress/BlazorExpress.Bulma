namespace BlazorExpress.Bulma;

public class DialogService
{
}

public class DialogOption
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public string YesButtonText { get; set; } = "Yes";
    public string? YesButtonCssClass { get; set; }
    public string NoButtonText { get; set; } = "No";
    public string? NoButtonCssClass { get; set; }
}

public enum DialogType
{
    Alert,
    Confirm,
    Prompt
}