class Competition:
    def __init__(self, name, weeks_due):
        self.name = name
        self.weeks_due = weeks_due
        self.athletes = []

    def enlist(self, athlete):
        self.athletes.append(athlete)

    def compete(self):
        print(f"\nWelcome to {self.name}!")
        for athlete in self.athletes:
            lifted = athlete.lift(1)
            print(f"\n{athlete.name} lifted {lifted}kg on his first attempt.")

            lifted = athlete.lift(2)
            print(f"{athlete.name} lifted {lifted}kg on his second attempt.")

            lifted = athlete.lift(3)
            print(f"{athlete.name} lifted {lifted}kg on his third attempt.")
        print("\nThank you for watching!")

    def reduce_weeks(self, amount):
        self.weeks_due -= amount
        if self.weeks_due == 0:
            self.compete()


        