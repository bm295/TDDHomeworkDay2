# AI Development Execution Order (Markdown Playbook)

Use this exact order when developing the BookStore application with AI agents.

## Phase 0 — Alignment (Read-Only)
1. `README.md`  
   Understand project setup, SDK version, and repo entry points.
2. `AGENTS.md`  
   Load AI operating rules, definition of done, and collaboration constraints.
3. `docs/README.md`  
   Confirm documentation map and operating principle.

## Phase 1 — Product to Design
4. `docs/PRODUCT_REQUIREMENTS.md`  
   Extract business goals, scope, and acceptance criteria for the selected feature.
5. `docs/DOMAIN_MODEL.md`  
   Translate requirements into entities, invariants, and service boundaries.
6. `docs/ARCHITECTURE.md`  
   Decide layer placement and dependency direction for implementation.

## Phase 2 — Delivery Planning
7. `docs/BACKLOG.md`  
   Pick one prioritized backlog item and define the smallest implementable slice.
8. `docs/TEST_STRATEGY.md`  
   Decide required tests (happy path, edge case, validation/error case).
9. `docs/AI_DEVELOPMENT_WORKFLOW.md`  
   Use the prompt templates and quality gates before generating code.

## Phase 3 — Build Cycle (Repeat)
10. Write/extend tests first in `BookStoreTests/`.
11. Implement minimal production code in `BookStore/`.
12. Refactor while preserving behavior.
13. Re-run tests.
14. Update docs if behavior, architecture, or backlog status changed.

## Phase 4 — Completion Checklist
15. Confirm acceptance criteria from `docs/PRODUCT_REQUIREMENTS.md` are met.
16. Confirm test expectations from `docs/TEST_STRATEGY.md` are met.
17. Mark or adjust the relevant item in `docs/BACKLOG.md`.
18. Ensure `README.md` and/or other docs reflect any externally visible changes.

---

## One-Line Agent Instruction
"Follow `docs/EXECUTION_ORDER.md` exactly; read docs in order, implement one backlog slice with TDD, and update docs before finishing."
