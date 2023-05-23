namespace eTickets_Live.Models
{
    // Aktör bilgilerini tutacak olan class
    
    public class Actor
    {
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; } // Picture bir int sitesinden geleceği varsayılarak

        public  string FullName { get; set; }

        public string Bio { get; set; } // Biyografisi

        // Yapılmış olan ara table(Actor_Movie) yapısının bağlanması.

        public List<Actor_Movie> Actor_Movies { get; set; }

    }
}
