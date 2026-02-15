# BookStore (C# 14 / .NET 10)

This repository is now configured for **.NET 10** and **C# 14** (`LangVersion=preview`).

## Prerequisites

- .NET 10 SDK (preview)

## Restore and run tests

```bash
dotnet restore
dotnet test
```

## IEnumerable demo: `BookIdSequence`

A new class named `BookIdSequence` was added in `BookStore/BookIdSequence.cs` to demonstrate `IEnumerable<int>`.

It yields a sequence of book IDs beginning from `startId`, with `count` items.

### Demo via targeted tests

Run only the demo tests:

```bash
dotnet test --filter "FullyQualifiedName~BookIdSequenceTests"
```

The test `GetEnumerator_ReturnsExpectedRange` demonstrates iterating over the `IEnumerable<int>` and materializing it with `ToList()`.
