
# Iteration 1 - Main Game Loop

## Goal

Create the first complete gameplay loop where the player can progress time, train athletes, run competitions, and view results.

---

## Completed Features

### Time Progression

- Added a basic time system.
- The game now tracks weeks and years.
- Players can advance time through the main game loop.
- Current date is displayed in the UI.

---

### Athlete System

- Athletes now have strength values:
  - Squat
  - Bench
  - Deadlift

- Added athlete training progression.
- Athletes gain strength when advancing a week.
- Added basic competition attempt strategy.

---

### Competition System

- Added competitions.
- Competitions can be scheduled for specific weeks.
- Added basic competition simulation.

Current competition format:

- All roster athletes participate.
- Each athlete gets:
  - 3 Squat attempts
  - 3 Bench attempts
  - 3 Deadlift attempts

- Results are calculated and ranked by total weight lifted.

---

### Weekly Progress Summary

Added a weekly summary screen displaying:

- Current date
- Athlete progression after training:
  - Squat gains
  - Bench gains
  - Deadlift gains
  - Total progress

---

### Roster System

Added a roster view displaying:

- Athlete names
- Squat values
- Bench values
- Deadlift values

Added:

- Scrollable roster list
- Column filtering
- Reusable athlete row display

---

### Competition Results

Added competition result display:

- Athlete rankings
- Best lifts
- Total weight lifted

---

### Save System

Added automatic saving after weekly progression.

The game now preserves:

- Athlete progress
- Current date
- Scheduled competitions
- Overall game state

---

### UI Improvements

Improved UI scaling and responsiveness.

Added:

- Proper anchors
- Better layout handling
- ScrollView improvements
- Resolution-independent positioning

---

# Result

The game now has a complete basic management loop:

1. Start game
2. View roster
3. Advance week
4. Athletes train
5. Review progress
6. Save game
7. Run competitions
8. Review results