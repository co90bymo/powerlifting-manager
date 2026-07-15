## Idea

Introduce AI opponents and the first competitive systems so the player begins competing against the world instead of only managing their own athletes.

This iteration focuses on creating the foundation for future systems:
- AI competition
- Event display
- Basic money tracking
- Improved competition presentation

The systems introduced are intentionally barebones and will be expanded in future iterations.

---

# New Features

## AI Athletes

Added AI-controlled athletes to the game world.

Features:
- AI athletes are generated during new game creation.
- Athlete generation was moved into `NewGameGenerator`.
- AI athletes receive:
    - Name
    - Age
    - Weight
    - Strength statistics
    - Training group data

AI progression was added:

- AI athletes gain strength automatically every week.
- Current progression rate:
    - +1.25kg per lift per week

This creates a competitive world where the player competes against progressing opponents.

---

## Basic Money Foundation

Introduced the first money-related system.

Added:

- Player money balance.

Currently:

- Money cannot be spent.
- There are no shops, upgrades, or expenses.
- Money only exists as a foundation for future finance systems.

The first use of money is competition prize winnings.

---

# Competition Improvements

## AI Competition Participation

Competition simulation was expanded.

Previously:
- Only player athletes participated.

Now:
- Player athletes and AI athletes compete together.

Athletes are still separated by weight class.

---

## Prize Money

Competition prize money was introduced.

Added:

- First place prize
- Second place prize
- Third place prize

Prize money is awarded in:

- Weight class rankings
- Overall rankings

Player athletes who earn prize money contribute winnings to the player balance.

Currently this is only a reward system.
A full economy will be introduced later.

---

## Player Athlete Visual Identification

Competition results were improved.

Added visual differences for player-controlled athletes:

- Player athletes receive a different background color.
- Player athlete names are highlighted.
- Podium positions have additional styling.

Competition results now make it easier to identify:
- Player athletes
- Winners

---

## Competition Notifications

Added a basic competition summary notification.

After competitions, the player receives:

- Total prize money earned.

This creates the first feedback loop after competing.

---

# Scheduler UI Improvements

Added the first version of an event scheduler.

Current functionality:

- Displays upcoming competitions.
- Creates event buttons dynamically.
- Shows competition information.

Competition events display:

- Competition name
- Description
- Prize money information
- Time until competition

The scheduler currently only supports competitions.

Future events will expand this system.

---

# UI Improvements

## Roster View

Fixed roster UI layout issues.

Improvements:

- Fixed squished rows.
- Improved spacing.
- Better readability of athlete information.

---

# Code Refactoring

## NewGameGenerator

Introduced `NewGameGenerator`.

Previously:

- Initial athletes were created directly inside `MainMenuUIManager`.

Now:

- Initial game setup logic is separated.
- Athlete creation is handled in one dedicated system.

This creates a cleaner foundation for future additions such as:

- More AI generation options
- Different starting scenarios
- Custom worlds

---

# Current Gameplay Loop

The current gameplay loop is now:

1. Manage athletes
2. Assign training
3. Advance weeks
4. Improve athletes
5. Compete against AI opponents
6. Earn competition prize money
7. Review competition results
8. Continue building the team

---

# Result

Iteration 3 establishes the first version of a competitive world.

The game now contains:

- Player athletes
- AI opponents
- Competitive events
- Prize rewards
- Basic money tracking
- Event scheduling

These systems are still intentionally simple and serve as the foundation for future expansions such as:

- Full finance management
- Competition calendars
- Reputation systems
- Facilities
- Sponsorships
- More event types