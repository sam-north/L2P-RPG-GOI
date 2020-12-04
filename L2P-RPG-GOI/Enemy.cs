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
            CurrentHealth = MaxHealth;

            ExperienceAwardedOnDeath = random.Next(1, Level * 2 + 1);
            Strength = random.Next(0, 100);
            Accuracy = random.Next(0, 100);
            Type = Types[random.Next(0, Types.Count + 1)];
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

        private List<string> Types = new List<string> { "ogre", "troll", "beast", "ben" };
    }
}
