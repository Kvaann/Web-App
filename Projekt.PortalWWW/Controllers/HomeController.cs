using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;
using Projekt.Data.Data.CMS;
using Projekt.PortalWWW.Models;
using System.Diagnostics;

namespace Projekt.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProjektContext _context; // to jest odnosnik do bazy danych

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ProjektContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id) // id identyfikator kliknietej strony w menu
        {
            //ViewBag sluzy do przenoszenia danych miedzy Widokiem a Controlerem. Po kropce w ViewBag mozna dowolnie nazwa model
            ViewBag.ModelStrony =
                (
                    from strona in _context.Strona
                    orderby strona.Pozycja
                    select strona
                ).ToList();
            ViewBag.Aktualnosc =
                (
                    from aktualnosc in _context.Aktualnosc
                    orderby aktualnosc.Pozycja
                    select aktualnosc
                ).ToList();
            ViewBag.ONas =
                (
                from oNas in _context.ONas
                select oNas
                ).ToList();
            ViewBag.Stopka =
                (
                from stopka in _context.Stopka
                select stopka
                ).ToList();
            ViewBag.Promocja =
            (
            from promocja in _context.Promocja
            select promocja
            ).ToList();
            ViewBag.Slider =
            (
            from slider in _context.Slider
            select slider
            ).ToList();

            if (id == null)
                id = _context.Strona.First().IdStrony;
            // odnajdujemy w bazie danych strone o podanym id i przekazujemy ja do widoku, aby Widok ja wyswietlil
            var item = _context.Strona.Find(id);
            return View(item);
        }

        public IActionResult Menu()
        {
            return View(); // widok będzie nazywał się tak samo jak funkcja czyli Menu
        }

        //public async Task<IViewComponentResult> InvokeAsync(ONas)
        //{
        //    return View("ONasComponent", await _context.ONas.ToListAsync());
        //}



        public IActionResult About()
        {
            return View(); // widok będzie nazywał się tak samo jak funkcja czyli About
        }

        public IActionResult Book()
        {
            return View(); // widok będzie nazywał się tak samo jak funkcja czyli Book
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}