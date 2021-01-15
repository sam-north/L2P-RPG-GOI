using Discord.Commands;
using L2P_RPG_GOI.DataAccess;
using L2P_RPG_GOI.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L2P_RPG_GOI.Discord.Modules
{
    // Keep in mind your module **must** be public and inherit ModuleBase.
    // If it isn't, it will not be discovered by AddModulesAsync!

    [Group("character")]
    public class CharacterModule : ModuleBase<SocketCommandContext>
    {
        [Command("create")]
        [Summary("creates a character.")]
        public Task Create(string playerName, string playerClass)
        {
            var messages = new List<string>();

            //conntect to the database
            var entityContext = new EntityContext();

            //queried for database class entity.
            var databaseClass = entityContext.Classes.Single(x => x.Name == playerClass);

            //create our player in code
            var player = new Player(playerName, databaseClass);
            //save our player to the database
            entityContext.Players.Add(player);
            entityContext.SaveChanges();

            //gg? message the user with feedback
            messages.Add("You created a player!");
            messages.Add("Your player id is " + player.Id);

            var formattedMessage = PrintHelpers.FormatMultipleStringsToMultilineString(messages);
            return ReplyAsync(formattedMessage);
        }


        [Command("list")]
        [Summary("creates a character.")]
        public Task List()
        {
            var messages = new List<string>();

            //connect to the database.
            var entityContext = new EntityContext();

            //query for characters
            var players = entityContext.Players.ToList();

            //add characters to our message list variable
            foreach (var player in players)
            {
                messages.Add(player.Name);
            }

            //format message and print to discord
            var formattedMessage = PrintHelpers.FormatMultipleStringsToMultilineString(messages);
            return ReplyAsync(formattedMessage);
        }
    }
}
