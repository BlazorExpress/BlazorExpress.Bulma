# C-Sharp Standards

## Purpose

This file captures the C# implementation standards that agents should follow directly, without repeatedly re-inspecting the repository for the same patterns.

## Component Implementation Patterns

### Pattern: Split markup components into `.razor` and `.razor.cs`

Rule:
- Use `.razor` for rendered structure and event wiring.
- Use `.razor.cs` for parameters, lifecycle methods, validation, computed class/style helpers, and supporting methods.

Generic example:
- Keep the HTML element tree in the markup file and keep `OnParametersSet`, `OnInitialized`, and parameter declarations in code-behind.

Repository example:
- `BlazorExpress.Bulma/Components/Button/Button.razor`
- `BlazorExpress.Bulma/Components/Button/Button.razor.cs`

### Pattern: Keep some form controls as `.cs` components

Rule:
- When a control is already implemented with `BuildRenderTree`, continue using that pattern in the same feature area.

Generic example:
- A low-markup input component can stay as a single `.cs` file when rendering logic and validation are tightly coupled.

Repository example:
- `BlazorExpress.Bulma/Components/Form/TextInput/TextInput.cs`
- `BlazorExpress.Bulma/Components/Form/DateInput/DateInput.cs`
- `BlazorExpress.Bulma/Components/Form/NumberInput/NumberInput.cs`

## Namespace And Type Rules

- Use file-scoped namespaces.
- Use `BlazorExpress.Bulma` for library source unless the file belongs to another project.
- Use the project namespace for demo and host files, such as `BlazorExpress.Bulma.Demo.RCL`.
- Match file name and top-level type name.
- Use `partial` for code-behind classes paired with `.razor`.

Repository example:
- `public partial class Button : BulmaComponentBase`
- `public class TextInput : BulmaComponentBase`

## Naming Rules

- Use PascalCase for classes, enums, public methods, public properties, and files.
- Use camelCase for private fields.
- Use clear boolean prefixes such as `Is`, `Has`, `Allow`, `Enable`, or `AutoHide`.
- Use the `Async` suffix for asynchronous methods, except JS callback methods intentionally named after JS entry points.

Repository examples:
- `IsRounded`, `HasShadow`, `AllowPaging`, `EnableMaxMin`
- `RefreshGridAsync`, `OnPageChangedAsync`
- `WindowResizeJS`, `OnMarkerClickJS`

## Class Layout Rules

When a non-trivial file uses regions, keep this order:
- `Fields and Constants`
- `Constructors` when needed
- `Methods`
- `Properties, Indexers`

Repository examples:
- `Grid.razor.cs`
- `Button.razor.cs`
- `GridState.cs`

Do not:
- add arbitrary new region names when the established structure already fits.

## Public Component API Rules

### Parameter metadata pattern

Rule:
- Public component parameters should stay explicitly documented and annotated.
- Preserve the local attribute order when the file already uses it.

Dominant attribute pattern:
- `[AddedVersion(...)]`
- `[DefaultValue(...)]` when applicable
- `[Description(...)]`
- `[ParameterTypeName(...)]` when needed
- `[EditorRequired]` when needed
- `[Parameter]`

Repository example:
- `BlazorExpress.Bulma/Components/Button/Button.razor.cs`

### AddedVersion source rule

Rule:
- When a new public component API is introduced through a GitHub issue or feature that has an assigned milestone, set each new `[AddedVersion(...)]` value to that milestone title.
- Do not guess the version from the current package version when the issue milestone already defines the release target.

Generic example:
- if issue `#123` is assigned to milestone `2.4.0`, new public parameters and components added for that issue should use `[AddedVersion("2.4.0")]`

Repository example:
- issue `#40` for the Card component is assigned to milestone `1.2.0`, so the new `Card` family uses `[AddedVersion("1.2.0")]`

### Computed class/style properties

Rule:
- Keep `ClassNames`, `StyleNames`, and related computed properties grouped before the public parameters in the `Properties, Indexers` region.

Repository example:
- `Button.razor.cs`
- `Navbar.razor.cs`

## Validation Rules

- Validate incompatible parameter combinations in lifecycle methods.
- Throw explicit framework exceptions such as `InvalidOperationException`, `ArgumentException`, or `ArgumentNullException`.
- Include the component or parameter name in the exception message.

Generic example:
- reject mutually exclusive options early in `OnParametersSet`.

Repository example:
- `Button.OnParametersSet()` rejects both `IsLightVersion` and `IsDarkVersion`
- `ScriptLoader.OnParametersSet()` rejects missing `Source`
- `Grid.OnParametersSetAsync()` rejects incompatible data sources

## Dependency Injection Rules

- Register reusable library services through `AddBlazorExpressBulma(IServiceCollection)`.
- Use `[Inject]` properties in components when a service is needed inside a component.
- Keep host startup files calling the shared extension method instead of duplicating service registration.

Repository example:
- `BlazorExpress.Bulma/Services/RegisterServices.cs`
- `BlazorExpress.Bulma.Demo.Server/Program.cs`
- `BlazorExpress.Bulma.Demo.WebAssembly/Program.cs`

## Shared Code Placement Rules

- Put CSS class and variable tokens in `Constants/`.
- Put enum-to-string and enum-to-class mappings in `Extensions/`.
- Put lightweight request/result/state objects in `Models/`.
- Put event payload types in `EventArguments/`.
- Put small interop constant holders or helpers in `Utils/` or the owning feature folder.

Repository examples:
- `Constants/BulmaCssClass.cs`
- `Extensions/EnumExtensions.cs`
- `Models/GridState.cs`

## Logging Rule

- No dominant `ILogger` pattern is established in this repository.
- Do not introduce a new logging convention casually.
- If a future change establishes a real logging pattern, document it in this file.

## Maintenance Rule

- When you discover a recurring C# implementation pattern not already written here, add it here with:
  - the rule
  - when it applies
  - a generic example
  - a short repository example when helpful
