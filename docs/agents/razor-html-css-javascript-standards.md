# Razor HTML CSS JavaScript Standards

## Purpose

This file combines the markup, styling, and browser-side standards that agents should follow directly for Razor, HTML, CSS, JavaScript, and Blazor interop work.

## Razor And Markup Rules

### Pattern: Use explicit top directives for library components

Rule:
- Library `.razor` files commonly declare namespace and base class explicitly.
- Add `@typeparam` only when the component is genuinely generic.

Repository example:
- `@namespace BlazorExpress.Bulma`
- `@inherits BulmaComponentBase`
- `@typeparam TItem` in `Grid.razor`

### Pattern: Keep root elements pass-through friendly

Rule:
- Preserve `@ref`, `id`, computed class/style properties, and `@attributes` on the root interactive element.

Generic example:
- the root rendered element should continue to accept extra attributes and styles from callers.

Repository example:
- `Button.razor`
- `Grid.razor`
- `Navbar.razor`

### Pattern: Use cascading parent-child composition for tightly coupled components

Rule:
- Use `CascadingValue` in a parent and `CascadingParameter` in children when the children must register with the parent or share direct component state.

Repository example:
- `Grid.razor` with `GridColumn<TItem>`
- `Navbar.razor` with nested navbar pieces
- `Tabs` and `Tab`

## HTML Rules

- Prefer semantic elements that match behavior.
- Preserve accessibility attributes already present in the component.
- Do not replace semantic markup with generic `<div>` containers unless the local component pattern requires it.

Repository examples:
- `Navbar.razor` uses `<nav>`
- `Grid.razor` uses `<table>`, `<thead>`, `<tbody>`
- `Button.razor` chooses `<a>` or `<button>` based on behavior

## CSS Rules

### Pattern: Bulma-first class composition

Rule:
- Reuse Bulma class constants and enum mapping helpers instead of scattering raw class strings.

Repository example:
- `BulmaCssClass.cs`
- `EnumExtensions.cs`

### Pattern: Scoped CSS for component-specific styling

Rule:
- Put component-specific styling in a sibling `.razor.css` file when the styling is owned by one component.

Repository example:
- `Components/Menu/Menu.razor.css`
- `Components/Navbar/NavbarBurger.razor.css`

### Pattern: Global CSS by ownership

Rule:
- Put reusable package CSS in the library `wwwroot/css`.
- Put demo-site-only CSS in the demo RCL `wwwroot/css`.

Repository example:
- `BlazorExpress.Bulma/wwwroot/css/blazorexpress.bulma.css`
- `BlazorExpress.Bulma.Demo.RCL/wwwroot/css/blazorexpress.bulma.demo.rcl.css`

### Pattern: Prefix custom CSS with `be-bulma-`

Rule:
- Custom classes and CSS variables should use the `be-bulma-` naming prefix unless the file is intentionally mirroring a third-party convention.

Repository example:
- `.be-bulma-page`
- `.be-bulma-doc-example`
- `--be-bulma-navbar-height`

## JavaScript Rules

### Pattern: Keep reusable browser logic under `window.blazorexpress.bulma`

Rule:
- Add reusable library browser behavior under the shared global namespace rooted at `window.blazorexpress.bulma`.
- Group functions by feature object.

Repository example:
- `googlemaps`
- `menu`
- `numberInput`
- `scriptLoader`
- `utils`

### Pattern: Keep demo-site browser logic separate

Rule:
- Demo-only browser behavior belongs in the demo RCL script, not in the reusable library script.

Repository example:
- `BlazorExpress.Bulma.Demo.RCL/wwwroot/js/blazorexpress.bulma.demo.rcl.js`

### Pattern: Mirror JS identifiers in C# interop constants

Rule:
- Keep JavaScript function names and C# interop constant names aligned.

Repository example:
- `window.blazorexpress.bulma.numberInput.initialize`
- `NumberInputJsInterop.Initialize`

## Host Script And Style Loading Rules

- Load reusable RCL assets through `_content/<AssemblyName>/...`.
- Keep host-level script and stylesheet inclusion in the host application startup or host page.
- Keep demo and docs host assets separate from the reusable library assets.

Repository example:
- `BlazorExpress.Bulma.Demo.Server/Components/App.razor`

## Demo And Docs Markup Rules

- Use the demo RCL for docs and demos rather than placing user-facing examples in the main library project.
- Keep docs pages and demo pages formulaic and easy to scan.
- When a component changes publicly, update matching docs and demos in the same change.

Repository example:
- `Pages/Docs/Button/Button_Doc_01_Documentation.razor`
- `Pages/Demos/Button/Button_Demo_09_Click_Events.razor`

## Maintenance Rule

- When you discover a recurring markup, CSS, or JavaScript pattern not already written here, add it here with:
  - the rule
  - when it applies
  - a generic example
  - a short repository example when helpful
