using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;

namespace Projekt.PortalWWW.Controllers
{
    // celem tego komponentu bedzie wyswietlenie w czesci layoutu wszytkich kategorii dan
    public class KategorieMenuComponent : ViewComponent
    {
        // dostep do bazy danych
        private readonly ProjektContext _context;

        public KategorieMenuComponent(ProjektContext context)
        {
            _context = context;
        }
        //InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //zwracam widok kategoriamenucomponent do ktorego przekazuje kolekcje kategorii dan
            return View("KategorieMenuComponent", await _context.Kategoria.ToListAsync());
        }
    }
}
