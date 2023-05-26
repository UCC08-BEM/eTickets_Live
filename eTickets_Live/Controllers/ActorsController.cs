using eTickets_Live.Data;
using eTickets_Live.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eTickets_Live.Controllers
{
    public class ActorsController : Controller
    {
        // Actor işlemleri için Interface tanımlandığından bunun atamasını tanımlamak gerekiyor.

        private readonly IActorsService _service;


        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        //private readonly AppDbContext _context;

        public ActorsController(IActorsService service)
        {
            _service = service;
            
        }

        public IActionResult Index()
        {
            //var actorsdata = _context.Actors.ToList();
            var actorsdata = _service.GetAll();

            return View(actorsdata);
        }

        public IActionResult Create()
        {
            return View();
        }


    }
}
