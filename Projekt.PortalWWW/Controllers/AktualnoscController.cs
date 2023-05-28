using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;

namespace Projekt.PortalWWW.Controllers
{
    public class AktualnoscController : Controller
    {
        private readonly ProjektContext _context;

        public AktualnoscController(ProjektContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            ViewBag.ModelStrony =
    (
        from strona in _context.Strona
        orderby strona.Pozycja
        select strona
    ).ToList();

            ViewBag.ModelDania =
                (
                    from danie in _context.Danie
                    orderby danie.Nazwa
                    select danie
                ).ToList();
//podajemy aktualnosci o danym kliknietych ID i przekazujemy ja do widoku
            var item = _context.Aktualnosc.Find(id);
            return View(item);
        }
    }
}
