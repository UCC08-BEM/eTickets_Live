using System.ComponentModel.DataAnnotations;

namespace eTickets_Live.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="E-Mail :")]
        [Required(ErrorMessage ="EMail alanı gereklidir..")]
        public string EMailAddress { get; set; }
        
        [Display(Name ="Şifre :")]
        [Required(ErrorMessage ="Şifrenizi girmeniz gerekmektedir..")]
        public string Password { get; set; }
    }
}
