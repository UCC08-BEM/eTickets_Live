using eTickets_Live.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            // Movie tablosu Cinema tablosu ile ilişkili olduğundan dolayı Include direktifi ile ilişkili olduğu tablodan gerekli alanı alabiliyoruz.(Burad Cinema adı gibi)
            var moviesdata = _context.Movies.Include(c => c.Cinema).OrderBy(c=> c.Name).ToList();

            return View(moviesdata);
        }
    }
}
