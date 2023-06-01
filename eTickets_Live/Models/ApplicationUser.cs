using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eTickets_Live.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Örnek olarak varolan IdentityUser sınıfındaki propertylere ek olarak kendimiz de bir property tanımlayalım

        [Display(Name = " Full Name")]
        public string FullName { get; set; }


    }
}
