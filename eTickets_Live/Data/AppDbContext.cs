using eTickets_Live.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets_Live.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor metodu

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        // İşkilerin tanımlanması
        // varolan OnModelCreating metoduna kendi tanımlarımızı yapacağımız için  metodu override(geçersiz kılıyoruz) olarak kullanıyoruz.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ilişkiler
            // Actor_Movie'nin key yapısını tanımlamam lazım ki aşağılarda bağlantılarda kullanabileyim.

            modelBuilder.Entity<Actor_Movie>().HasKey(acmo => new
            {
                acmo.ActorId,
                acmo.MovieId
            });

            // Actor_Movie <-> Movie classı ilişkisi
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(acmo => acmo.Actor_Movies).HasForeignKey(m => m.MovieId);

            // Actor_Movie <-> Actor classı ilişkisi
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(acmo => acmo.Actor_Movies).HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        // VT tarafında oluşacak olan tablo tanımlamaları

        public DbSet<Actor> Actors { get; set; } // VT tarafındaki Actors table belirtiyor Actor modeli
        public DbSet<Movie> Movies { get; set; } // VT tarafındaki Movies table belirtiyor Movie modeli
        public DbSet<Actor_Movie> Actors_Movies { get; set; } // VT tarafındaki Actors_Movies table belirtiyor Actor_Movie modeli
        public DbSet<Cinema> Cinemas { get; set; } // VT tarafındaki Cinemas table belirtiyor Cinema modeli
        public DbSet<Producer> Producers { get; set; } // VT tarafındaki Producers table belirtiyor Producer modeli



    }
}
