using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;

namespace Projekt.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly ProjektContext _context; // to jest odnosnik do bazy danych

        public SklepController(ProjektContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int? id) // id kategorii
        {
            // za pomocą ViewBag przekazujemy do Widoku listę kategorii
            ViewBag.Kategoria = await _context.Kategoria.ToListAsync();
            if (id == null)
            {
                // jeżeli nie wybrano kategorii to wyświetlamy wszystkie dania
                return View(await _context.Danie.ToListAsync());
            }
            else
            {
                // jeżeli wybrano kategorię to wyświetlamy tylko dania z tej kategorii
                return View(await _context.Danie.Where(d => d.KategoriaId == id).ToListAsync());
            }

        }

        // to jest akcja wywoływana po kliknięciu w danie, które chcemy zobaczyć w szczegółach
        public async Task<IActionResult> Szczegoly(int id) // id musi byc wskazane
        {
            ViewBag.Kategoria = await _context.Kategoria.ToListAsync();
            // do widoku przekazujemy danie o wskazanym id
            return View(await _context.Danie.FirstOrDefaultAsync(d => d.IdDania == id));
        }

        public async Task<IActionResult> Stopka(int? id) // id musi byc wskazane
        {
            ViewBag.Stopka = await _context.Stopka.ToListAsync();
            return View(await _context.Stopka.ToListAsync());
        }




    }
}
