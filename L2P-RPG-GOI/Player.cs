using System;

namespace L2P_RPG_GOI
{
    public class Player
    {
        public Player()
        {
            ExperiencePoints = 0;
            CurrentHealth = MaxHealth;

            var random = new Random();
            Strength = random.Next(1, 101);
            Dexterity = random.Next(0, 101);
            Intellect = random.Next(0, 101);
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level
        {
            get {
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
    }
}