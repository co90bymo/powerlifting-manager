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
- Advance Week (Button) → Advance Week Scene (This will trigger the simulation step, the summary of that will be displayed inside the Advance Week Scene)
- (Schedule Button exists, it's the Date display button - Schedule class will be added later, so currently it's just displaying the current Date)

---

## 4. Advance Week Scene

### Panels / States:

- Week Summary Panel (Only pannel, so it also contains the "done button" for now)
- Notification Panel (Only in Week 1)
- Competition Panel (Only when there is competition

 Notification/ Competition -> Week Summary Panel -> The Gym Scene 

### Actions:

- Display the weekly progress
- Display Competitions
- Done (Button) → Advance Week Scene to The Gym Scene (and AutoSave)



---

## 5. Soring and Loading Flow

### Save Flow
UI → GameManager → GameState → SaveManager → File

---

### Load Flow
File → SaveManager → GameState → GameManager → UI

---

### Where can player save a game?
- Automatically when new game starts
- Automatically after each week

---

## 6. Risk Areas 

- UI modifying GameState directly 
- Multiple systems writing to GameState 
- SaveManager containing game logic 
- GameState becoming too large (future risk) 

---

## 7. Rules

- GameManager is the only entry point for state changes
- GameState is the single source of truth
- UI never stores permanent data
- SaveManager only reads/writes data, never modifies gameplay