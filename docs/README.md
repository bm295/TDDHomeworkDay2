# BookStore Documentation Hub

This folder contains the core documentation needed to develop the BookStore management application in an **AI-native** way.

## Documents
- `PRODUCT_REQUIREMENTS.md`  
  Functional and non-functional scope, user roles, and acceptance criteria.
- `DOMAIN_MODEL.md`  
  Core entities, relationships, and invariants.
- `ARCHITECTURE.md`  
  Target architecture, component boundaries, and evolution plan.
- `AI_DEVELOPMENT_WORKFLOW.md`  
  Practical workflow for prompt-driven, test-first implementation.
- `TEST_STRATEGY.md`  
  Testing pyramid, suites, conventions, and quality gates.
- `BACKLOG.md`  
  Prioritized implementation roadmap.
- `EXECUTION_ORDER.md`  
  Exact markdown file reading/execution order for AI-native delivery.

## Reading/Execution Order (for humans and agents)
Use `EXECUTION_ORDER.md` as the canonical sequence to follow.

Quick sequence:
1. `PRODUCT_REQUIREMENTS.md`
2. `DOMAIN_MODEL.md`
3. `ARCHITECTURE.md`
4. `BACKLOG.md`
5. `TEST_STRATEGY.md`
6. `AI_DEVELOPMENT_WORKFLOW.md`

## Operating Principle
For each new feature:
1. Pick one backlog item.
2. Confirm acceptance criteria from product requirements.
3. Add tests first.
4. Implement minimal code to pass.
5. Refactor.
6. Update docs when behavior changes.
