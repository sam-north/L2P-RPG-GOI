using System;

namespace Game
{
    public class Player
    {
        public Player()
        {
            CreateCharacter();
        }

        public Player(string playerName, string playerClass)
        {
            Name = playerName;
            Class = playerClass;
            CreateCharacter();
        }

        public string Name { get; set; }
        public string Class { get; set; }

        public int Health { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intellect { get; set; }

        private void CreateCharacter()
        {
            Health = 100;
            ExperiencePoints = 0;
            Level = 1;

            var random = new Random();
            Strength = random.Next(0, 101);
            Dexterity = random.Next(0, 101);
            Intellect = random.Next(0, 101);
        }
    }
}