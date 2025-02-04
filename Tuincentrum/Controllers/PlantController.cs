using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tuincentrum.Models;

namespace Tuincentrum.Controllers
{
    public class PlantController : Controller
    {
        private readonly MvctuinCentrumContext _context;

        public PlantController(MvctuinCentrumContext context)
        {
            _context = context;
        }

        // GET: Plant
        public async Task<IActionResult> Index()
        {
            var mvctuinCentrumContext = _context.Planten.Include(p => p.LevnrNavigation).Include(p => p.SoortNrNavigation);
            return View(await mvctuinCentrumContext.ToListAsync());
        }

        // GET: Plant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Planten == null)
            {
                return NotFound();
            }

            var plant = await _context.Planten
                .Include(p => p.LevnrNavigation)
                .Include(p => p.SoortNrNavigation)
                .FirstOrDefaultAsync(m => m.PlantNr == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // GET: Plant/Create
        public IActionResult Create()
        {
            ViewData["Levnr"] = new SelectList(_context.Leveranciers, "LevNr", "Naam");
            ViewData["SoortNr"] = new SelectList(_context.Soorten, "SoortNr", "Naam");
            return View();
        }

        // POST: Plant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Levnr"] = new SelectList(_context.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewData["SoortNr"] = new SelectList(_context.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // GET: Plant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Planten == null)
            {
                return NotFound();
            }

            var plant = await _context.Planten.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            ViewData["Levnr"] = new SelectList(_context.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewData["SoortNr"] = new SelectList(_context.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // POST: Plant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Plant plant)
        {
            if (id != plant.PlantNr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantExists(plant.PlantNr))
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
            ViewData["Levnr"] = new SelectList(_context.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewData["SoortNr"] = new SelectList(_context.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // GET: Plant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Planten == null)
            {
                return NotFound();
            }

            var plant = await _context.Planten
                .Include(p => p.LevnrNavigation)
                .Include(p => p.SoortNrNavigation)
                .FirstOrDefaultAsync(m => m.PlantNr == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // POST: Plant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Planten == null)
            {
                return Problem("Entity set 'MvctuinCentrumContext.Planten'  is null.");
            }
            var plant = await _context.Planten.FindAsync(id);
            if (plant != null)
            {
                _context.Planten.Remove(plant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantExists(int id)
        {
          return (_context.Planten?.Any(e => e.PlantNr == id)).GetValueOrDefault();
        }
    }
}
