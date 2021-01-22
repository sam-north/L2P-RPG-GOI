using L2P_RPG_GOI.DataAccess;
using L2P_RPG_GOI.Models;
using System;

namespace L2P_RPG_GOI.Helpers
{
    public class MessageAuditHelper
    {
        public void CreateLog(int userId, string message)
        {
            var entityContext = new EntityContext();
            var messageAudit = new MessageAudit();
            messageAudit.Time = DateTimeOffset.Now;
            messageAudit.UserId = userId;
            messageAudit.Message = message;

            entityContext.MessageAudits.Add(messageAudit);
            entityContext.SaveChanges();
        }
    }
}
