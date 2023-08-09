using JournalSite.Data.Entities;

namespace JournalSite.Data.Interfaces.Abstract
{
    public interface IArchive_year
    {
        IQueryable<Archive_year> GetAllYears();
        bool YearIsIn(int year);
        Archive_year GetYear(int year);
        void Save(Archive_year entity);
    }
}
