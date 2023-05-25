using eTickets_Live.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets_Live.Controllers
{
    public class ProducersController : Controller
    {
        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            var producersdata = _context.Producers.ToList();

            return View(producersdata);

        }
    }
}
