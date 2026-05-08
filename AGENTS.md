# AGENTS.md

This file is the entry point for development agents working in this repository. It contains the top-priority rules that should be followed without re-discovering patterns from the codebase each time. Detailed standards live in the referenced documents below.

## Scope

- Primary reusable library: `BlazorExpress.Bulma/`
- Companion demo and docs projects: `BlazorExpress.Bulma.Demo.RCL/`, `BlazorExpress.Bulma.Demo.Server/`, `BlazorExpress.Bulma.Demo.WebAssembly/`
- Package assets: `nuget/`

## Top-Priority Rules

- Keep markup components split by responsibility when that pattern already exists.
  Rule: if a component already uses `.razor` plus `.razor.cs`, keep markup in `.razor` and move parameters, lifecycle logic, validation, and computed classes/styles into `.razor.cs`.
  Example: `BlazorExpress.Bulma/Components/Button/Button.razor` stays thin while `Button.razor.cs` owns parameters and `ClassNames`.

- Preserve the established `.cs`-only component pattern for low-markup input controls.
  Rule: do not convert existing `BuildRenderTree` components into `.razor` files unless the repository explicitly adopts a new pattern.
  Example: `BlazorExpress.Bulma/Components/Form/TextInput/TextInput.cs` and `NumberInput/NumberInput.cs` are authored as `.cs` components.

- Update companion docs and demos when public component behavior changes.
  Rule: if a library change affects public parameters, events, rendered output, install/setup guidance, or user-facing behavior, update the matching demo/docs content in the same change set.
  Example: a change under `BlazorExpress.Bulma/Components/Button/` should trigger review of `BlazorExpress.Bulma.Demo.RCL/Pages/Docs/Button/` and `Pages/Demos/Button/`.

- Align demo navigation sources for every new component implementation.
  Rule: when you add a new component or first-time demo/docs area, wire it into both demo navigation sources in the same change set: `DemoPageLinkUtil` for the home/demo catalog and `DemosMainLayout` for the demos sidebar menu.
  Example: adding `Spinner` requires both the `DemoPageLinkUtil.GetDemosLinks()` entry and the `DemosMainLayout` `ELEMENTS` sidebar link.

- Keep ownership boundaries intact.
  Rule: reusable component code and reusable static assets belong in `BlazorExpress.Bulma/`; docs, demos, screenshots, demo CSS/JS, and content assets belong in `BlazorExpress.Bulma.Demo.RCL/`; host startup wiring belongs in the server or WebAssembly host projects.

- Treat generated output as non-authoritative.
  Rule: do not derive coding standards from `bin/`, `obj/`, generated scoped CSS, or published artifacts.

- Preserve the current inconsistency strategy.
  Rule: when the repository has mixed patterns, use the nearest local pattern for the file or feature you are changing and document the ambiguity if you formalize it here later.

- Perform a mandatory requirement analysis before every new implementation.
  Rule: before starting any new implementation, first analyze the provided requirements for ambiguity, missing decisions, or conflicting expectations. If any material ambiguity exists, pause before coding and resolve it through sequential clarification questions. Ask one question at a time, provide multiple-choice options plus a `Custom Answer` option, mark a recommended option, explain why it is recommended, and wait for the user's response before asking the next question or starting implementation.
  Rule: if the requirement is already clear enough to implement safely, document that conclusion in a short user-facing note and then proceed.
  Example: if a feature request is unclear about API shape, UI behavior, or backward-compatibility expectations, ask the highest-impact unresolved question first and do not begin code changes until that ambiguity is resolved.

- Clean up temporary artifacts after every implementation.
  Rule: remove temporary folders, temp files, tool caches, ad hoc scratch outputs, and one-off verification artifacts created during the task before finishing the change.
  Example: a temporary CLI cache folder like `.dotnet-cli/` should not remain in the repository after the work is complete.

- Maintain these agent docs as part of the same change.
  Rule: whenever you add, remove, discover, or change a coding rule, folder rule, workflow rule, dependency relationship, or recurring implementation pattern, update the relevant file under `docs/agents/` in the same change set.

## When To Open Which File

- Editing C# classes, component code-behind, services, models, or enums:
  open [`docs/agents/c-sharp-standards.md`](docs/agents/c-sharp-standards.md)

- Editing Razor markup, HTML structure, CSS, scoped CSS, static JS, or Blazor JS interop:
  open [`docs/agents/razor-html-css-javascript-standards.md`](docs/agents/razor-html-css-javascript-standards.md)

- Adding, moving, renaming, or organizing files, features, assets, or companion docs/demos:
  open [`docs/agents/repository-structure-rules.md`](docs/agents/repository-structure-rules.md)

- Running builds, validating changes, changing project references, updating package dependencies, or maintaining documentation/workflow rules:
  open [`docs/agents/workflow-dependency-maintenance-rules.md`](docs/agents/workflow-dependency-maintenance-rules.md)

## Reference Documents

- [`docs/agents/c-sharp-standards.md`](docs/agents/c-sharp-standards.md)
  Defines the C# implementation standards used in this repository, including component code-behind structure, `.cs`-only component patterns, naming, parameter metadata, validation style, DI, and helper organization.
  Consult before creating or modifying `.cs` or `.razor.cs` files.

- [`docs/agents/razor-html-css-javascript-standards.md`](docs/agents/razor-html-css-javascript-standards.md)
  Defines the combined markup, styling, and browser-side standards for Razor markup, semantic HTML, Bulma class composition, scoped CSS, global CSS ownership, JavaScript organization, and Blazor JS interop.
  Consult before creating or modifying `.razor`, `.razor.css`, `.css`, or `.js` files.

- [`docs/agents/repository-structure-rules.md`](docs/agents/repository-structure-rules.md)
  Defines file placement, project boundaries, folder naming, docs/demo coupling, asset ownership, and where new features or supporting files should live.
  Consult before adding, moving, renaming, or restructuring files and folders.

- [`docs/agents/workflow-dependency-maintenance-rules.md`](docs/agents/workflow-dependency-maintenance-rules.md)
  Defines build and validation commands, CI behavior, dependency ownership, host wiring rules, documentation maintenance requirements, and cleanup expectations.
  Consult before running or changing workflows, dependencies, startup wiring, or repository maintenance rules.
