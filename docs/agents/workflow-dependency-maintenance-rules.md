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
