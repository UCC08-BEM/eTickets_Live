using eTickets_Live.Data;
using eTickets_Live.Data.Interfaces;
using eTickets_Live.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace eTickets_Live.Controllers
{
    public class MoviesController : Controller
    {
        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;

        }

        public IActionResult Index()
        {
            // Movie tablosu Cinema tablosu ile ilişkili olduğundan dolayı Include direktifi ile ilişkili olduğu tablodan gerekli alanı alabiliyoruz.(Burad Cinema adı gibi)
            //var allmovies = _context.Movies.Include(c => c.Cinema).OrderBy(c=> c.Name).ToList();

            // Not: Normal bir şekilde service tarafındaki GetAll metodunu kullanamıyorum. Nedeni Movie modelinin birden fazla relation içermesi. Bunun için BaseRepository de ayrı bir GetAll metodu tanımlanması gerekiyor

            var allmovies = _service.GetAll(c => c.Cinema);

            return View(allmovies);
        }


        public IActionResult Details(int id)
        {
            var movieDetail= _service.Get
            return View();
        }
    }
}
