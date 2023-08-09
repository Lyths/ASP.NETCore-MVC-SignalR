using System.ComponentModel.DataAnnotations;

namespace JournalSite.Data.Entities
{
    public class Article
    {
        public Article()
        {
            Files = new List<File>();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Укажите имя автора")]
        [Display(Name = "Имя автора")]
        public string AuthorName { get; set; }

        public string Sender { get; set; }

        [Required(ErrorMessage = "Укажите название статьи")]
        [Display(Name = "Название статьи")]
        public string Text { get; set; }

        public DateTime SendDate { get; set; } = DateTime.UtcNow;

        public string State { get; set; } = "Ожидается";

        public virtual ICollection<File> Files { get; set; }
    }
}
