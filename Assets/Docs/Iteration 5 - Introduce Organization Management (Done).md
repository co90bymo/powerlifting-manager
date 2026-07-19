
## Idea

Introduce the first permanent management systems by transforming the player from only managing athletes into managing an actual organization.

This iteration focuses on introducing:

- Facility ownership
- Recurring weekly expenses
- Improved financial processing
- Basic money restrictions
- Improved competition registration flow
- Better financial transparency

The systems introduced are intentionally simple and designed as foundations for future expansions such as:

- Equipment management
- Staff costs
- Club development
- Sponsors
- Contracts
- Advanced economy simulation

---

# New Features

# Facility System

The first version of organization management was introduced through facilities.

Previously:

- The player only managed athletes.
- The gym existed only as a location.

Now:

- The player owns facilities.
- Facilities create permanent financial obligations.
- Facilities are connected to the finance system.

---

## Facility Architecture

Added a reusable facility system.

Created:

- Base `Facility` class.
- First facility implementation: `Gym`.

Facilities now contain:

- Facility type.
- Ownership status.
- Weekly cost.
- Maintenance cost.
- Finance category.

This creates the foundation for future facilities such as:

- Competition equipment
- Training areas
- Recovery facilities
- Additional gym upgrades

---

## Gym Facility

The first player-owned facility was introduced.

Added:

### Gym

Contains:

- Ownership.
- Weekly rent cost.
- Maintenance cost.
- Automatic expense generation.

The gym now represents the first permanent organization expense.

---

# Recurring Expense System

Facilities now generate recurring weekly costs.

Added:

- Automatic weekly facility finance entries.
- Rent expenses.
- Maintenance expenses.
- Connection with `FinanceManager`.

The weekly finance loop now includes:

1. Facility costs are generated.
2. Finance entries are created.
3. Expenses are displayed.
4. Transactions are processed.

This creates the foundation for future systems such as:

- Electricity costs
- Equipment maintenance
- Insurance
- Staff salaries

---

# Facilities UI

Introduced a new facility management interface.

Added:

## Facilities Button

Added a new button in the Gym scene.

Location:

- Leftmost button in the top bar.

Players can now access facility management directly from the gym.

---

## Facilities Panel

Created the first facility overview screen.

Added:

### Left Side

- Facility image display.

### Right Side

- Facility information.

### Bottom Menu

- Facility selection navigation.

The UI structure is prepared for future expansion with multiple facilities.

---

# Finance System Improvements

The finance system was expanded from tracking only competition transactions into supporting organization costs.

Previously:

- Finance mainly tracked competition income and expenses.

Now:

- Finance supports recurring costs.
- Finance supports pending transactions.
- Finance distinguishes between completed and scheduled payments.

---

# Finance Processing Improvements

Added better transaction handling.

Transactions now support:

- Immediate completion.
- Scheduled completion.

Logic:

## Completed Transactions

Examples:

- Competition entry fees.
- Instant purchases.

Rules:

- Money is checked before applying.
- Transaction fails if the player cannot afford it.

---

## Pending Transactions

Examples:

- Rent.
- Maintenance.
- Recurring costs.

Rules:

- Payments are always processed.
- Player may go negative.

This creates realistic financial pressure:

> The organization must pay its bills, even if it cannot afford them.

---

# Financial Restrictions

Introduced the first version of money validation.

Previously:

- The player could freely spend money.

Now:

- Instant purchases cannot exceed available funds.
- Competition registrations check affordability.
- Recurring costs can create debt.

The finance system now differentiates between:

## Optional Spending

Examples:

- Purchases.
- Registrations.
- Future upgrades.

Requirement:

- Player must have enough money.

---

## Required Organization Costs

Examples:

- Rent.
- Maintenance.

Requirement:

- Always processed.

---

# Competition Improvements

The competition registration system was redesigned.

---

# New Registration Flow

Previously:

- Athletes were immediately registered when clicked.
- Fees were instantly applied.
- Registration could create unwanted financial states.

Now:

Players follow a confirmation-based flow.

New process:

1. Open competition.
2. Select athletes.
3. Review costs.
4. Confirm registration.
5. Pay entry fees.
6. Register athletes.

---

# Athlete Selection System

Athletes are no longer immediately registered.

Added:

- Temporary athlete selection list.
- Selection toggle.
- Registration confirmation.

Players can now:

- Select multiple athletes.
- Review total fees.
- Confirm once.

This creates the foundation for future systems such as:

- Registration limits.
- Athlete contracts.
- Team strategy.
- Competition preparation.

---

# Registration Restrictions

Added financial checks before registration.

Players cannot:

- Register athletes they cannot afford.

The UI prevents selecting additional athletes when:

- Current selection cost exceeds available money.

This gives immediate feedback before confirmation.

---

# Registration Deadline Display

Competitions now communicate registration deadlines.

Added visual indicator:

- Red button outline.
- Transparent red button overlay.

The player can immediately see when:

- Registration is currently in the final phase.

This improves competition clarity and reduces accidental missed deadlines.

---

# Competition Registration UI Improvements

Added:

- Current balance display.
- Competition fee display.
- Total registration cost.
- Confirmation popup.

Players now understand:

- Current available money.
- Registration cost.
- Financial consequences before confirming.

---

# Finance Panel Improvements

The finance panel was expanded to better communicate organization costs.

Added:

## Expense Separation

The UI now distinguishes between:

- One-time payments.
- Recurring organization costs.

---

## Weekly Finance Overview

Added improved financial information:

Players can now see:

- Current balance.
- Upcoming changes.
- Applied expenses.
- Scheduled expenses.

---

## Pending Transactions

Added support for displaying future payments.

Players can now understand:

- What has already been paid.
- What will be charged later.

This prepares the finance UI for:

- Loans.
- Salaries.
- Contracts.
- Long-term expenses.

---

# Bug Fixes

## Competition Registration Bug

Fixed:

> Competition fees were applied, but athletes could still be registered afterwards.

Problem:

- Clicking athletes immediately modified competition data.
- Fees and registration state became inconsistent.

Solution:

The registration process was separated.

Now:

- Athlete selection does not register athletes.
- Registration happens only after confirmation.
- Registered athletes cannot be removed.
- Additional athletes can still be registered later until the deadline.

---

# Code Architecture Improvements

## Facility Architecture

Created a reusable organization system.

Added:

- Facility base class.
- Facility ownership.
- Facility finance generation.

Future systems can now build on:

- Equipment.
- Staff.
- Buildings.
- Upgrades.

---

## Finance Architecture Expansion

The finance system now supports:

- Immediate expenses.
- Scheduled expenses.
- Recurring costs.
- Income.
- Expense categories.

The system is now ready for a larger economic simulation.

---

# Current Gameplay Loop

The gameplay loop is now:

1. Manage club athletes.
2. Assign training.
3. Improve athlete performance.
4. Maintain organization facilities.
5. Pay recurring weekly expenses.
6. Register athletes for competitions.
7. Manage available funds.
8. Compete against AI athletes.
9. Earn prize money.
10. Improve the organization.

---

# Result

Iteration 5 introduces the first true management layer.

The game now contains:

- Player-owned facilities.
- Recurring organization expenses.
- Facility management UI.
- Improved finance processing.
- Money restrictions.
- Confirmation-based registration.
- Registration deadlines.
- Better financial transparency.

These systems provide the foundation for future expansions such as:

- Equipment purchases.
- Staff management.
- Athlete contracts.
- Sponsorships.
- Club reputation.
- Gym upgrades.
- Advanced financial simulation.