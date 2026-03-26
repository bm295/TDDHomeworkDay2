# Error Model

## Purpose
This document defines the typed exception strategy for the BookStore application. It exists to stop AI agents from introducing raw `Exception` usage in domain, application, or infrastructure code.

## Principles
- Throw typed exceptions, not raw `Exception`, for expected business and persistence failures.
- Keep error types stable and domain-meaningful.
- Preserve enough detail for tests and operators to understand what failed.
- Fail before state mutation whenever possible.

## Base Type
Recommended base type:
- `BookStoreException : Exception`

Recommended base properties:
- `Code`
- `Message`
- optional `InnerException`
- optional metadata payload if needed later

## Exception Taxonomy

### `DomainValidationException`
Use when input violates a domain rule.

Examples:
- empty title
- negative price
- invalid ISBN format
- checkout with empty cart

Recommended code:
- `domain.validation`

### `DuplicateEntityException`
Use when a uniqueness rule is violated.

Examples:
- duplicate ISBN
- duplicate book identifier in persistence input

Recommended code:
- `domain.duplicate`

### `EntityNotFoundException`
Use when a requested entity does not exist.

Examples:
- unknown `BookId`
- removing a missing cart line

Recommended code:
- `domain.not_found`

### `InsufficientStockException`
Use when a stock-dependent operation would move inventory below zero.

Examples:
- checkout requests 3 copies and only 2 are available
- manual stock reduction would create negative quantity

Recommended code:
- `inventory.insufficient_stock`

### `PersistenceException`
Use for infrastructure read and write failures that are not domain validation failures.

Examples:
- file system failure
- serialization failure

Recommended code:
- `persistence.failure`

### `MalformedDataException`
Subclass of `PersistenceException`.

Use when persisted data is unreadable or violates stored-data invariants.

Examples:
- invalid JSON
- duplicate records in a file
- negative stock in persisted inventory

Recommended code:
- `persistence.malformed_data`

### `UnsupportedSchemaVersionException`
Subclass of `PersistenceException`.

Use when a persisted file declares a schema version the reader does not support.

Recommended code:
- `persistence.unsupported_schema`

## Message Rules
- Messages should explain the violated rule, not only the symptom.
- Messages should include the primary identifier when safe and useful.
- Messages should avoid leaking low-level path or stack details unless needed for diagnostics.

Good examples:
- `Book title is required.`
- `Book with ISBN '9780131103627' already exists.`
- `Checkout requires 3 units for BookId 7 but only 2 are available.`

## Handling Rules by Layer

### Domain Layer
- Throws domain exceptions only.
- Must not throw persistence exceptions.

### Application Layer
- May translate lower-level exceptions into use-case-specific failures when needed.
- Must preserve the original exception as `InnerException` when translation happens.

### Infrastructure Layer
- May throw persistence exceptions.
- Must not throw raw `Exception` for expected file, schema, or serialization issues.

## Current Repository Baseline
The current `FileIO` implementation throws raw `Exception` for invalid file paths. That behavior is transitional and should be replaced by typed exceptions in a dedicated migration slice.

## Testing Rules
Every new exception type should have tests that verify:
- type
- message
- code if the implementation includes a code property
- no partial state mutation occurred when the exception was thrown
