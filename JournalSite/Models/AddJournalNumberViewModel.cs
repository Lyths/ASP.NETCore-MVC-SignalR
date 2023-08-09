using System.ComponentModel.DataAnnotations;

namespace JournalSite.Models
{
    public class AddJournalNumberViewModel
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Display(Name = "Год выпуска журнала")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Display(Name = "Номер журнала")]
        public string Name { get; set; }
    }
}
