using eTickets_Live.Data.Base;
using eTickets_Live.Data.Interfaces;
using eTickets_Live.Models;

namespace eTickets_Live.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
