from game_logic.athlete import Athlete
from game_logic.competition import Competition
import time

class GameController:
    def __init__(self):
        # TODO: initialize game state
        self.current_week = 1
        self.teams = []
        self.competitions = []
        self.athletes = []

    def start_game(self):
        print("Start Game")
        time.sleep(0.5)
        print("Generate Athletes and Competitions")
        time.sleep(1)
        alex = Athlete(name="Alex", base_strength=60)
        ben = Athlete(name="Ben", base_strength=50)
        self.athletes.append(alex)
        self.athletes.append(ben)

        test_competition = Competition(name="Test Competition", weeks_due=4)
        self.competitions.append(test_competition)
        
        intermediate_competition = Competition(name="Intermediate Competition", weeks_due=8)
        self.competitions.append(intermediate_competition)

        print("Week 1")
        # Print athletes
        print("Athletes in the game:")
        for athlete in self.athletes:
            print(f"- {athlete.name} (Base Strength: {athlete.base_strength} kg)")
            test_competition.enlist(athlete)
            intermediate_competition.enlist(athlete)

        # Print upcoming competition(s)
        print("\nUpcoming Competition(s):")
        for comp in self.competitions:
            print(f"- {comp.name} (In {comp.weeks_due} weeks)")

        input("\nPress Enter to progress a week (or Ctrl+C to quit)...")
        self.progress_week()

    def progress_week(self):
        print("____________________________________________________________________")


        if self.current_week == 10:
            print("You finished the demo! Thanks for playing")
            return
        
        print("A week passed")
        self.current_week += 1
        print(f"Current Week: {self.current_week}")

        for athlete in self.athletes:
            athlete.gainXP(1)
    
        # Catch finished competitions and delete them after.
        # Otherwise it will cause a bug where the other competitions will not reduced their weeks_due attribute the following week
        finished = []
        for competition in self.competitions:
            competition.reduce_weeks(amount=1)
            if competition.weeks_due <= 0:
                finished.append(competition)

        for competition in finished:
            self.competitions.remove(competition)

        # Print upcoming competition(s)
        print("\nUpcoming Competition(s):")
        for comp in self.competitions:
            print(f"- {comp.name} ({comp.weeks_due} Weeks)")
        
        input("\nPress Enter to progress a week (or Ctrl+C to quit)...")
        self.progress_week()

        
