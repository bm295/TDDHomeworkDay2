# AI Development Execution Order (Markdown Playbook)

Use this exact order when developing the BookStore application with AI agents.

## Phase 0 - Alignment (Read-Only)
1. `README.md`  
   Understand project setup, SDK version, repo entry points, documentation map, and operating principle.
2. `AGENTS.md`  
   Load AI operating rules, definition of done, and collaboration constraints.

## Phase 1 - Product to Design
3. `docs/PRODUCT_REQUIREMENTS.md`  
   Extract business goals, scope, and acceptance criteria for the selected feature.
4. `docs/DOMAIN_MODEL.md`  
   Translate requirements into entities, invariants, and service boundaries.
5. `docs/USE_CASES.md`  
   Confirm application-level commands, queries, actors, and outputs.
6. `docs/ARCHITECTURE.md`  
   Decide layer placement and dependency direction for implementation.
7. `docs/ADR/0001-initial-layering.md`  
   Confirm the accepted layering decision.
8. `docs/ADR/0002-error-model-and-exceptions.md`  
   Confirm the accepted exception strategy.

## Phase 2 - Rules and Contracts
9. `docs/ERROR_MODEL.md`  
    Confirm expected exception types and translation rules.
10. `docs/PRICING_SPEC.md`  
    Confirm pricing behavior before touching pricing or checkout code.
11. `docs/PERSISTENCE_SCHEMA.md`  
    Confirm file contracts before touching repository or file code.

## Phase 3 - Delivery Planning
12. `docs/BACKLOG.md`  
   Pick one ready backlog slice.
13. `docs/SLICE_DEFINITIONS.md`  
   Expand the slice into explicit acceptance criteria, tests, dependencies, and non-goals.
14. `docs/TEST_STRATEGY.md`  
   Decide required tests (happy path, edge case, validation/error case).
15. `docs/AI_DEVELOPMENT_WORKFLOW.md`  
   Use the prompt templates and quality gates before generating code.

## Phase 4 - Build Cycle (Repeat)
16. Write or extend tests first in `BookStoreTests/`.
17. Implement minimal production code in `BookStore/`.
18. Refactor while preserving behavior.
19. Re-run tests.
20. Update docs if behavior, architecture, or backlog status changed.

## Phase 5 - Completion Checklist
21. Confirm acceptance criteria from the chosen slice and `docs/PRODUCT_REQUIREMENTS.md`.
22. Confirm contract compliance with `docs/USE_CASES.md`, `docs/PRICING_SPEC.md`, `docs/PERSISTENCE_SCHEMA.md`, and `docs/ERROR_MODEL.md` as applicable.
23. Confirm test expectations from `docs/TEST_STRATEGY.md`.
24. Mark or adjust the relevant item in `docs/BACKLOG.md`.
25. Ensure `README.md` and/or other docs reflect any externally visible changes.

---

## One-Line Agent Instruction
"Follow `docs/EXECUTION_ORDER.md` exactly; read docs in order, implement one ready slice with TDD, and update docs before finishing."
