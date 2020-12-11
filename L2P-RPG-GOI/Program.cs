using System;
using System.Collections.Generic;

namespace L2P_RPG_GOI
{
    class Program
    {
        static string WorldName = "Walker High";
        static Player player;
        static Enemy enemy;
        static bool itIsThePlayersTurn;
        static void Main(string[] args)
        {
            //welcome (cool ascii art)
            Welcome();
            //menu
            Menu();
            //create a character
            while (player.CurrentHealth > 0)
                StartFight();
        }

        private static void StartFight()
        {
            Print($"Ready... Fight!");
            enemy = new Enemy(player.Level);
            Print($"A wild {enemy.Type} appears!");
            Print($"Enemy Accuracy-{enemy.Accuracy}%, Strength-{enemy.Strength}, Level-{enemy.Level}, ExperienceAwardedOnDeath-{enemy.ExperienceAwardedOnDeath} ");
            Console.ReadLine();
            itIsThePlayersTurn = false;
            while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                if (itIsThePlayersTurn)
                    PlayerTurn();
                else
                    EnemyTurn();

                itIsThePlayersTurn = !itIsThePlayersTurn;
            }
            //check for dead
            if (player.CurrentHealth < 1)
            {
                var deathPhrases = new List<string> { "YOU DIED", "WASTED", "UNINSTALL", "GIT GUD", "ADIOS MUCHACHO", "ZAK SUX NVR 4 GIT" };
                var random = new Random();
                var fucked = deathPhrases[random.Next(0, deathPhrases.Count)];
                Console.ForegroundColor = ConsoleColor.Red;
                Print($"{ fucked }");
                Console.ResetColor();
            }
        }

        private static void PlayerTurn()
        {
        }

        private static void EnemyTurn()
        {
            Print($"");
            var random = new Random();
            var doesHit = random.Next(0, 100);
            if (doesHit <= enemy.Accuracy)
            {
                //hit player based off enemy strength
                var damage = enemy.Strength / random.Next(8, 13);
                var doesCrit = random.Next(0, 100);
                if (doesCrit < 20)
                {
                    damage = damage * 2;
                    Print($"Critical hit!");
                }
                player.CurrentHealth = player.CurrentHealth - damage;
                Print($"{enemy.Type} hit you for {damage} damage!");
                Print($"Your current health is {player.CurrentHealth}.");
            }
            else
                Print("Enemy swang and missed");
        }

        private static void Welcome()
        {
            Print("Welcome to the game bitch.");
            Print("/////////*******//////////");
            Print("///////attempted//////////");
            Print("/////cool ascii art///////");
            Print("/////////*here**//////////");
            Print("/////////*-----*//////////");
            Print("/////////*******//////////");
        }

        private static void Menu()
        {
            player = new Player();
            player.Name = Prompt("What is your name?");
            player.Class = Prompt("What class are you? (Warrior, Archer, Mage)", new List<string> { "Warrior", "Archer", "Mage" });
            Print("");

            Print($"Welcome to {WorldName} fellow {player.Name}");
            Print($"We have not had a {player.Class} at {WorldName} since the year 2019. Before the storm...of covid");
            Print($"Oh MY!  Look at how strong you are! ******** Strength: {player.Strength}.");
            Print($"Little dexterious dick bro are you! ******** Dexterity: {player.Dexterity}.");
            Print($"You are sooooo smart!........       ******** Intellect: {player.Intellect}.");

            Print("");
            Print($"Congratulations.  You have created your character.  Enjoy the world of {WorldName}.");
            Print($"Health: {player.MaxHealth}, Experience: {player.ExperiencePoints}, Level: {player.Level}");
        }

        private static string Prompt(string promptThis)
        {
            string input = "";
            //check to see if they put anything in
            while (input.Trim().Length <= 0)
            {
                //tell them to put something in.
                Print(promptThis);
                //let them input something
                input = Console.ReadLine();
            }
            //return the something
            return input;
        }

        private static string Prompt(string promptThis, List<string> expectedResponses)
        {
            var input = Prompt(promptThis);

            while (!expectedResponses.Contains(input))
            {
                input = Prompt($"Choose from: {string.Join(",", expectedResponses)}");
            }
            return input;
        }

        private static void Print(string line)
        {
            Console.WriteLine(line);
        }
    }
}
