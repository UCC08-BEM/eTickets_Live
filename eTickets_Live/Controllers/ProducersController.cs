using eTickets_Live.Data;
using eTickets_Live.Data.Interfaces;
using eTickets_Live.Data.Static;
using eTickets_Live.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace eTickets_Live.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
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

        [AllowAnonymous]
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

        // Get : Producers/Details/1
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var producerDetails=_service.GetById(id);

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
           

        }

        // Get : Producers/Edit/1
        public IActionResult Edit(int id)
        {
            var producerDetails = _service.GetById(id);

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);


        }

        // Get : Producers/Edit/1
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            _service.Update(id, producer);

            return RedirectToAction(nameof(Index));

        }

        // Get : Producers/Delete/1
        public IActionResult Delete(int id)
        {
            var producerDetails = _service.GetById(id);

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);

        }

        // Get : Producers/Edit/1
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producerDetails= _service.GetById(id);

            if (producerDetails == null) return View("NotFound");

            _service.Delete(id);
 
            return RedirectToAction(nameof(Index));

        }

    }
}
