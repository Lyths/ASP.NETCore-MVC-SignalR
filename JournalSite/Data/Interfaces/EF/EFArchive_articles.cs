using JournalSite.Data.Entities;
using JournalSite.Data.Interfaces.Abstract;
using JournalSite.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalSite.Data.Interfaces.EF
{
    public class EFArchive_articles: IArchive_articles
    {
        private readonly AppDBContext context;
        public EFArchive_articles(AppDBContext context)
        {
            this.context = context;
        }
        public void Save(Archive_articles entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteArchiveArticle(Guid Id)
        {
            context.Archive_Articles.Remove(new Archive_articles { Id = Id });
            context.SaveChanges();
        }
    }
}
