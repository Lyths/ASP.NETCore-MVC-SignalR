using JournalSite.Data.Entities;
using JournalSite.Data.Interfaces.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JournalSite.Data.Interfaces.EF
{
    public class EFMessage : IMessage
    {
        private readonly AppDBContext context;
        public EFMessage(AppDBContext context)
        {
            this.context = context;
        }
        public IQueryable<Message> GetMessagesByGroupName(string groupName)
        {
            return context.Messages.Where(x => x.GroupName == groupName);
        }

        public void SaveMessage(Message model)
        {
            if (model.Id == default)
                context.Entry(model).State = EntityState.Added;
            else
                context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
