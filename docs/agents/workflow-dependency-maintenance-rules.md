# Workflow Dependency Maintenance Rules

## Purpose

This file defines how agents should validate work, manage dependencies, maintain documentation, and clean up temporary artifacts.

## Build And Validation Rules

### Safe baseline commands

Run from repository root when environment access permits:

```powershell
dotnet restore .\BlazorExpress.Bulma.sln
dotnet build .\BlazorExpress.Bulma.sln
```

For the current CI deployment target:

```powershell
dotnet build .\BlazorExpress.Bulma.Demo.Server\BlazorExpress.Bulma.Demo.Server.csproj --configuration Release
dotnet publish .\BlazorExpress.Bulma.Demo.Server\BlazorExpress.Bulma.Demo.Server.csproj --configuration Release
```

Rule:
- Prefer solution-level restore/build for broad validation.
- Prefer the server host Release build when validating the path currently used by CI.

## Observed Workflow State

Current repository signals:
- solution file present: `BlazorExpress.Bulma.sln`
- CI workflow present: `.github/workflows/main_bulma-blazorexpress.yml`
- no dedicated test project found
- no repo-level lint command found
- no repo-level formatter command found
- no repository `.editorconfig` found
- no `global.json` found

Rule:
- Do not invent permanent workflow requirements that the repository does not currently define.

## CI Rule

Observed CI behavior:
- GitHub Actions builds on `windows-latest`
- workflow targets the server host project
- deployment is gated behind the `prod_release` input

Repository example:
- `.github/workflows/main_bulma-blazorexpress.yml`

Rule:
- Review CI ownership before changing host startup, deployment target, or publish assumptions.

## Dependency Ownership Rules

- Add reusable library dependencies to `BlazorExpress.Bulma` only when the reusable library needs them.
- Add docs/demo-only dependencies to `BlazorExpress.Bulma.Demo.RCL`.
- Keep host-only startup or runtime packages in the host project that uses them.
- Register reusable library services through `AddBlazorExpressBulma()`.

Repository examples:
- `BlazorExpress.Bulma.csproj`
- `BlazorExpress.Bulma.Demo.RCL.csproj`
- `RegisterServices.cs`

## Host Wiring Rules

- Keep host projects responsible for top-level service registration calls, route hosting, render-mode setup, and script/style includes.
- Do not move host-only bootstrapping into the reusable library.

Repository examples:
- `BlazorExpress.Bulma.Demo.Server/Program.cs`
- `BlazorExpress.Bulma.Demo.Server/Components/App.razor`
- `BlazorExpress.Bulma.Demo.WebAssembly/Program.cs`

## Documentation Maintenance Rules

- When you add, remove, or discover a recurring standard, update the relevant `docs/agents/` file in the same change set.
- If a new rule does not fit the existing files, expand the closest relevant file instead of creating fragmented micro-docs by default.
- Keep rules explicit.
- Replace vague guidance with:
  - the rule
  - when it applies
  - a generic example
  - a short repository example when helpful

### Supported Versions Sync Rule

Rule:
- When you add, remove, or change any package version, target framework, hosted script dependency, stylesheet dependency, or other externally visible library/framework version used by the repository, update the Getting Started `Supported Versions` section in the same change set.
- Treat this as required for both reusable-library changes and demo/docs host wiring changes when the effective shipped stack changes.

When it applies:
- updating NuGet package versions
- changing target frameworks such as `net8.0`, `net9.0`, or `net10.0`
- changing CDN-hosted third-party libraries such as Chart.js, PDF.js, Bulma, Bootstrap Icons, or similar browser dependencies
- changing documented release-stack information that users rely on during setup

Generic example:
- if a component package starts depending on a newer charting library or a host starts loading a newer CDN script, update the Supported Versions table and related version notes in the setup docs during the same task

Repository example:
- update `BlazorExpress.Bulma.Demo.RCL/Pages/Docs/GettingStarted/GettingStartedDocumentation.razor` whenever the shipped stack shown there changes

## Requirement Clarification Rule

Before implementation:
- Always analyze the provided requirements for ambiguity, missing decisions, or conflicting expectations before starting any new implementation.
- If any ambiguity remains that could materially affect the implementation, ask clarifying questions before making code changes.
- Ask one clarification question at a time.
- For each clarification question, provide:
  - multiple-choice options
  - a `Custom Answer` option
  - one recommended option
  - a short justification for the recommended option
- Wait for the user's answer before asking the next clarification question or starting implementation.
- If the requirement is already clear enough to implement safely, say so briefly in a user-facing note and then proceed without inventing unnecessary questions.

Generic example:
- if a component change request does not specify whether the new behavior should be opt-in or default, ask that decision first before editing parameters or rendering logic

Repository example:
- if a change to `BlazorExpress.Bulma/Components/Button/` is unclear about whether it should preserve existing rendered markup for demo and docs examples, resolve that expectation before modifying the component and its companion demo/docs pages

## Temporary Artifact Cleanup Rule

- Remove temporary folders, temp files, tool caches, scratch notes, and ad hoc verification artifacts created during the task before finishing.
- If a temporary artifact is intentionally kept, document why in the change summary.

Generic examples:
- temporary CLI home folders
- scratch output files
- one-off copied assets used only for local verification

Repository example:
- remove a temporary folder such as `.dotnet-cli/` after the implementation and verification steps are complete

## Completion Rule

Before finishing a task:
- verify the relevant build or validation path when environment access allows it
- update affected docs in the same change set
- clean up temporary artifacts
- leave the repository in a state where only intentional deliverables remain
