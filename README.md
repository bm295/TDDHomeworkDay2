# BookStore (C# 14 / .NET 10)

This repository is configured for **.NET 10** and **C# 14** (`LangVersion=preview`) and is now documented for **AI-native development**.

## Start Here
- AI agent operating guide: `AGENTS.md`
- Documentation hub: `docs/README.md`
- Product requirements: `docs/PRODUCT_REQUIREMENTS.md`
- Architecture blueprint: `docs/ARCHITECTURE.md`
- AI workflow: `docs/AI_DEVELOPMENT_WORKFLOW.md`
- Test strategy: `docs/TEST_STRATEGY.md`
- Prioritized backlog: `docs/BACKLOG.md`
- Canonical AI markdown execution order: `docs/EXECUTION_ORDER.md`

## Prerequisites

- .NET 10 SDK (preview)

## Restore and run tests

```bash
dotnet restore
dotnet test
```

## Existing IEnumerable demo: `BookIdSequence`

`BookStore/BookIdSequence.cs` demonstrates `IEnumerable<int>` by yielding a sequence of book IDs.

Run only the demo tests:

```bash
dotnet test --filter "FullyQualifiedName~BookIdSequenceTests"
```
