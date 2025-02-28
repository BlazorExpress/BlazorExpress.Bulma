using System.Runtime.CompilerServices;

namespace BlazorExpress.Bulma;

/// <summary>
/// Extension methods for <see cref="RenderTreeBuilder" />.
/// <see href="https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/RenderTreeBuilderExtensions.cs" />
/// </summary>
internal static class RenderTreeBuilderExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddAttributeIfNotNullOrWhiteSpace(this RenderTreeBuilder builder, int sequence, string name, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            builder.AddAttribute(sequence, name, value);
    }
}
