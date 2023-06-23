using Microsoft.AspNetCore.Mvc;
using Projekt.Data.Data;

namespace Projekt.Intranet.Controllers
{
    //kontroler bazowy, z niego dziedziczą wszystkie kontrolery realizujace operacje elementarne CRUD
    public abstract class BaseController<TEntity> : Controller
    {
        // bedziemy go uzywac w kazdym kontrolerze, dlatego wskazuje jako protected, ew. mozna zastosowac property
        protected readonly ProjektContext _context;

        public BaseController(ProjektContext context)
        {
            _context = context;
        }

        public abstract Task<List<TEntity>> GetEntityList();

        public virtual Task SetSelectList()
        {
            return null;
        }

        public virtual async Task<IActionResult> Index()
        {
            return View(await GetEntityList());
        }

        public async Task<IActionResult> Create()
        {
            if (SetSelectList() != null)
            {
                await SetSelectList();
                return View();
            }
            else
            {
                return View();
            }

        }

        public virtual async Task<IActionResult> Create(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
