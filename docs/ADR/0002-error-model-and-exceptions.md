# ADR 0002: Error Model and Exceptions

- Status: Accepted
- Date: 2026-03-26

## Context
The repository currently includes raw `Exception` usage in file handling and does not yet define a stable exception taxonomy. As the system grows, AI-generated code will diverge unless error behavior is explicitly standardized.

## Decision
Adopt a typed exception model rooted in `BookStoreException` and documented in `docs/ERROR_MODEL.md`.

Key rules:
- expected business failures use domain-specific exception types
- persistence failures use persistence-specific exception types
- raw `Exception` is reserved for truly unexpected failures and should not be thrown directly by normal application code
- tests must assert specific exception types for validation and rule failures

## Consequences
- AI agents have a stable contract for failure cases.
- Refactors can replace transitional raw exceptions with typed exceptions in small slices.
- Some existing tests and classes will need migration once the new exception types are introduced.

## Alternatives Considered
- Keep using raw `Exception` with message assertions only.
- Use result objects for every failure path in v1 without first standardizing the failure taxonomy.
