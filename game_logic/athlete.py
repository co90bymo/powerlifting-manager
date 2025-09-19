import math

class Athlete:
    def __init__(self, name, base_strength):
        self.name = name
        self.base_strength = base_strength
        self.xp = 0
        self.team = None

    def calculate_1RM(self):
        val = self.base_strength * self.xp * 1/6
        if val < self.base_strength:
            val = self.base_strength 
        return val    

    def lift(self, attempt):
        if attempt == 1:
            value = self.calculate_1RM() * 0.91
            rounded = math.floor(value * 2) / 2
            return rounded
        elif attempt == 2:
            value = self.calculate_1RM() * 0.96
            rounded = math.floor(value * 2) / 2
            return rounded
        elif attempt == 3:
            value = self.calculate_1RM()
            rounded = math.floor(value * 2) / 2
            return rounded
        
    def gainXP(self, amount):
        self.xp += amount
        
        