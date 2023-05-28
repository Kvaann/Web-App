using Microsoft.AspNetCore.Mvc;
using Projekt.Data.Data;

namespace Projekt.Intranet.Controllers
{
    //kontroler bazowy, z niego dziedziczą wszystkie kontrolery realizujace operacje elementarne CRUD
    public class BaseController : Controller
    {
        // bedziemy go uzywac w kazdym kontrolerze, dlatego wskazuje jako protected, ew. mozna zastosowac property
        protected readonly ProjektContext _context;

        public BaseController(ProjektContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
