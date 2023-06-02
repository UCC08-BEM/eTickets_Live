using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eTickets_Live.Data.ViewModels
{
    public class RegisterVM
    {

        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Ad Soyad gereklidir...")]
        public string FullName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address gereklidir")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password (Tekrar)")]
        [Required(ErrorMessage = "Confirm password gereklidir....")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyumsuz...Kontrol ediniz...")]      
        public string ConfirmPassword { get; set; }


    }
}
