using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmApp.Data;
using FilmApp.Models;

namespace FilmApp.Controllers
{
    public class GlumciController : Controller
    {
        private readonly KontekstBaze _context;

        public GlumciController(KontekstBaze context)
        {
            _context = context;
        }

        // GET: Glumci
        public async Task<IActionResult> Index()
        {
            return View(await _context.Glumac.ToListAsync());
        }

        // GET: Glumci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glumac = await _context.Glumac
                .FirstOrDefaultAsync(m => m.Id == id);
            if (glumac == null)
            {
                return NotFound();
            }

            return View(glumac);
        }

        // GET: Glumci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Glumci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Glumac glumac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(glumac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(glumac);
        }

        // GET: Glumci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glumac = await _context.Glumac.FindAsync(id);
            if (glumac == null)
            {
                return NotFound();
            }
            return View(glumac);
        }

        // POST: Glumci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Glumac glumac)
        {
            if (id != glumac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glumac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlumacExists(glumac.Id))
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
            return View(glumac);
        }

        // GET: Glumci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glumac = await _context.Glumac
                .FirstOrDefaultAsync(m => m.Id == id);
            if (glumac == null)
            {
                return NotFound();
            }

            return View(glumac);
        }

        // POST: Glumci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var glumac = await _context.Glumac.FindAsync(id);
            _context.Glumac.Remove(glumac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GlumacExists(int id)
        {
            return _context.Glumac.Any(e => e.Id == id);
        }
    }
}
