namespace eTickets_Live.Models
{
    // Many-to-Many ilişkiyi One-to-Many(n) ilişki durumuna getirmek için...Bağlaşımı sağlayan yapı.
    // 
    public class Actor_Movie
    {
        public int MovieId { get; set; } // db tarafında yaratıldığında oluşacak olan alanlar.
        public Movie Movie { get; set; } // yukardaki alan/bilgi Movie classından gelecek.


        public int ActorId { get; set; } // Actor sınıfından gelecek bilgi.
        public Actor Actor { get; set; }

    }
}
