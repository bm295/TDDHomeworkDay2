# ADR 0001: Initial Layering

- Status: Accepted
- Date: 2026-03-26

## Context
The repository currently contains a small set of classes in a single library project. The product scope is expanding to catalog management, inventory, pricing, checkout, persistence, and reporting. AI agents need a stable way to decide where new code belongs without inventing architecture on each task.

## Decision
Use a layered architecture inside the existing `BookStore/` project before considering project-level splits.

Layer responsibilities:
- `Domain`: entities, value objects, domain services, and domain exceptions
- `Application`: use-case orchestration, commands, queries, handlers, and repository abstractions
- `Infrastructure`: file repositories, serialization, and other external adapters
- `Interface` (future): CLI, API, or UI adapters

Folder direction:
- `Domain` depends on no infrastructure code
- `Application` depends on `Domain`
- `Infrastructure` depends on `Application` and `Domain`
- interface code depends on `Application`

Testing split:
- `BookStoreTests/Unit` for domain and isolated application rules
- `BookStoreTests/Integration` for repository and orchestration flows

## Consequences
- Agents have clear placement rules for new code.
- The solution can evolve without forcing an immediate multi-project refactor.
- Cross-layer shortcuts should be treated as defects, not conveniences.
- Some transitional wrappers may exist while old classes are retired.

## Alternatives Considered
- Keep adding classes to the root namespace with no layering.
- Split into multiple projects immediately before behavior exists to justify the extra structure.
