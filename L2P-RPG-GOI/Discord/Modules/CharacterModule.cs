using Discord.Commands;
using L2P_RPG_GOI.DataAccess;
using L2P_RPG_GOI.Helpers;
using L2P_RPG_GOI.Models;
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

            var userHelper = new UserHelper();
            var user = userHelper.GetOrCreateUser(Context.User);

            //queried for database class entity.
            var databaseClass = entityContext.Classes.SingleOrDefault(x => x.Name == playerClass);
            if (databaseClass == null)
            {
                messages.Add($"Invalid class specified {user.Username}.");
                messages.Add("Expecting (Warrior, Archer, Mage)");
                return ReplyAsync(PrintHelpers.FormatMultipleStringsToMultilineString(messages));
            }

            //create our player in code
            var character = new Character(playerName, databaseClass);
            character.UserId = user.Id;
            //save our player to the database
            entityContext.Characters.Add(character);
            entityContext.SaveChanges();

            //gg? message the user with feedback
            messages.Add("You created a character!");
            messages.Add("Your character id is " + character.Id);

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
            var players = entityContext.Characters.ToList();

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
