using JournalSite.Data.Entities;
using JournalSite.Data.Interfaces.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JournalSite.Data.Interfaces.EF
{
    public class EFArchive_year : IArchive_year
    {
        private readonly AppDBContext context;
        public EFArchive_year(AppDBContext context)
        {
            this.context = context;
        }
        public IQueryable<Archive_year> GetAllYears()
        {
            return context.Archive_Years.Distinct().Include(c => c.Numbers);
        }

        public Archive_year GetYear(int year)
        {
            return context.Archive_Years.FirstOrDefault(x => x.Year == year);
        }

        public void Save(Archive_year entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public bool YearIsIn(int year)
        {
            if (context.Archive_Years.FirstOrDefault(x => x.Year == year) == null)
            {
                return false;
            }
            return true;
        }
    }
}
