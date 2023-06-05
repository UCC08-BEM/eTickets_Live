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
    public class CinemasController : Controller
    {
        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //var cinemasdata = _context.Cinemas.ToList();
            var cinemasdata = _service.GetAll();

            return View(cinemasdata);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            _service.Add(cinema);

            return RedirectToAction(nameof(Index));
        }

        // Cinemas/Details/4
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var cinemaDetails=_service.GetById(id);

            if (cinemaDetails == null) return View("NotFound");
            

            return View(cinemaDetails);
        }

        // Cinemas/Edit/4
        public IActionResult Edit(int id)
        {
            var cinemaDetails = _service.GetById(id);

            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            _service.Update(id, cinema);

            return RedirectToAction(nameof(Index));

        }

        // Cinemas/Delete/4
        public IActionResult Delete(int id)
        {
            var cinemaDetails = _service.GetById(id);

            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var cinemaDetails = _service.GetById(id);

            if (cinemaDetails == null) return View("NotFound");

            _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
