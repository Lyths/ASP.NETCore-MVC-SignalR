using JournalSite.Data.Entities;
using JournalSite.Data.Interfaces.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq;

namespace JournalSite.Data.Interfaces.EF
{
    public class EFGroup : IGroup
    {
        private readonly AppDBContext context;
        public EFGroup(AppDBContext context)
        {
            this.context = context;
        }

        public bool AnyGroup()
        {
            return context.Groups.Any();
        }

        public int GetCountGroupsByUserName(string userName)
        {
            return context.Groups.Count(x => x.UserName == userName);
        }

        public IQueryable<Group> GetGroupsByUserNameMod(string username)
        {
            return context.Groups.Where(x => x.UserName != username);
        }

        public IQueryable<Group> GetGroupsByUserNameUs(string username)
        {
            Group entity = context.Groups.First(x => x.UserName == username);
            return context.Groups.Where(x => x.GroupName == entity.GroupName && x.UserName != username);
        }

        public void SaveGroup(Group group)
        {
            if (group.Id == default)
                context.Entry(group).State = EntityState.Added;
            else
                context.Entry(group).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
