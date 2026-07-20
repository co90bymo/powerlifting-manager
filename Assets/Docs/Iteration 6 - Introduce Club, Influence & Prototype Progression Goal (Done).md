
## Idea

Transform the player from managing only individual athletes into building and managing a growing organization.

This iteration focuses on introducing:

- Club identity
    
- Reputation / Influence progression
    
- Competition access progression
    
- Better connection between results and long-term growth
    
- Improved training consequences
    

The systems introduced are intentionally simple and designed as foundations for future expansions such as:

- Sponsors
    
- Coaches
    
- Scouting
    
- Athlete recruitment
    
- Licenses
    
- Club development
    
- Advanced progression systems
    

---

# New Features

# Club System

Introduced the first version of organization identity.

Previously:

- The player mainly managed athletes.
    
- The organization existed only indirectly.
    

Now:

- The player has a club.
    
- The club has its own progression value.
    
- Future management systems have a dedicated foundation.
    

---

## Club Architecture

Created the first `Club` structure.

Added:

- Club name.
    
- Basic club information.
    
- Club reputation value.
    

The system is prepared for future additions such as:

- Staff.
    
- Facilities.
    
- Sponsors.
    
- Scouting.
    
- Club upgrades.
    

---

# Influence / Reputation System

Introduced reputation as the main progression currency.

Previously:

- Competition results only provided immediate rewards.
    

Now:

- Results contribute to long-term organization growth.
    
- The club can unlock access to higher-level opportunities.
    

Added:

- Centralized reputation tracking.
    
- Reputation gain from competition results.
    
- Reputation display in UI.
    

---

## Reputation Usage

Reputation now affects:

- Competition accessibility.
    
- Future progression paths.
    

Future expansions:

- Athlete attraction.
    
- Sponsors.
    
- Club growth.
    
- Competition tiers.
    

---

# Competition Integration

Competitions now support reputation requirements.

Added:

- Minimum reputation requirements.
    
- Entry restrictions.
    
- Visual feedback when requirements are not met.
    

Previously:

- All competitions were available.
    

Now:

- Higher-level competitions can be locked behind progression.
    

---

## Competition Requirement UI

Added reputation information to:

- Competition selection panel.
    
- Competition schedule information.
    

Players can now see:

- Required reputation.
    
- Current reputation.
    
- Whether they are eligible to participate.
    

Locked competitions are visually displayed as unavailable.

---

# Progression Goal Prototype

Created the first progression path.

Added:

- Beginner competition without requirements.
    
- Higher-level competition requiring reputation.
    

The structure now supports a simple progression loop:

1. Enter available competitions.
    
2. Achieve good results.
    
3. Gain reputation.
    
4. Unlock better competitions.
    

---

# Training Improvements

Improved the connection between training decisions and competition performance.

---

## Fatigue Recovery

Added fatigue reduction through lighter training.

Light training now helps athletes recover before competitions.

This creates the foundation for:

- Deloading.
    
- Competition preparation.
    
- Future peak condition systems.
    

---

## Fatigue Competition Impact

Fatigue now affects competition performance.

Previously:

- Fatigue only limited training choices.
    

Now:

- Training decisions have consequences during competitions.
    

The gameplay loop now includes:

Training choice → Fatigue → Competition performance → Results

---

# UI Improvements

Added reputation information throughout competition-related screens.

Players can now understand:

- Why competitions are unavailable.
    
- How much reputation is required.
    
- How competition results contribute to progression.
    

---

# Code Architecture Improvements

## Reputation System

Created a centralized reputation system.

The system now supports:

- Reputation gains.
    
- Reputation requirements.
    
- Future progression mechanics.
    

---

## Competition Expansion

Competitions now support additional progression data:

- Reputation requirements.
    
- Entry restrictions.
    
- Future qualification systems.
    

---

# Current Gameplay Loop

The gameplay loop is now:

1. Manage club athletes.
    
2. Assign training.
    
3. Balance progression and fatigue.
    
4. Enter available competitions.
    
5. Achieve results.
    
6. Gain reputation.
    
7. Unlock higher-level competitions.
    
8. Grow the organization.
    

---

# Result

Iteration 6 introduces the first true progression system.

The game now contains:

- Club identity.
    
- Reputation progression.
    
- Competition requirements.
    
- Locked progression paths.
    
- Better training consequences.
    
- Stronger connection between preparation and results.
    

These systems provide the foundation for future expansions such as:

- Athlete recruitment.
    
- Licenses and qualifications.
    
- Sponsors.
    
- Staff management.
    
- Club development.
    
- Advanced competition tiers.