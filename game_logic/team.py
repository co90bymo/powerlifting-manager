class Team:
    def __init__(self, name):
        self.name = name
        self.athletes = []

    def add_athlete(self, athlete):
        self.athletes.append(athlete)

    def remove_athlete(self, athlete):
        self.athletes.remove(athlete)

        