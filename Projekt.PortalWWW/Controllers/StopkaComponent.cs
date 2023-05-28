using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;

namespace Projekt.PortalWWW.Controllers
{
    public class StopkaComponent : ViewComponent
    {
        private readonly ProjektContext _context;
        public StopkaComponent(ProjektContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("StopkaComponent", await _context.Stopka.ToListAsync());
        }

    }
}
