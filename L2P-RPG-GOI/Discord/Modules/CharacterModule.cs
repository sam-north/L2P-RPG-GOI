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
            var userHelper = new UserHelper();
            var user = userHelper.GetOrCreateUser(Context.User);
            var players = entityContext.Characters.ToList().Where(x => x.UserId == user.Id).ToList();

            //add characters to our message list variable
            foreach (var player in players)
            {
                messages.Add(player.Name);
            }

            //format message and print to discord
            var formattedMessage = PrintHelpers.FormatMultipleStringsToMultilineString(messages);
            return ReplyAsync(formattedMessage);
        }


        [Command("login")]
        [Summary("login to character")]
        public Task Login(string characterName)
        {
            //Determine who's logging in.
            var userHelper = new UserHelper();
            var user = userHelper.GetOrCreateUser(Context.User);
            var messages = new List<string>();

            //Check database for character for this user.
            var entityContext = new EntityContext();
            var databaseCharacter = entityContext.Characters.SingleOrDefault(u => u.UserId == user.Id && u.Name == characterName);
            if (databaseCharacter == null)
            {
                messages.Add($"You don't have a character named {characterName}, {user.Username}.");
                messages.Add("Get your shit together.");
                return ReplyAsync(PrintHelpers.FormatMultipleStringsToMultilineString(messages));
            }
            //Set currently active character inactive.
            var activeCharacter = entityContext.Characters.SingleOrDefault(u => u.UserId == user.Id && u.Active == true);
            if (activeCharacter != null)
                activeCharacter.Active = false;

            //Set character to active.
            databaseCharacter.Active = true;
            entityContext.SaveChanges();
            messages.Add($"You are now logged in as {characterName}, {user.Username}.");

            var formattedMessage = PrintHelpers.FormatMultipleStringsToMultilineString(messages);
            return ReplyAsync(formattedMessage);

        }
    }
}
