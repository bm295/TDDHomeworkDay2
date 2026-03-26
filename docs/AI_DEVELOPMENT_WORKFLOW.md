# AI-Native Development Workflow

## Goal
Enable fast, reliable, prompt-driven development while preserving software quality through TDD and documentation discipline.

## 1) Workflow Loop (per slice)
1. Select one ready slice from `docs/BACKLOG.md`.
2. Expand it with `docs/SLICE_DEFINITIONS.md`.
3. Read the relevant contract docs before coding:
   - `docs/USE_CASES.md`
   - `docs/ERROR_MODEL.md`
   - `docs/PRICING_SPEC.md`
   - `docs/PERSISTENCE_SCHEMA.md`
4. Ask AI to write or extend failing tests first.
5. Ask AI to implement the minimal production code to pass those tests.
6. Refactor with behavior preserved.
7. Update docs and backlog status.

## 2) Prompt Templates

## A) Feature Implementation Prompt
"Implement slice `<slice id>` in the BookStore solution using TDD.
First add tests in `BookStoreTests/` that fail.
Then implement the minimal production changes in `BookStore/`.
Acceptance criteria:
- `<criterion 1>`
- `<criterion 2>`
Required tests:
- `<happy path>`
- `<edge case>`
- `<validation or error case>`
Constraints:
- Keep API backward compatible where possible.
- Avoid unrelated refactors.
- Touch only the expected modules unless the tests force a small extension.
Non-goals:
- `<explicit non-goal>`
Update docs if behavior changes."

## B) Refactor Prompt
"Refactor `<module>` for readability and extensibility.
Do not change observable behavior.
Run and keep existing tests passing.
Add tests only if needed to protect uncovered behavior.
Summarize design tradeoffs."

## C) Bugfix Prompt
"Fix bug: `<description>`.
Add a failing test that reproduces the issue.
Implement the smallest possible fix.
Explain root cause and prevention strategy."

## 3) Quality Gates for AI-Generated Changes
- Compiles successfully.
- Relevant tests pass.
- New behavior is test-covered.
- Slice dependencies were already complete before coding started.
- No dead/commented-out code introduced.
- Docs updated when architecture or behavior changes.

## 4) Review Checklist (Human + AI)
- Does change satisfy acceptance criteria?
- Are edge cases tested?
- Is naming domain-meaningful?
- Are exceptions specific and actionable?
- Is scope appropriately small?
- Does the change match the active contract docs?

## 5) Branch & Commit Convention
- Branch examples:
  - `feature/catalog-management`
  - `feature/pricing-rules-engine`
  - `fix/fileio-line-read-bounds`
- Commit style:
  - `feat: add cart aggregate and pricing service`
  - `test: add checkout stock validation cases`
  - `docs: add AI-native architecture and workflow guides`

## 6) Anti-Patterns to Avoid
- Large multi-feature prompts in one change.
- Implementing code before writing tests.
- Letting AI perform broad "cleanup" unrelated to the task.
- Accepting generated code without domain validation.
- Starting a slice before its dependencies are complete.
