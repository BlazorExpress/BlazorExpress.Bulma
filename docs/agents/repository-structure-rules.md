# Repository Structure Rules

## Purpose

This file defines where new code, assets, demos, docs, and supporting files belong.

## Project Boundaries

### `BlazorExpress.Bulma`

Owns:
- reusable components
- reusable CSS and JS
- shared enums, constants, models, extensions, services, and utilities
- package-facing assets and metadata

Do:
- put reusable functionality here

### `BlazorExpress.Bulma.Demo.RCL`

Owns:
- layouts
- docs pages
- demo pages
- screenshots
- demo-only CSS and JS
- content assets such as sample documents and images

Do:
- put companion docs and demos here

### `BlazorExpress.Bulma.Demo.Server` and `BlazorExpress.Bulma.Demo.WebAssembly`

Own:
- host startup
- service registration calls
- top-level asset loading
- routing and render-mode hosting

Do:
- keep these hosts thin

## Folder Placement Rules

### Library component placement

Rule:
- Put each reusable component family under `BlazorExpress.Bulma/Components/<Feature>/`.

Repository examples:
- `Components/Button/`
- `Components/Grid/`
- `Components/Form/EnumInput/`

### Shared code placement

- `Constants/` for tokens and shared constants
- `Enums/` for enums grouped by category
- `Models/` for lightweight data/state/result classes
- `Extensions/` for reusable extension methods
- `Services/` for registration and reusable service classes
- `Utils/` for focused helper classes
- `EventArguments/` for event payload types

### Demo and docs placement

Rule:
- Put documentation pages under `BlazorExpress.Bulma.Demo.RCL/Pages/Docs/`.
- Put example/demo pages under `BlazorExpress.Bulma.Demo.RCL/Pages/Demos/`.
- Keep them grouped by feature or component folder.

Repository example:
- `Pages/Docs/Button/`
- `Pages/Demos/Button/`

## Naming Rules

### Component files

- Match folder, component name, and file base name.
- Keep paired `.razor` and `.razor.cs` names aligned.

### Docs pages

Dominant pattern:
- `<Component>_Doc_01_Documentation.razor`

### Demo pages

Dominant pattern:
- `<Component>_Demo_<nn>_<Scenario>.razor`

Known inconsistency:
- Some folders also contain `<Component>Documentation.razor`.

Rule:
- When editing an existing area, match the naming convention already used in that folder.

## Asset Ownership Rules

- Reusable library assets belong under `BlazorExpress.Bulma/wwwroot/`.
- Demo-only assets belong under `BlazorExpress.Bulma.Demo.RCL/wwwroot/`.
- Package README and package images belong under `nuget/` when they are packed by the library project.

Repository examples:
- `BlazorExpress.Bulma/wwwroot/js/blazorexpress.bulma.js`
- `BlazorExpress.Bulma.Demo.RCL/wwwroot/images/screenshots/`
- `nuget/README.md`

## Generated Output Rule

- Do not place authored source in `bin/` or `obj/`.
- Do not treat generated scoped CSS or build artifacts as the source of truth for conventions.

## Companion Update Rule

- If a public library component changes, review whether matching docs, demos, screenshots, or snippets should also change.
- Keep those companion updates in the same change set when they are affected.

## Maintenance Rule

- When a new recurring repository placement rule appears, add it here with:
  - the rule
  - when it applies
  - a generic example
  - a short repository example when helpful
