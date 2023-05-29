using eTickets_Live.Data.Base;

namespace eTickets_Live.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get; set; }

        public string Logo { get; set; } // İnternetten geleceği varsayılır.

        public string Name { get; set; }

        public string Description { get; set; } // Detaylı bilgi.

        // Relation tanımı (Movie ile)
        public List<Movie>? Movies { get; set; } // Movie classından bir liste değeri Id (Movie) bilgisinin geleceği kısım. Bir cinemada birden fazla film olabilir.

    }
}
