using JournalSite.Data.Entities;

namespace JournalSite.Data.Interfaces.Abstract
{
    public interface IArchive_number
    {
        void Save(Archive_number entity);
        IQueryable<Archive_number> GetAllById(Guid Id);
    }
}
