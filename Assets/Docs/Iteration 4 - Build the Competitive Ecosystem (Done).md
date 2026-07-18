## Idea

Transform competitions from isolated events into a persistent competitive ecosystem.

This iteration focuses on making the world feel alive by introducing:

- Recurring competitions
- Athlete career progression
- Competition history
- Basic financial consequences
- Improved athlete and competition presentation

The systems introduced are intentionally simple and designed as foundations for future expansions.

---

# New Features

## Recurring Competition System

Competitions were transformed from one-time events into recurring events.

Added:

- Automatic competition generation.
- Competition scheduling over time.
- Recurring competition templates.
- Competition week tracking.

Competitions can now:

- Exist in the future.
- Appear repeatedly.
- Be registered for.
- Be completed multiple times.

This creates the foundation for future systems such as:

- Competition rankings
- Seasons
- Championships
- Qualification systems

---

## Athlete Profiles and Career History

Athletes were expanded from simple stat containers into persistent career entities.

Added:

- Athlete profile view.
- Athlete statistics overview.
- Competition history.
- Personal records.

Athlete history now stores:

- Competition name
- Competition date
- Overall ranking
- Weight class ranking
- Total lifted
- Squat performance
- Bench performance
- Deadlift performance
- Prize money earned

Athletes now maintain a career record instead of only current attributes.

---

## Athlete Profile Access

Athlete profiles can now be opened from different parts of the game.

Added clickable athlete access from:

- Competition results
- Athlete roster
- Training view

This creates a consistent way to inspect athletes throughout the game.

---

# Competition Improvements

## Competition Result Expansion

Competition results were expanded with additional career information.

Added:

- Historical result saving.
- Personal best tracking.
- Improved result presentation.

Athletes now track:

- Best competition squat
- Best competition bench
- Best competition deadlift
- Best competition total
- Best competition dots score

---

## Improved Prize Money System

Prize money was expanded into a proper income source.

Previously:

- Prize money was directly awarded as a generic reward.

Now:

- Prize money belongs to athletes.
- Player athletes contribute their earnings to the player.

Added:

- Athlete prize money tracking.
- Player income from athlete earnings.
- Competition prize history.

This creates the foundation for future systems such as:

- Athlete contracts
- Sponsorships
- Team management
- Career earnings

---

# Finance System

Introduced the first version of a real finance system.

Added:

- Finance manager.
- Income tracking.
- Expense tracking.
- Finance entries.
- Finance panel.

Tracked transactions now include:

## Income

- Competition prize money.

## Expenses

- Competition entry fees.

The finance system now supports:

- Transaction history.
- Different transaction categories.
- Future recurring costs.

Future expansions:

- Coach salaries
- Facility costs
- Equipment purchases
- Sponsorship income

---

# Competition Registration Improvements

Competition registration was expanded with financial information.

Added:

- Entry fee calculation.
- Individual competition fee display.
- Total registration cost display.
- Current balance display.

Players can now see:

- Cost of entering athletes.
- Total upcoming competition fees.
- Financial impact before competing.

---

# Competition Scheduler Improvements

Improved competition scheduling presentation.

Added:

- Competition registration panels.
- Dynamic competition selection.
- Athlete registration interface.
- Competition fee previews.

Players can now:

1. View upcoming competitions.
2. Select an event.
3. Register athletes.
4. See expected costs.

---

# UI Improvements

## Progress View

Fixed UI layout issues.

Improvements:

- Better alignment.
- Improved readability.
- Cleaner presentation.

---

## Training View

Improved training UI.

Changes:

- Training headers are no longer draggable.
- Improved interaction reliability.

---

# Code Refactoring

## Competition System

Competition logic was expanded and separated into reusable systems.

Added:

- Competition scheduler.
- Competition history storage.
- Competition result persistence.

Competitions now contain:

- Scheduling data.
- Registration data.
- Results.
- Prize information.

---

## Finance Architecture

Created a centralized finance system.

Previously:

- Money changes happened directly in isolated locations.

Now:

- All transactions go through `FinanceManager`.

This creates a foundation for:

- Recurring expenses
- Multiple income sources
- Financial reports
- Economy balancing

---

# Current Gameplay Loop

The gameplay loop is now:

1. Manage athletes
2. Assign training
3. Improve athlete statistics
4. Register athletes for competitions
5. Pay competition entry fees
6. Compete against AI athletes
7. Earn prize money
8. Review competition results
9. Build athlete careers
10. Continue improving the team

---

# Result

Iteration 4 establishes the first real competitive ecosystem.

The game now contains:

- Recurring competitions
- Athlete careers
- Competition history
- Personal records
- Prize money economy
- Entry fees
- Finance tracking
- Improved athlete presentation

These systems provide the foundation for future expansions such as:

- Full facility management
- Coaches and staff
- Sponsorships
- Athlete contracts
- Competition rankings
- Reputation systems
- Advanced economy simulation