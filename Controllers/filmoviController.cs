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
    public class filmoviController : Controller
    {
        private readonly KontekstBaze _context;

        public filmoviController(KontekstBaze context)
        {
            _context = context;
        }

        // GET: filmovi
        public async Task<IActionResult> Index()
        {
            var kontekstBaze = _context.film.Include(f => f.Glumac);
            return View(await kontekstBaze.ToListAsync());
        }

        // GET: filmovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.film
                .Include(f => f.Glumac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: filmovi/Create
        public IActionResult Create()
        {
            ViewData["GlumacId"] = new SelectList(_context.Glumac, "Id", "Naziv");
            return View();
        }

        // POST: filmovi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Dat,Zanr,GlumacId")] film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GlumacId"] = new SelectList(_context.Glumac, "Id", "Naziv", film.GlumacId);
            return View(film);
        }

        // GET: filmovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["GlumacId"] = new SelectList(_context.Glumac, "Id", "Naziv", film.GlumacId);
            return View(film);
        }

        // POST: filmovi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Dat,Zanr,GlumacId")] film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!filmExists(film.Id))
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
            ViewData["GlumacId"] = new SelectList(_context.Glumac, "Id", "Naziv", film.GlumacId);
            return View(film);
        }

        // GET: filmovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.film
                .Include(f => f.Glumac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: filmovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.film.FindAsync(id);
            _context.film.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool filmExists(int id)
        {
            return _context.film.Any(e => e.Id == id);
        }
    }
}
