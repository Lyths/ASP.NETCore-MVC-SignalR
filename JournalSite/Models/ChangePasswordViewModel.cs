using System.ComponentModel.DataAnnotations;

namespace JournalSite.Models
{
    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }
        [Display(Name = "Старый пароль")]
        [Required(ErrorMessage = "Введите старый пароль!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Введите новый пароль!")]
        [Display(Name = "Новый пароль")]
        [StringLength(15, ErrorMessage = "Пароль должен иметь минимум 6 символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Подтверждение пароля")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set;}
    }
}
