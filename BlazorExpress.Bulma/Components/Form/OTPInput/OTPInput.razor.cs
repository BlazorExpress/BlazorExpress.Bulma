﻿namespace BlazorExpress.Bulma;

public partial class OTPInput : BulmaComponentBase
{
    #region Fields and Constants

    private string[] otpValues = Array.Empty<string>();

    #endregion

    #region Methods

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

    /// <summary>
    /// Clears the OTP input fields.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Clears the OTP input fields.")]
    public async Task ClearAsync()
    {
        otpValues = new string[Length];
        Array.Fill(otpValues, string.Empty);
        await NotifyChangesAsync();

        if (Length > 0)
            await JSRuntime.InvokeVoidAsync(JsInteropUtils.FocusElement, GetInputId(0));

        await InvokeAsync(StateHasChanged);
    }

    private string GetInputId(int index) => $"{Id}-otp-input-{index}";

    private async Task NotifyChangesAsync()
    {
        var otpValue = string.Join(string.Empty, otpValues);
        await OnOTPChanged.InvokeAsync(otpValue);

        if (otpValue.Length == Length
            && !otpValues.Any(string.IsNullOrWhiteSpace))
            await OnOTPCompleted.InvokeAsync(otpValue);
    }

    private async Task OnInput(ChangeEventArgs e, int index)
    {
        Console.WriteLine($"OnInput: {e.Value}");

        var currentValue = otpValues[index] ?? "";
        var newValue = new string(e.Value?.ToString()?.Where(char.IsDigit)?.ToArray());

        if (string.IsNullOrEmpty(newValue))
        {
            otpValues[index] = string.Empty;

            return;
        }

        if (int.TryParse(newValue, out var digit))
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
        if (e.Key == "ArrowLeft" && index > 0) JSRuntime.InvokeVoidAsync(JsInteropUtils.FocusElement, GetInputId(index - 1));

        // Handle right arrow key to focus on the next input
        if (e.Key == "ArrowRight" && index < Length - 1) JSRuntime.InvokeVoidAsync(JsInteropUtils.FocusElement, GetInputId(index + 1));
    }

    #endregion

    #region Properties, Indexers

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

    /// <summary>
    /// Gets or sets the CSS class for the container element.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS class for the container element.")]
    [Parameter]
    public string? ContainerCssClass { get; set; }

    /// <summary>
    /// Gets or sets the CSS style for the container element.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS style for the container element.")]
    [Parameter]
    public string? ContainerCssStyle { get; set; }

    private string? ContainerStyleNames =>
        BuildClassNames(
            ContainerCssStyle
        );

    /// <summary>
    /// Gets or sets the OTP input length.
    /// <para>
    /// Default value is 6.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(6)]
    [Description("Gets or sets the OTP input length.")]
    [Parameter]
    public int Length { get; set; } = 6;

    /// <summary>
    /// This event fires when the OTP input value changes.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the OTP input value changes.")]
    [Parameter]
    public EventCallback<string> OnOTPChanged { get; set; }

    // Disabled
    // Divider

    /// <summary>
    /// This event fires when the OTP input is completed.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the OTP input is completed.")]
    [Parameter]
    public EventCallback<string> OnOTPCompleted { get; set; }

    #endregion

    // Size
    // Style
    // Width
}
