namespace BlazorExpress.Bulma;

public partial class OTPInput : BulmaComponentBase
{
    private string[] otpValues = Array.Empty<string>();

    // Auto focus
    // Color

    protected override void OnParametersSet()
    {
        if (otpValues.Length != Length)
        {
            otpValues = new string[Length];
            Array.Fill(otpValues, string.Empty);
        }
    }

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Input, true),
            (BulmaCssClass.HasTextCentered, true),
            (BulmaCssClass.MarginLeftRight1, true)
        );

    protected override string? StyleNames =>
        BuildClassNames(
            Style,
            ("width: 40px;", true),
            ("height: 40px;", true)
        );

    private string? ContainerClassNames =>
        BuildClassNames(
            ContainerCssClass,
            (BulmaCssClass.IsFlex, true),
            (BulmaCssClass.IsFlexDirectionRow, true)
        );

    private string? ContainerStyleNames =>
        BuildClassNames(
            ContainerCssStyle
        );

    private string GetInputId(int index)
    {
        return $"{Id}-otp-input-{index}";
    }

    private async Task OnInput(ChangeEventArgs e, int index)
    {
        Console.WriteLine($"OnInput: {e.Value}");

        string currentValue = otpValues[index] ?? "";
        var newValue = new string(e.Value?.ToString()?.Where(char.IsDigit)?.ToArray());

        if (string.IsNullOrEmpty(newValue))
        {
            otpValues[index] = string.Empty;
            return;
        }

        if (int.TryParse(newValue, out int digit))
        {
            otpValues[index] = digit.ToString();
            if (index < Length - 1)
            {
                otpValues[index + 1] = string.Empty;
                await JSRuntime.InvokeVoidAsync(JsInteropUtils.FocusElement, GetInputId(index + 1));
            }
        }
        else
        {
            otpValues[index] = string.Empty;
        }

        // Notify changes
        await NotifyChangesAsync();
    }

    private void OnKeyUp(KeyboardEventArgs e, int index)
    {
        // Handle backspace key to clear the current input and focus on the previous one
        if (e.Key == "Backspace" && index > 0)
        {
            otpValues[index] = string.Empty;
            JSRuntime.InvokeVoidAsync(JsInteropUtils.FocusElement, GetInputId(index - 1));
        }

        // Handle left arrow key to focus on the previous input
        if (e.Key == "ArrowLeft" && index > 0)
        {
            JSRuntime.InvokeVoidAsync(JsInteropUtils.FocusElement, GetInputId(index - 1));
        }

        // Handle right arrow key to focus on the next input
        if (e.Key == "ArrowRight" && index < Length - 1)
        {
            JSRuntime.InvokeVoidAsync(JsInteropUtils.FocusElement, GetInputId(index + 1));
        }
    }

    public async Task ClearAsync()
    {
        otpValues = new string[Length];
        Array.Fill(otpValues, string.Empty);
        await NotifyChangesAsync();

        if(Length > 0)
            await JSRuntime.InvokeVoidAsync(JsInteropUtils.FocusElement, GetInputId(0));

        await InvokeAsync(StateHasChanged);
    }

    private async Task NotifyChangesAsync()
    {
        var otpValue = string.Join(string.Empty, otpValues);
        await OnOTPChanged.InvokeAsync(otpValue);

        if (otpValue.Length == Length
            && !otpValues.Any(string.IsNullOrWhiteSpace))
        {
            await OnOTPCompleted.InvokeAsync(otpValue);
        }
    }

    [Parameter]
    public string? ContainerCssClass { get; set; }

    [Parameter]
    public string? ContainerCssStyle { get; set; }

    // Disabled
    // Divider

    [Parameter] 
    public EventCallback<string> OnOTPCompleted { get; set; }

    [Parameter] 
    public EventCallback<string> OnOTPChanged { get; set; }

    [Parameter]
    public int Length { get; set; } = 6;

    // Size
    // Style
    // Width
}
