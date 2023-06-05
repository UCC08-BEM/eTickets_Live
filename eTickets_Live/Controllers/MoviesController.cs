using eTickets_Live.Data;
using eTickets_Live.Data.Interfaces;
using eTickets_Live.Data.Static;
using eTickets_Live.Data.ViewModels;
using eTickets_Live.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets_Live.Controllers
{
    // Identity özelliklerini kullanabilmek için (admin girdiğinde ona göre,user girdiğin user yetkilendirmesine göre controllerın durum değiştirmesi yapması gerekiyor. Bu yüzden Authorize attribute belirtilmesi gerekiyor.

    [Authorize(Roles =UserRoles.Admin)] // tüm metotları adminin erişeği şekilde belirliyor.
    public class MoviesController : Controller
    {
        // Bu controller ile öncelikle db tarafındaki verleri görüntüleyelim.
        // dbcontext tanımlarını yapmam gerekiyor.

        //DI
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;

        }

        [AllowAnonymous] // admin..user farketmeksizin görülebilmesi
        public IActionResult Index()
        {
            // Movie tablosu Cinema tablosu ile ilişkili olduğundan dolayı Include direktifi ile ilişkili olduğu tablodan gerekli alanı alabiliyoruz.(Burad Cinema adı gibi)
            //var allmovies = _context.Movies.Include(c => c.Cinema).OrderBy(c=> c.Name).ToList();

            // Not: Normal bir şekilde service tarafındaki GetAll metodunu kullanamıyorum. Nedeni Movie modelinin birden fazla relation içermesi. Bunun için BaseRepository de ayrı bir GetAll metodu tanımlanması gerekiyor..



            var allmovies = _service.GetAll(c => c.Cinema);

            return View(allmovies);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var movieDetail= _service.GetMovieById(id);

            return View(movieDetail); // Seçilen filmin detayını getirme

        }

        public IActionResult Create()
        {
            // Öncelikle Create Viewında kullanılacak olan dropdown ların içeriklerini öğreneyi/oluşturayım
            var movieDropdownsData = _service.GetNewMovieDropdownsValues();

            // Bu olşan dropdown değerlerini ViewBag yöntemiyle Create View'da kullanılacak şekilde belirleyelim.
            ViewBag.Cinemas= new SelectList(movieDropdownsData.Cinemas,"Id","Name");
            ViewBag.Producers= new SelectList(movieDropdownsData.Producers,"Id","FullName");
            ViewBag.Actors= new SelectList(movieDropdownsData.Actors,"Id","FullName");


            return View(); // Seçilen filmin detayını getirme

        }

        [HttpPost]
        public IActionResult Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
            // Öncelikle Create Viewında kullanılacak olan dropdown ların içeriklerini öğreneyi/oluşturayım
            var movieDropdownsData = _service.GetNewMovieDropdownsValues();

            // Bu olşan dropdown değerlerini ViewBag yöntemiyle Create View'da kullanılacak şekilde belirleyelim.
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");


            return View(movie); // Seçilen filmin detayını getirme

            }

            _service.AddNewMovie(movie);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int id)
        {
            var movieDetails = _service.GetMovieById(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actor_Movies.Select(n => n.ActorId).ToList()
            };


            // Öncelikle Create Viewında kullanılacak olan dropdown ların içeriklerini öğreneyi/oluşturayım
            var movieDropdownsData = _service.GetNewMovieDropdownsValues();

            // Bu olşan dropdown değerlerini ViewBag yöntemiyle Create View'da kullanılacak şekilde belirleyelim.
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");


            return View(response); // Seçilen filmin detayını getirme

        }

        [HttpPost] 
        public IActionResult Edit(int id,NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                // Öncelikle Create Viewında kullanılacak olan dropdown ların içeriklerini öğreneyi/oluşturayım
                var movieDropdownsData = _service.GetNewMovieDropdownsValues();

                // Bu olşan dropdown değerlerini ViewBag yöntemiyle Create View'da kullanılacak şekilde belirleyelim.
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");


                return View(movie); // Seçilen filmin detayını getirme

            }

            _service.UpdateMovie(movie);

            return RedirectToAction(nameof(Index));

        }

        [AllowAnonymous]
        public IActionResult Filter(string searchString)
        {
            // Filmin ismine göre bir arama

            var allMovies = _service.GetAll(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                // eğer boş değilse view ekranında bir arama kelimesi yazılmıştır.

                //var filteredResult = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description,searchString,StringComparison.CurrentCultureIgnoreCase)).ToList();

                var filteredResult=allMovies.Where(n=> n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index",filteredResult);
            }

            return View("Index", allMovies);
        }
    }
}
