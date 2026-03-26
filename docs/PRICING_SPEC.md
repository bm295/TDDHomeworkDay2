# Pricing Specification

## Purpose
This document defines the canonical pricing rules for cart pricing and checkout totals. It is the source of truth for pricing tests and future pricing-engine refactors.

## Scope
- Cart subtotal, discount, and grand total calculations
- Distinct-title bundle promotion behavior
- Monetary precision, rounding, and explainability

## Current Baseline in Repo
The current `BookStoreEngine.CalculatePrice` implementation is a temporary baseline only.

Current baseline behavior:
- assumes all cart items share the same unit price
- derives a single discount from the count of distinct book IDs across the whole cart
- does not optimize multiple bundle groupings
- returns `int`

Target pricing work must preserve the current behavior only until the dedicated pricing migration slices replace it with this specification.

## Money Rules
- Monetary values use `decimal`.
- Currency is implicit and out of scope for v1.
- `UnitPrice`, `Subtotal`, `DiscountTotal`, and `GrandTotal` are represented with two decimal places.
- Calculations keep full decimal precision until totals are finalized.
- Final totals are rounded to two decimal places with `MidpointRounding.AwayFromZero`.
- Discount amounts are stored as positive values that are subtracted from subtotals.

## Pricing Inputs
A priced cart contains zero or more cart lines.

Each cart line must contain:
- `BookId`
- `Quantity > 0`
- `UnitPrice >= 0`

Additional rules:
- `UnitPrice` is a snapshot taken from the catalog at the time the line is added or increased.
- An empty cart is valid and produces zero totals.
- Pricing does not reserve stock.

## Promotion Model
Each promotion rule should expose, directly or through an equivalent contract:
- `Name`
- `Priority`
- `Combinability`
- `Apply(PricingContext)`

V1 enables exactly one promotion:
- `DistinctTitleBundlePromotion`

If additional rules exist in code before a new spec is approved, they must remain disabled so V1 totals stay stable.

## V1 Canonical Promotion: DistinctTitleBundlePromotion
A bundle is a group containing one copy of each distinct title.

Bundle discount table:

| Distinct titles in bundle | Discount |
| --- | --- |
| 1 | 0% |
| 2 | 5% |
| 3 | 10% |
| 4 | 20% |
| 5 | 25% |

Rules:
- The maximum discounted bundle size in v1 is 5 distinct titles.
- Carts with more than 5 distinct titles must be partitioned into multiple bundles of size 5 or less.
- Each physical copy can belong to at most one bundle.
- The pricing engine must choose the lowest possible total price for the whole cart.
- The engine must not use a simple "largest bundle first" heuristic if it produces a higher total.
- If two bundle partitions produce the same total, either partition is acceptable, but the resulting totals and pricing trace must be deterministic.

## Mixed Price Rule
- Discounts apply to the actual sum of prices inside each bundle.
- Titles in the same bundle do not need to share the same unit price.
- A bundle discount is calculated from the bundle subtotal, not from a store-wide default price.

## Non-Combinability Rule
- `DistinctTitleBundlePromotion` is non-combinable in v1.
- V1 totals may include only this promotion.

## Totals
- `Subtotal` = sum of `Quantity * UnitPrice` across all cart lines
- `DiscountTotal` = sum of all bundle discounts
- `GrandTotal` = `Subtotal - DiscountTotal`

## Pricing Trace
When pricing trace support is implemented, each trace entry should include:
- promotion rule name
- bundle members
- bundle subtotal before discount
- discount amount
- bundle total after discount

Trace entries should be ordered deterministically by promotion priority and then by bundle composition.

## Examples

### Example 1: Single title
Input:
- `A x1 @ 100.00`

Result:
- `Subtotal = 100.00`
- `DiscountTotal = 0.00`
- `GrandTotal = 100.00`

### Example 2: Two distinct titles
Input:
- `A x1 @ 100.00`
- `B x1 @ 100.00`

Result:
- one 2-title bundle
- `Subtotal = 200.00`
- `DiscountTotal = 10.00`
- `GrandTotal = 190.00`

### Example 3: Duplicate plus bundle
Input:
- `A x2 @ 100.00`
- `B x1 @ 100.00`

Result:
- one 2-title bundle and one single title
- `Subtotal = 300.00`
- `DiscountTotal = 10.00`
- `GrandTotal = 290.00`

### Example 4: Optimal bundling over greedy bundling
Input:
- `A x2 @ 100.00`
- `B x2 @ 100.00`
- `C x2 @ 100.00`
- `D x1 @ 100.00`
- `E x1 @ 100.00`

Result:
- optimal partition is two 4-title bundles
- `Subtotal = 800.00`
- `DiscountTotal = 160.00`
- `GrandTotal = 640.00`

This case is intentionally included because a naive 5-title bundle plus 3-title bundle is more expensive.

### Example 5: Mixed prices
Input:
- `A x1 @ 100.00`
- `B x1 @ 120.00`

Result:
- one 2-title bundle on `220.00`
- `Subtotal = 220.00`
- `DiscountTotal = 11.00`
- `GrandTotal = 209.00`

## Non-Goals
- Membership pricing
- Time-window promotions
- Coupon codes
- Tax calculation
- Multi-currency support
