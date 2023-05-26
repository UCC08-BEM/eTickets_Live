using eTickets_Live.Data.Base;

namespace eTickets_Live.Models
{
    // Aktör bilgilerini tutacak olan class

    // IEntityBase interfacini kullanarak..yani bu sınıf içindeki propertyleri(gerekenleri) interface tarafından alabiliriz.
    
    public class Actor : IEntityBase
    {
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; } // Picture bir int sitesinden geleceği varsayılarak

        public  string FullName { get; set; }

        public string Bio { get; set; } // Biyografisi

        // Yapılmış olan ara table(Actor_Movie) yapısının bağlanması.

        public List<Actor_Movie>? Actor_Movies { get; set; }

    }
}
