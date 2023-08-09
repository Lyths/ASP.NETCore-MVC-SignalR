using JournalSite.Data.Entities;
using JournalSite.Models;

namespace JournalSite.Data.Interfaces.Abstract
{
    public interface IArchive_articles
    {
        void Save(Archive_articles entity);
        void DeleteArchiveArticle(Guid Id);
    }
}
