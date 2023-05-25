using eTickets_Live.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets_Live.Controllers
{
    public class MoviesController : Controller
    {
        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            var moviesdata = _context.Movies.ToList();

            return View();
        }
    }
}
