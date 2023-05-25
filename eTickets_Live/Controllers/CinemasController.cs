using eTickets_Live.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets_Live.Controllers
{
    public class CinemasController : Controller
    {
        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            var cinemasdata = _context.Cinemas.ToList();

            return View(cinemasdata);
        }
    }
}
