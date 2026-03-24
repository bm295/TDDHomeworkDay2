# AGENTS.md

## Purpose
This repository is configured for **AI-native development** of a BookStore management application.
Use this file as the default operating guide for coding agents.

## Product Goal
Build a maintainable bookstore management platform that supports:
- Catalog management
- Inventory tracking
- Pricing and discount rules
- Order/cart workflows
- File/storage integrations
- Automated test coverage

See `docs/PRODUCT_REQUIREMENTS.md` for detailed scope.

## Working Agreement for AI Agents
1. **Follow markdown execution order before coding**
   - Use `docs/EXECUTION_ORDER.md` as the canonical sequence.
   - Minimum docs pass: `docs/README.md` -> `docs/PRODUCT_REQUIREMENTS.md` -> `docs/DOMAIN_MODEL.md` -> `docs/ARCHITECTURE.md` -> `docs/BACKLOG.md` -> `docs/TEST_STRATEGY.md` -> `docs/AI_DEVELOPMENT_WORKFLOW.md`
2. **Use TDD**
   - Write/extend tests in `BookStoreTests/` first.
   - Implement minimal code in `BookStore/` to pass tests.
3. **Keep changes small and reviewable**
   - Prefer incremental commits tied to one capability.
4. **Protect backward compatibility when possible**
   - If breaking changes are needed, document them in PR notes.
5. **Update docs with behavior changes**
   - Any feature-level logic update should include docs updates.

## Definition of Done
A task is complete when:
- New/updated tests exist and pass.
- Core behavior is implemented in production code.
- Relevant docs/backlog items are updated.
- No unrelated refactors are mixed into the same change.

## Current Codebase Snapshot
- Language: C# (preview, configured as C# 14)
- Runtime: .NET 10 (preview)
- Solution: `BookStore.sln`
- Projects:
  - `BookStore/` (core library)
  - `BookStoreTests/` (unit tests)

## Priority Areas
1. Replace simplistic pricing logic with extensible discount strategy.
2. Add richer domain entities (book metadata, stock, order line items).
3. Introduce repository abstraction for persistence.
4. Improve error handling and validation (typed exceptions).
5. Expand tests for edge cases and domain workflows.

## Prompting Pattern (Recommended)
When asking an AI agent to implement work, include:
- Business objective
- Acceptance criteria
- Constraints (performance, compatibility, coding style)
- Required tests
- Explicit non-goals

Template:
"Implement `<feature>` for the BookStore app using TDD.
Acceptance criteria: `<list>`.
Constraints: `<list>`.
Add/update tests in `BookStoreTests/`.
Update docs if behavior changes."
