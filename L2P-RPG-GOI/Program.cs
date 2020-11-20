using System;

namespace L2P_RPG_GOI
{
    class Program
    {
        static string WorldName = "Ghrothban";
        static void Main(string[] args)
        {
            //welcome (cool ascii art)
            Welcome();
            //menu
            Menu();
                //create a character
        }

        private static void Welcome()
        {
            Print("Welcome to the game bitch.");
            Print("///////*******////////");
            Print("///////****///////////");
            Print("///////*///***////////");
            Print("///////*******////////");
            Print("///////*-----*////////");
            Print("///////*******////////");
        }

        private static void Menu()
        {
            var player = new Player();
            player.Name = Prompt("What is your name?");
            player.Class = Prompt("What class are you?  (Warrior, Archer, Mage)");

            Print($"Welcome to {WorldName} fellow {player.Name}");
            Print($"We have not had a {player.Class} at {WorldName} since the year 2019. Before the storm...of covid");
            Print($"Oh MY!  Look at how strong you are! ******** Strength: {player.Strength}.");
            Print($"Little dexterious dick bro are you! ******** Dexterity: {player.Dexterity}.");
            Print($"You are sooooo smart!........       ******** Intellect: {player.Intellect}.");

            Print("");
            Print($"Congratulations.  You have created your character.  Enjoy the world of {WorldName}.");
            Print($"Health: {player.Health}, Experience: {player.ExperiencePoints}, Level: {player.Level}");
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

        private static void Print(string line)
        {
            Console.WriteLine(line);
        }
    }
}
