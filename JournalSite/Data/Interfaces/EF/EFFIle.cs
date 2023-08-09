using JournalSite.Data.Interfaces.Abstract;
using Microsoft.EntityFrameworkCore;
using JournalSite.Data.Entities;

namespace JournalSite.Data.Interfaces.EF
{
    public class EFFIle : IFile
    {
        private readonly AppDBContext context;
        public EFFIle(AppDBContext dbContext)
        {
            context = dbContext;
        }

        public void SaveFile(Entities.File entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
