using JournalSite.Data.Entities;

namespace JournalSite.Data.Interfaces.Abstract
{
    public interface IPostItems
    {
        //Получить все публикации
        IQueryable<PostItem> GetPostItems();

        //Получить публикацию по ее идентификатору
        PostItem GetPostItemById(Guid Id);

        //Сохранить публикацию или ее изменения
        void SavePostItem(PostItem entity);

        //Удалить публикацию по ее идентификатору
        void DeletePostItem(Guid Id);
    }
}
