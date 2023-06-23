using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;
using Projekt.Data.Data.CMS;
using Projekt.Data.Data.Sklep;
using System;

namespace Projekt.Intranet.Controllers
{
    public class PromocjaController : BaseController<Promocja>
    {
        public PromocjaController(ProjektContext context)
            : base(context)
        {
        }

        // GET: PromocjaController
        public override async Task<IActionResult> Index()
        {
            return _context.Promocja != null ?
                        View(await _context.Promocja.ToListAsync()) :
                        Problem("Entity set 'ProjektContext.Promocja'  is null.");
        }

        // GET: PromocjaController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            {
                if (id == null || _context.Promocja == null)
                {
                    return NotFound();
                }

                var promocja = await _context.Promocja
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (promocja == null)
                {
                    return NotFound();
                }

                return View(promocja);
            }
        }

        // POST: PromocjaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create(Promocja promocja)
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file != null && file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    using (var binaryReader = new BinaryReader(stream))
                    {
                        var imageData = binaryReader.ReadBytes((int)file.Length);
                        promocja.FotoURL = imageData;
                    }
                }
            }// image, serialnumber
            _context.Add(promocja);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: PromocjaController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Promocja == null)
            {
                return NotFound();
            }

            var promocja = await _context.Promocja.FindAsync(id);
            if (promocja == null)
            {
                return NotFound();
            }
            return View(promocja);
        }

        // POST: PromocjaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Promocja promocja)
        {
            {
                if (id != promocja.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(promocja);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PromocjaExists(promocja.Id))
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
                return View(promocja);
            }
        }

        // GET: PromocjaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PromocjaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id, IFormCollection collection)
        {
            if (id == null || _context.Promocja == null)
            {
                return NotFound();
            }

            var promocja = await _context.Promocja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promocja == null)
            {
                return NotFound();
            }

            return View(promocja);
        }

        private bool PromocjaExists(int id)
        {
            return (_context.Promocja?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async override Task<List<Promocja>> GetEntityList()
        {
            return await _context.Promocja.Include(s => s.Id).ToListAsync();
        }
    }
}
