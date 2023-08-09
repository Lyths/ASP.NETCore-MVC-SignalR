using JournalSite.Data.Entities;

namespace JournalSite.Data.Interfaces.Abstract
{
    public interface IGroup
    {
        IQueryable<Group> GetGroupsByUserNameMod(string username);
        IQueryable<Group> GetGroupsByUserNameUs(string username);
        int GetCountGroupsByUserName(string userName);
        void SaveGroup (Group group);
        bool AnyGroup();
    }
}
