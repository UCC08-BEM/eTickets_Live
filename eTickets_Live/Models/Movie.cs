using eTickets_Live.Data.Base;
using eTickets_Live.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace eTickets_Live.Models 
{
    public class Movie: IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public string ImageURL { get; set; } // Filmin poster - int sitesinden gelecek şekilde varsayım

        public DateTime StartDate { get; set; } // Vizyona giriş tarihi

        public DateTime EndDate { get; set; } // Vizyondan kalkış tarihi

        // Bu filmin kategorisi ayrı bir özel "enum" olarak yaratıldı
        public MovieCategory MovieCategory { get; set; }

        // Yapılmış olan ara table(Actor_Movie) yapısının bağlanması.
        // Many-to-Many ilişki.
        public List<Actor_Movie> Actor_Movies { get; set; }

        // Bu sınıfı(tabloyu) besleyecek olan Cinema ve Producer sınıflarının ilişkilendirilmesi

        // Cinema (One-to-Many(n) ilişki)
        public int CinemaId { get; set; } // Bu alan Cinema classındaki Id ile ilişkilendirilecek
        [ForeignKey("CinemaId")] // ForeingKey <- Cinemadan geliyor. 
        public Cinema Cinema { get; set;}


        // Producer (One-to-Many(n) ilişki)
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }


    }
}
