using eTickets_Live.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets_Live.Controllers
{
    public class ActorsController : Controller
    {
        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
            
        }

        public IActionResult Index()
        {
            var actorsdata = _context.Actors.ToList();

            return View(actorsdata);
        }
    }
}
