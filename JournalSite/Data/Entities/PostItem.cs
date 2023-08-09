using System.ComponentModel.DataAnnotations;

namespace JournalSite.Data.Entities
{
    public class PostItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название публикации")]
        [Display(Name = "Название публикации")]
        public override string  Title { get; set; }


        [Display(Name = "Краткое описание публикации")]
        public override string? SubTitle { get; set; }


        [Display(Name = "Полное описание публикации")]
        public override string? Text { get; set; }
    }
}
