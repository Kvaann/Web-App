using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data.CMS;
using Projekt.Data.Data;

namespace Projekt.Intranet.Controllers
{
    public class ONasController : BaseController<ONas>
    {

        public ONasController(ProjektContext context)
            : base(context)
        {

        }

        // GET: Onas
        public override async Task<List<ONas>> GetEntityList()
        {
            return await _context.ONas.Include(t => t.IdONas).ToListAsync();
        }

        // GET: Danie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas
                .FirstOrDefaultAsync(m => m.IdONas == id);
            if (oNas == null)
            {
                return NotFound();
            }

            return View(oNas);
        }

        // GET: ONas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: O nas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdONas,Tytul,Tresc")] ONas oNas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oNas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oNas);
        }

        // GET: Danie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas.FindAsync(id);
            if (oNas == null)
            {
                return NotFound();
            }
            return View(oNas);
        }

        // POST:  O nas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdONas,Tytul,Tresc")] ONas oNas)
        {
            if (id != oNas.IdONas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oNas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ONasExists(oNas.IdONas))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(oNas);
        }

        // GET: O nas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ONas == null)
            {
                return NotFound();
            }

            var oNas = await _context.ONas
                .FirstOrDefaultAsync(m => m.IdONas == id);
            if (oNas == null)
            {
                return NotFound();
            }

            return View(oNas);
        }

        // POST:  O nas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ONas == null)
            {
                return Problem("Entity set 'ProjektContext.ONas'  is null.");
            }
            var oNas = await _context.ONas.FindAsync(id);
            if (oNas != null)
            {
                _context.ONas.Remove(oNas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ONasExists(int id)
        {
            return (_context.ONas?.Any(e => e.IdONas == id)).GetValueOrDefault();
        }
    }
}

