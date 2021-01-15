using Discord.Commands;
using L2P_RPG_GOI.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace L2P_RPG_GOI.Discord.Modules
{
    // Keep in mind your module **must** be public and inherit ModuleBase.
    // If it isn't, it will not be discovered by AddModulesAsync!
    
    public class GameModule : ModuleBase<SocketCommandContext>
    {
        // ~say hello world -> hello world
        [Command("welcome")]
        [Summary("Echoes a message.")]
        public Task Welcome()
        {
            var welcomeMessages = new List<string>();
            welcomeMessages.Add("Welcome to the game bitch.");
            welcomeMessages.Add("/////////*******//////////");
            welcomeMessages.Add("///////attempted//////////");
            welcomeMessages.Add("/////cool ascii art///////");
            welcomeMessages.Add("/////////*here**//////////");
            welcomeMessages.Add("/////////*-----*//////////");
            welcomeMessages.Add("/////////*******//////////");
            welcomeMessages.Add("**bold**");
            welcomeMessages.Add("*italics*");
            welcomeMessages.Add("***bold Italics***");
            welcomeMessages.Add("__underline__");
            welcomeMessages.Add("Welcome to the game bitch.");

            var formattedMessage = PrintHelpers.FormatMultipleStringsToMultilineString(welcomeMessages);
            return ReplyAsync(formattedMessage);
        }
    }
}
