# Product Backlog

Prioritized for AI-native, test-first delivery.

## P0 — Foundation
- [ ] Add richer `Book` model (ISBN, title, author, category, decimal price).
- [ ] Introduce domain validation and typed exceptions.
- [ ] Add `InventoryItem` model and stock adjustment logic.
- [ ] Add cart aggregate with line-item quantities.
- [ ] Add checkout workflow with stock validation.

## P1 — Pricing Engine
- [ ] Refactor `BookStoreEngine` into pluggable promotion rules.
- [ ] Preserve current distinct-book discount semantics via rule(s).
- [ ] Add support for rule priority and combinability controls.
- [ ] Add pricing trace output for explainability/debugging.

## P1 — Persistence
- [ ] Define repository interfaces for books, inventory, and orders.
- [ ] Add file-based repository implementations.
- [ ] Add serialization versioning for persisted records.
- [ ] Add integration tests for corrupted/missing data files.

## P2 — Reporting
- [ ] Add sales summary use case.
- [ ] Add top-selling books report.
- [ ] Add low-stock report.

## P2 — Developer Experience
- [ ] Add CI workflow for build + tests.
- [ ] Add code analyzers and formatting configuration.
- [ ] Add architecture decision record (ADR) folder/template.

## Suggested Next 3 Tasks
1. Implement `InventoryItem` + stock validation tests.
2. Introduce cart and checkout aggregate tests.
3. Refactor pricing logic into a rule abstraction with characterization tests.
