# AI-Native Development Workflow

## Goal
Enable fast, reliable, prompt-driven development while preserving software quality through TDD and documentation discipline.

## 1) Workflow Loop (per feature)
1. Select one item from `docs/BACKLOG.md`.
2. Convert it into explicit acceptance criteria.
3. Ask AI to write/extend failing tests first.
4. Ask AI to implement minimal code to pass tests.
5. Refactor with behavior preserved.
6. Update docs and backlog status.

## 2) Prompt Templates

## A) Feature Implementation Prompt
"Implement `<feature>` in the BookStore solution using TDD.
First add tests in `BookStoreTests/` that fail.
Then implement the minimal production changes in `BookStore/`.
Acceptance criteria:
- `<criterion 1>`
- `<criterion 2>`
Constraints:
- Keep API backward compatible where possible.
- Avoid unrelated refactors.
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
- No dead/commented-out code introduced.
- Docs updated when architecture or behavior changes.

## 4) Review Checklist (Human + AI)
- Does change satisfy acceptance criteria?
- Are edge cases tested?
- Is naming domain-meaningful?
- Are exceptions specific and actionable?
- Is scope appropriately small?

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
- Letting AI perform broad “cleanup” unrelated to the task.
- Accepting generated code without domain validation.
