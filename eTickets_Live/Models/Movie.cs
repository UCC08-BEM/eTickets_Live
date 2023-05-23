using eTickets_Live.Data.Enums;
using System.Data;

namespace eTickets_Live.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; } // Filmin afişi - int sitesinden gelecek şekilde varsayım

        public DateTime StartDate { get; set; } // Vizyona giriş tarihi

        public DateTime EndDate { get; set; } // Vizyondan kalkış tarihi

        // Bu filmin kategorisi ayrı bir özel "enum" olarak yaratıldı
        public MovieCategory MovieCategory { get; set; }
    }
}
