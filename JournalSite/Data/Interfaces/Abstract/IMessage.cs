using JournalSite.Data.Entities;

namespace JournalSite.Data.Interfaces.Abstract
{
    public interface IMessage
    {
        IQueryable<Message> GetMessagesByGroupName(string groupName);
        void SaveMessage(Message model);
    }
}
