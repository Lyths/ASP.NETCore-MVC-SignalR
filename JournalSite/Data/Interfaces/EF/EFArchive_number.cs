using JournalSite.Data.Entities;
using JournalSite.Data.Interfaces.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JournalSite.Data.Interfaces.EF
{
    public class EFArchive_number: IArchive_number
    {
        private readonly AppDBContext context;
        public EFArchive_number(AppDBContext context)
        {
            this.context = context;
        }

        public IQueryable<Archive_number> GetAllById(Guid Id)
        {
            return context.Archive_Numbers.Where(a => a.Id == Id).Include(x => x.Articles);
        }

        public void Save(Archive_number entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
