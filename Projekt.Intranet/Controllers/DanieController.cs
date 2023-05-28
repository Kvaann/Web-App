using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data.Sklep;
using Projekt.Data.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt.Intranet.Controllers
{
    public class DanieController : BaseController<Danie>
    {

        public DanieController(ProjektContext context)
            : base(context)
        {
        }

        public override async Task<List<Danie>> GetEntityList()
        {
            return await _context.Danie.Include(t => t.Kategoria).ToListAsync();
        }

        public override async Task SetSelectList()
        {
            var kategoria = await _context.Kategoria.ToListAsync();
            ViewBag.Kategoria = new SelectList(kategoria, "IdKategorii", "Nazwa");
        }

        // GET: Danie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Danie == null)
            {
                return NotFound();
            }

            var Danie = await _context.Danie
                .FirstOrDefaultAsync(m => m.IdDania == id);
            if (Danie == null)
            {
                return NotFound();
            }

            return View(Danie);
        }

        // POST: Danie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create(Danie danie)
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file != null && file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    using (var binaryReader = new BinaryReader(stream))
                    {
                        var imageData = binaryReader.ReadBytes((int)file.Length);
                        danie.FotoURL = imageData;
                    }
                }
            }// image, serialnumber
            _context.Add(danie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Danie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await SetSelectList();
            if (id == null || _context.Danie == null)
            {
                return NotFound();
            }

            var danie = await _context.Danie.FindAsync(id);
            if (danie == null)
            {
                return NotFound();
            }
            return View(danie);
        }

        // POST: Danie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDania,Kod,Nazwa,Cena,FotoURL,KategoriaId,Opis")] Danie danie)
        {
            if (id != danie.IdDania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var file = Request.Form.Files.FirstOrDefault();
                    if (file != null && file.Length > 0)
                    {
                        using (var stream = file.OpenReadStream())
                        {
                            using (var binaryReader = new BinaryReader(stream))
                            {
                                var imageData = binaryReader.ReadBytes((int)file.Length);
                                danie.FotoURL = imageData;
                            }
                        }
                    }

                    _context.Update(danie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanieExists(danie.IdDania))
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

            return View(danie);
        }

        // GET: Danie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Danie == null)
            {
                return NotFound();
            }

            var danie = await _context.Danie
                .FirstOrDefaultAsync(m => m.IdDania == id);
            if (danie == null)
            {
                return NotFound();
            }

            return View(danie);
        }

        // POST: Danie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Danie == null)
            {
                return Problem("Entity set 'ProjektContext.Danie'  is null.");
            }
            var danie = await _context.Danie.FindAsync(id);
            if (danie != null)
            {
                _context.Danie.Remove(danie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanieExists(int id)
        {
            return (_context.Danie?.Any(e => e.IdDania == id)).GetValueOrDefault();
        }
    }
}
