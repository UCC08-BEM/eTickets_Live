using eTickets_Live.Data;
using eTickets_Live.Data.Interfaces;
using eTickets_Live.Models;

using Microsoft.AspNetCore.Mvc;

namespace eTickets_Live.Controllers
{
    public class ProducersController : Controller
    {
        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        //private readonly AppDbContext _context;
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;

        }

        public IActionResult Index()
        {
            var producersdata = _service.GetAll();

            return View(producersdata);

        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]

        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        { 
            if (!ModelState.IsValid) 
            {
                return View(producer);
            }

            _service.Add(producer); // Kayıt eklemeyi servis üzerinden gönderiliyor

            return RedirectToAction(nameof(Index));

        }

    }
}
