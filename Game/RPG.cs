using System.Collections.Generic;

namespace Game
{
    public class RPG
    {
        string WorldName = "Ghrothban";
        Player player;
        public List<string> WelcomeGame()
        {
            var messages = new List<string>();
            messages.Add("Welcome to the game bitch.");
            messages.Add("/////////*******//////////");
            messages.Add("/////////****/////////////");
            messages.Add("/////////*///***//////////");
            messages.Add("/////////*******//////////");
            messages.Add("/////////*-----*//////////");
            messages.Add("/////////*******//////////");
            return messages;
        }

        public List<string> CreatePlayerPrompts()
        {            
            var prompts = new List<string>();
            prompts.Add("What is your name?");
            prompts.Add("What class are you?  (Warrior, Archer, Mage)");
            return prompts;
        }

        public void CreatePlayer(string playerName, string playerClass)
        {
            player = new Player(playerName, playerClass);
        }

        public List<string> WelcomePlayer()
        {
            var messages = new List<string>();

            messages.Add($"Welcome to {WorldName} fellow {player.Name}");
            messages.Add($"We have not had a {player.Class} at {WorldName} since the year 2019. Before the storm...of covid");
            messages.Add($"Oh MY!  Look at how strong you are! ******** Strength: {player.Strength}.");
            messages.Add($"Little dexterious dick bro are you! ******** Dexterity: {player.Dexterity}.");
            messages.Add($"You are sooooo smart!........       ******** Intellect: {player.Intellect}.");
            messages.Add("");
            messages.Add($"Congratulations.  You have created your character.  Enjoy the world of {WorldName}.");
            messages.Add($"Health: {player.Health}, Experience: {player.ExperiencePoints}, Level: {player.Level}");

            return messages;
        }
    }
}
