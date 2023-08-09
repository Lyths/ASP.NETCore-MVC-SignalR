using System.ComponentModel.DataAnnotations;

namespace JournalSite.Models
{
    public class AddArticlesViewModel
    {
        public Guid NumberId { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Display(Name = "Отправитель")]
        public string Sender { get; set; }
    }
}
