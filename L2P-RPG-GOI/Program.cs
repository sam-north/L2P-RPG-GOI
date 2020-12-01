using Game;
using System;
using System.Collections.Generic;

namespace L2P_RPG_GOI
{
    class Program
    {
        static RPG game = new RPG();
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
            Print(game.WelcomeGame());
        }

        private static void Menu()
        {
            var prompts = game.CreatePlayerPrompts();
            var promptAnswers = Prompt(prompts);

            game.CreatePlayer(promptAnswers[prompts[0]], promptAnswers[prompts[1]]);
            Print(game.WelcomePlayer());
        }
        private static Dictionary<string, string> Prompt(IEnumerable<string> prompts)
        {
            var results = new Dictionary<string, string>();
            foreach (var promptThis in prompts)
                results.Add(promptThis, Prompt(promptThis));
            return results;
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

        private static void Print(IEnumerable<string> lines)
        {
            foreach (var line in lines)
                Print(line);
        }
    }
}
