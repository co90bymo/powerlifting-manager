

## Goal

Expand the core gameplay loop by introducing meaningful player decisions through training intensity, fatigue management, and a more realistic competition system based on weight classes.

This iteration focuses on making the management aspect more engaging while laying the foundation for future gameplay systems.

---

## Completed Features

### Training Groups

Introduced selectable training intensity for every athlete.

Available training groups:

- Unassigned
    
- Light
    
- Normal
    
- Heavy
    

Players can now freely assign athletes to different training groups using drag-and-drop.

Each training group affects:

- Strength progression
    
- Fatigue gain
    

This transforms training from an automatic process into a player-driven decision.

---

### Fatigue System

Added a fatigue mechanic to represent athlete recovery.

Features:

- Athletes accumulate fatigue from training.
    
- Different training groups generate different fatigue levels.
    
- Athletes recover fatigue when left Unassigned.
    
- Fatigue is limited to a defined range.
    
- Athletes cannot perform training sessions that require more fatigue than they currently have available.
    

This introduces the first resource management mechanic into the game.

---

### Athlete Information

Expanded athlete data.

Athletes now track:

- Age
    
- Weight
    
- Fatigue
    

Roster UI was updated to display all newly added information.

---

### Weight Classes

Introduced official powerlifting weight classes.

Supported classes:

- 52 kg
    
- 56 kg
    
- 60 kg
    
- 67.5 kg
    
- 75 kg
    
- 82.5 kg
    
- 90 kg
    
- 100 kg
    
- 110 kg
    
- 125 kg
    
- 140 kg
    
- 140+ kg (Super Heavyweight)
    

Each athlete is automatically assigned to a weight class based on bodyweight.

---

### Competition Improvements

Competition simulation has been completely redesigned.

New features:

- Athletes compete only against athletes in the same weight class.
    
- Individual placings are assigned within every weight class.
    
- Added DOTS score calculation.
    
- Added an overall competition ranking based on DOTS.
    
- Competition results now include:
    
    - Weight class placing
        
    - Overall placing
        
    - DOTS score
        
    - Total
        
    - Individual lifts
        

---

### Competition UI

Competition presentation received a significant overhaul.

Added:

- Weight class selection
    
- Overall DOTS ranking view
    
- Weight class filtering
    
- Ranking column
    
- Athlete age
    
- Athlete weight
    
- DOTS score
    
- Improved competition notification
    
- Competition welcome screen
    

Players can now switch between:

- Overall results
    
- Individual weight class results
    

without rerunning the competition.

---

### Weekly Progress Improvements

Weekly progress screen now displays:

- Squat change
    
- Bench change
    
- Deadlift change
    
- Total strength change
    
- Fatigue change
    

Positive and negative values are displayed with appropriate formatting.

---

### Training UI Improvements

Improved the training interface.

Added:

- Named training sections
    
- Visual feedback for training groups
    
- Athlete card color changes depending on assigned training group
    
- Better athlete organization
    

These changes make training assignments much easier to understand at a glance.

---

### Gym UI

Reworked the main Gym screen.

Improvements include:

- Cleaner top navigation
    
- Better button layout
    
- Improved spacing and alignment
    
- More scalable interface structure for future systems
    

The layout now serves as a foundation for future additions such as facilities, finances, notifications, and reputation.

---

# Result

The gameplay loop has evolved from a passive simulation into a management game where the player makes meaningful weekly decisions.

Current gameplay flow:

1. Review athlete roster
    
2. Assign training intensity
    
3. Manage athlete fatigue
    
4. Advance week
    
5. Review weekly progression
    
6. Participate in competitions
    
7. Review overall and weight class rankings
    
8. Continue long-term athlete development
    

This iteration establishes the core management mechanics that future gameplay systems will build upon.