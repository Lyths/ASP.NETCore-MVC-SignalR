using JournalSite.Data.Entities;

namespace JournalSite.Data.Interfaces.Abstract
{
    public interface IArticle
    {
        IQueryable<Article> GetArticlesByUserName(string userName);
        IQueryable<Article> GetArticles();
        void DenyState(Guid Id);
        void AcceptState(Guid Id);
        void SaveArticle(Article entity);
    }
}
