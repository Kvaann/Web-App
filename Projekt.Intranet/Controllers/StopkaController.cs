using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;
using Projekt.Data.Data.CMS;
using Projekt.Data.Data.Sklep;
using System;

namespace Projekt.Intranet.Controllers
{
    public class StopkaController : BaseController<Stopka>
    {

        public StopkaController(ProjektContext context) 
            : base(context)
        {

        }

        // GET: StopkaController
        public override async Task<IActionResult> Index()
        {
            return _context.Stopka != null ?
                        View(await _context.Stopka.ToListAsync()) :
                        Problem("Entity set 'ProjektContext.Stopka'  is null.");
        }

        // GET: StopkaController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            {
                if (id == null || _context.Stopka == null)
                {
                    return NotFound();
                }

                var stopka = await _context.Stopka
                    .FirstOrDefaultAsync(m => m.IdStopka == id);
                if (stopka == null)
                {
                    return NotFound();
                }

                return View(stopka);
            }
        }

        // POST: StopkaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create(Stopka stopka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stopka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: StopkaController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stopka == null)
            {
                return NotFound();
            }

            var stopka = await _context.Stopka.FindAsync(id);
            if (stopka == null)
            {
                return NotFound();
            }
            return View(stopka);
        }

        // POST: StopkaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Stopka stopka)
        {
            if (id != stopka.IdStopka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stopka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StopkaExists(stopka.IdStopka))
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
            return View(stopka);
        }

        // GET: StopkaController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Stopka == null)
            {
                return NotFound();
            }

            var stopka = await _context.Stopka
                .FirstOrDefaultAsync(m => m.IdStopka == id);
            if (stopka == null)
            {
                return NotFound();
            }

            return View(stopka);
        }

        // POST: StopkaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stopka == null)
            {
                return Problem("Entity set 'ProjektContext.Aktualnosc'  is null.");
            }
            var stopka = await _context.Stopka.FindAsync(id);
            if (stopka != null)
            {
                _context.Stopka.Remove(stopka);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public override async Task<List<Stopka>> GetEntityList()
        {
            return await _context.Stopka.Include(s => s.IdStopka).ToListAsync();
        }

        private bool StopkaExists(int id)
        {
            return (_context.Stopka?.Any(e => e.IdStopka == id)).GetValueOrDefault();
        }
    }
}
