using Microsoft.AspNetCore.Mvc;
using Projekt.Data.Data;
using Projekt.PortalWWW.Models.BusinessLogic;
using Projekt.PortalWWW.Models.Sklep;

namespace Projekt.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {
        public readonly ProjektContext _context;
        public KoszykController(ProjektContext context)
        {
            _context = context;
        }
        // ta funkcja wystawia dane do wyswietlania koszyka
        public async Task<IActionResult> Index()
        {
            //element logiki biznesowej, z ktorego to obiektu uzywam dwoch funkcji
            KoszykB koszykB = new KoszykB(this._context, this.HttpContext);
            var daneDoKoszyka = new DaneDoKoszyka()
            {
                ElementyKoszyka = await koszykB.GetElementyKoszyka(),
                Razem = await koszykB.GetRazem()
            };
            return View(daneDoKoszyka);
        }
        public async Task<IActionResult> DodajDoKoszyka(int id)
        {
            KoszykB koszykB = new KoszykB(this._context, this.HttpContext);
            koszykB.DodajDoKoszyka(await _context.Danie.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
