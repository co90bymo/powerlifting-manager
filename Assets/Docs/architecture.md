# Game Loop Structure

---

## 1. Scene Loop (High-Level Flow)

MainMenu
    ↕
The Gym
    ↕
Advance Week

---

## 2. Main Menu Scene

### Panels / States:

- Main Menu Panel
    ↕
- Slot Selection Panel
    ↕
- New Game Panel

### Transitions:

- Start New Game (Button) → Slot Selection → New Game Panel | The Gym

---

## 3. The Gym Scene

### Panels / States:

- Gym Panel (default gameplay view)
	↕
- Roster Panel 

### Actions:

- View roster
- Advance Week (Button) → Advance Week Scene

---

## 4. Advance Week Scene

### Panels / States:

-  None

### Actions:

- Done (Button) → Advance Week Scene