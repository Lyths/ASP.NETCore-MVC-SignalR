using JournalSite.Data.Entities;
using JournalSite.Data.Interfaces.Abstract;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace JournalSite.Data.Interfaces.EF
{
    public class EFArticle : IArticle
    {
        private readonly AppDBContext context;
        public EFArticle(AppDBContext dbContext)
        {
            context = dbContext;
        }

        public void AcceptState(Guid Id)
        {
            var entity = context.Arcticles.Find(Id);
            entity.State = "Принято";
            SaveArticle(entity);
        }

        public void DenyState(Guid Id)
        {
            var entity = context.Arcticles.Find(Id);
            entity.State = "Отклонено";
            SaveArticle(entity);
        }

        public IQueryable<Article> GetArticles()
        {
            return context.Arcticles.Include(c => c.Files);
        }

        public IQueryable<Article> GetArticlesByUserName(string userName)
        {
            return context.Arcticles.Where(x => x.Sender == userName).Include(c => c.Files);
        }

        public void SaveArticle(Article entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
