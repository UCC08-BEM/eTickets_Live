using eTickets_Live.Data.Base;

namespace eTickets_Live.Models
{
    // Aktör bilgilerini tutacak olan class
    
    public class Producer : IEntityBase
    {
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; } // Picture bir int sitesinden geleceği varsayılarak

        public  string FullName { get; set; }

        public string Bio { get; set; } // Biyografisi

        // Relation tanımlaması
        public List<Movie>? Movies { get; set; } // Movie classından bir liste değeri Id (Movie) bilgisinin geleceği kısım. Bir producer birden fazla filmi yapmış olabilir.   

    }
}
