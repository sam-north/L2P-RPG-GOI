using System;

namespace L2P_RPG_GOI
{
    public class Player
    {
        public Player(string name, string playerClass)
        {
            Name = name;
            Class = new Class(playerClass);
            ExperiencePoints = 0;
            CurrentHealth = MaxHealth;
            ActionPoints = 10;

            var random = new Random();
            if (Class.Name == "Warrior")
            {
                Dexterity = random.Next(35, 66);
                Intellect = random.Next(0, 11);
                Strength = random.Next(70, 101);
            }
            else if (Class.Name == "Archer")
            {
                Dexterity = random.Next(70, 101);
                Intellect = random.Next(35, 66);
                Strength = random.Next(45, 80);
            }
            else if (Class.Name == "Mage")
            {
                Dexterity = random.Next(35, 66);
                Intellect = random.Next(70, 101);
                Strength = random.Next(0, 11);
            }
        }

        public string HairColor { get; set; } //syntactic sugar (easier to type and shit)

        public string Name { get; set; }
        public Class Class { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level
        {
            get
            {
                if (ExperiencePoints > 100)
                    return 10;
                else if (ExperiencePoints > 85)
                    return 9;
                else if (ExperiencePoints > 70)
                    return 8;
                else if (ExperiencePoints > 60)
                    return 7;
                else if (ExperiencePoints > 45)
                    return 6;
                else if (ExperiencePoints > 35)
                    return 5;
                else if (ExperiencePoints > 25)
                    return 4;
                else if (ExperiencePoints > 15)
                    return 3;
                else if (ExperiencePoints > 5)
                    return 2;
                else
                    return 1;
            }
        }
        public int MaxHealth
        {
            get
            {
                return Level * 100;
            }
        }
        public int CurrentHealth { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intellect { get; set; }
        public int ActionPoints { get; set; }
    }
}