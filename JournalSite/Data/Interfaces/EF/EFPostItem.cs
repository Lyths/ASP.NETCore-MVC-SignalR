using JournalSite.Data.Entities;
using JournalSite.Data.Interfaces.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JournalSite.Data.Interfaces.EF
{
    public class EFPostItem : IPostItems
    {
        //Контекст доступа к базе данных
        private readonly AppDBContext context;

        //Конструктор класса
        public EFPostItem(AppDBContext context)
        {
            this.context = context;
        }

        //Удалить публикацию по ее идентификатору
        public void DeletePostItem(Guid Id)
        {
            context.PostItems.Remove(new PostItem { Id = Id });
            context.SaveChanges();
        }

        //Получить публикацию по ее идентификатору
        public PostItem GetPostItemById(Guid Id)
        {
            return context.PostItems.FirstOrDefault(x => x.Id == Id);
        }

        //Получить список всех публикаций
        public IQueryable<PostItem> GetPostItems()
        {
            return context.PostItems;
        }

        //Сохранить публикацию или ее изменения
        public void SavePostItem(PostItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
