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

        [AllowAnonymous]
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
        
        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _service.Add(actor);


            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Details/1
        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            var actorDetails = _service.GetById(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        // Get: Actors/Edit/1
        public IActionResult Edit(int id)
        {

            var actorDetails = _service.GetById(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _service.Update(id, actor);


            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Delete/1
        public IActionResult Delete(int id)
        {

            var actorDetails = _service.GetById(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            var actorDetails = _service.GetById(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
