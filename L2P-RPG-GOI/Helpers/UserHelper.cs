using Discord.WebSocket;
using L2P_RPG_GOI.DataAccess;
using L2P_RPG_GOI.Models;
using System.Linq;

namespace L2P_RPG_GOI.Helpers
{
    public class UserHelper
    {
        internal User GetOrCreateUser(SocketUser socketUser)
        {
            var entityContext = new EntityContext();

            //figure out if the user that typed a command for our app exists.
            var existingUser = entityContext.Users.SingleOrDefault(x => x.DiscordUserId == socketUser.Id);
            //if not, create
            if (existingUser == null)
            {
                var user = new User();
                user.DiscordUserId = socketUser.Id;
                user.Discriminator = socketUser.Discriminator;
                user.Username = socketUser.Username;

                entityContext.Users.Add(user);
                entityContext.SaveChanges();

                return user;
            }
            //if so...get the userid  and pass it to the command.
            else
            {
                return existingUser;
            }
        }
    }
}
