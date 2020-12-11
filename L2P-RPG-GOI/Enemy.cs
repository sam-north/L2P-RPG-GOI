using System;
using System.Collections.Generic;

namespace L2P_RPG_GOI
{
    public class Enemy
    {
        public Enemy(int playerLevel)
        {
            Random random = new Random();
            Level = random.Next(playerLevel - 1, playerLevel + 2);
            if (Level == 0)
                Level = 1;

            CurrentHealth = MaxHealth;

            ExperienceAwardedOnDeath = random.Next(1, Level * 2 + 1);
            Accuracy = random.Next(55, 95);

            var randomTypeIndex = random.Next(0, Types.Count);
            Type = Types[randomTypeIndex];

            if (Type == "troll")
                Strength = random.Next(70, 100);
            else if (Type == "beast")
                Strength = random.Next(50, 80);
            else if (Type == "flower")
                Strength = random.Next(25, 60);
            else if (Type == "cary")
                Strength = random.Next(1, 10);
        }

        public string Type { get; set; } // ogre, troll, beast
        public string Name { get; set; } //timmy

        public int MaxHealth
        {
            get
            {
                return Level * 100;
            }
        }
        public int CurrentHealth { get; set; }
        public int Level { get; set; }
        public int ExperienceAwardedOnDeath { get; set; }
        public int Strength { get; set; }
        public int Accuracy { get; set; }

        private List<string> Types = new List<string> { "troll", "beast", "flower", "cary" };
    }
}
