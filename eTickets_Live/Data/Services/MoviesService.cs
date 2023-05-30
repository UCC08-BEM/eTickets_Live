using eTickets_Live.Data.Base;
using eTickets_Live.Data.Interfaces;
using eTickets_Live.Data.ViewModels;
using eTickets_Live.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets_Live.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Movie GetMovieById(int id)
        {
            // aşağıdaki gösterim modeller arasındaki ilişkilerden yararlanarak  istenen film bilgisi db den çeker

            var movieDetails= _context.Movies
                .Include(c=> c.Cinema)
                .Include(p=> p.Producer)
                .Include(acmo=> acmo.Actor_Movies)
                .ThenInclude(a=> a.Actor)
                .FirstOrDefault(n=> n.Id == id);

            return movieDetails;
        }

        public NewMovieDropdownsVM GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = _context.Actors.OrderBy(a => a.FullName).ToList(),
                Cinemas = _context.Cinemas.OrderBy(c => c.Name).ToList(),
                Producers = _context.Producers.OrderBy(p => p.FullName).ToList()
            };

            return response;
        }
    }
}
