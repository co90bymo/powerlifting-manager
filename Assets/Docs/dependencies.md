# Dependency Map

---

## 1. Core Systems

## UIManager

Depends on:
- RosterUI (to refresh roster display)
- GameTime (via GameState)
- UI panels (Gym Panel, Roster Panel)

Used by:
- UI Buttons (Roster, Back to Gym)

Responsibilities:
- Panel switching (Gym ↔ Roster view)

---

## SlotButton

Depends on:
- SaveManager (via GameManager) 

Used by:
- DeleteButton
- Slot Selection Panel

Responsibilities:
- Displays save slot state (Game / Slot text)

---

## SceneLoader

Depends on:
- /

Used by:
- /

Responsibilities:
- Handles scene transitions

---

### Roster
Depends on:
- Athlete 
- TrainingResult

Used by:
- GameState
- Gym UI (display roster)

---

### SaveManager
Depends on:
- GameState 

Used by:
- MainMenuUIManager (via GameManager)
- SlotButtons (via GameManager)
- DeleteButton (via GameManager)


Used for:
- Storing and Loading GameStates
- Save slot management

---
### RosterUI
Depends on:
- Roster Text (TMP - not a self reference!)  
- PlayerRoster (via GameManager) 

Used by:
- UIManager

Used for:
- Displays Roster in Roster Text 

---
### MainMenuUIManager
Depends on:
- UI-Objects (Main Menu Panel, Slot Selection Panel, New Game Panel)
- SaveManager (via GameManager)
- PlayerRoster (via GameManager)
- GameState (via GameManager)
- Athlete
- AthleteButton
- GameManager

Used by:
- /

Used for:
- Manage switching between Panels in Main Menu

---
### GameState
Depends on:
- Roster
- GameTime

Used by:
- MainMenuUIManager (via GameManager)
- SaveManager
- GameManager

Used for:
- Storing the games state

---
### GameManager
Depends on:
- GameState 
- SaveManager 
- PlayerRoster  (via CurrentState)
- TrainingResult

Used by:
- SlotButtons 
- MainMenuUIManager
- AdvanceWeekDoneButton (Saving Game)
- WeekSummaryUI

Used for:
- Instantiates important Game Objects
- Hub for some important functions (StartNewGame() and LaodGame())

---
### DeleteButton
Depends on:
- SaveManager (via GameManager)
- SlotButton

Used by:
- /

Used for:
-  Deletes a save state

---
### Athlete
Depends on:
- TrainingResult

Used by:
- Roster
- MainMenuUIManager
- AthleteButton

Used for:
-  Class to model Athletes

---
### AthleteButton
Depends on:
- Athlete
- MainMenuUIManager

Used by:
- MainMenuUIManager

Used for:
-  Toggle Selection when starting a new game

--- 
### GameTime
Depends on:
- /

Used by:
- GameState
- UIManager
- GameManager

Used for:
- Keeps track of game time in week/year

---
## AdvanceWeekDoneButton

Depends on:
- GameManager

Used by:
- 

Used for:
- Progressing time 
- Autosaving
---
## AdvanceWeekButton

Depends on
- GameManager

Used by:
- 

Used for:
- Calls simulation step inside GameManager
- Train Athletes in PlayerRoster

--- 
## WeekSummaryUI

Depends on
- GameManager
- TrainingResult

Used by:
- 

Used for:
- Populates the progress summary scroll view
- Handles all other UI (currently only the advance button)

--- 
## TrainingResult

Depends on
- 

Used by:
- WeekSummaryUI
- Athlete
- GameManager
- Roster

Used for:
- Provides structure to store weekly progress

--- 


## 2. Soring and Loading Flow

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

## 3. Risk Areas 

- UI modifying GameState directly 
- Multiple systems writing to GameState 
- SaveManager containing game logic 
- GameState becoming too large (future risk) 

---

## 4. Rules

- GameManager is the only entry point for state changes
- GameState is the single source of truth
- UI never stores permanent data
- SaveManager only reads/writes data, never modifies gameplay