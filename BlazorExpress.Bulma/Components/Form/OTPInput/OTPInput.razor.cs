using System.Xml.Linq;

namespace BlazorExpress.Bulma;

public partial class OTPInput : BulmaComponentBase
{
    // Auto focus
    // Color

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

    [Parameter]
    public string? ContainerCssClass { get; set; }

    [Parameter]
    public string? ContainerCssStyle { get; set; }

    // Disabled
    // Divider

    [Parameter]
    public int Length { get; set; } = 6;

    // Size
    // Style
    // Width
}
