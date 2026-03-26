# Slice Definitions

## Purpose
This document defines what counts as a single AI-native delivery slice. Use it together with `BACKLOG.md` so agents take work items that are small, testable, and reviewable.

## Slice Size Rules
A valid slice should:
- implement exactly one primary behavior or rule
- have one dominant reason to fail
- usually require 1 to 5 new or updated tests
- usually touch no more than 3 production files
- be completable in one focused session

If a task needs multiple unrelated behaviors, split it before coding.

## Required Fields for a Ready Slice
Each ready slice should define:
- `Id`
- `Objective`
- `Acceptance criteria`
- `Required tests`
- `Non-goals`
- `Dependencies`
- `Expected modules or files`
- `Docs to update`

## Ready Checklist
A slice is ready for implementation only when:
- all dependencies are complete
- acceptance criteria are specific enough to write failing tests
- the relevant contract docs already exist
- the change does not require inventing new behavior during coding
- the slice has explicit non-goals

## Done Checklist
A slice is done only when:
- failing tests were added first or an existing failing test was reproduced first
- production code passes the new and relevant existing tests
- the slice changed only the intended behavior
- the backlog item was updated
- related docs were updated if behavior or architecture changed

## Recommended Slice Shape
Use this template when expanding a backlog item into an implementation brief:

```text
Slice Id:
Objective:
Acceptance criteria:
- ...
- ...
Required tests:
- happy path
- edge case
- validation/error case
Non-goals:
- ...
Dependencies:
- ...
Expected files/modules:
- ...
Docs to update:
- ...
```

## Example Slice

```text
Slice Id: S13
Objective: Add `InventoryItem` invariant checks for non-negative stock and reorder threshold.
Acceptance criteria:
- `InventoryItem` rejects negative `QuantityOnHand`
- `InventoryItem` rejects negative `ReorderThreshold`
- valid values are stored unchanged
Required tests:
- create item with valid values
- create item with negative stock throws `DomainValidationException`
- create item with negative reorder threshold throws `DomainValidationException`
Non-goals:
- stock adjustment services
- repository persistence
Dependencies:
- S10 base exception type
Expected files/modules:
- `BookStore/Domain/InventoryItem.cs`
- `BookStoreTests/Unit/InventoryItemTests.cs`
Docs to update:
- `docs/DOMAIN_MODEL.md` if invariants change
```

## Anti-Patterns
Do not treat these as a single slice:
- add book model, inventory, and checkout in one change
- refactor pricing engine while also changing discount semantics
- add repository interfaces and concrete file storage in one first pass
- broad cleanup with no acceptance criteria
