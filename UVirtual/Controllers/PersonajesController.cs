using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UVirtual.Data;
using UVirtual.Models;

namespace UVirtual.Controllers
{
    public class PersonajesController : Controller
    {
        private readonly UVirtualContext _context;

        public PersonajesController(UVirtualContext context)
        {
            _context = context;
        }

        // GET: Personajes
        public async Task<IActionResult> Index()
        {
            var uVirtualContext = _context.Personaje.Include(p => p.Rol);
            return View(await uVirtualContext.ToListAsync());
        }

        // GET: Personajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personaje
                .Include(p => p.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaje == null)
            {
                return NotFound();
            }

            return View(personaje);
        }

        // GET: Personajes/Create
        public IActionResult Create()
        {
            ViewData["RolID"] = new SelectList(_context.Rol, "Id", "Nombre");
            return View();
        }

        // POST: Personajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado,RolID")] Personaje personaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolID"] = new SelectList(_context.Rol, "Id", "Nombre", personaje.RolID);
            return View(personaje);
        }

        // GET: Personajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personaje.FindAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }
            ViewData["RolID"] = new SelectList(_context.Rol, "Id", "Nombre", personaje.RolID);
            return View(personaje);
        }

        // POST: Personajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado,RolID")] Personaje personaje)
        {
            if (id != personaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonajeExists(personaje.Id))
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
            ViewData["RolID"] = new SelectList(_context.Rol, "Id", "Nombre", personaje.RolID);
            return View(personaje);
        }

        // GET: Personajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personaje
                .Include(p => p.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaje == null)
            {
                return NotFound();
            }

            return View(personaje);
        }

        // POST: Personajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personaje = await _context.Personaje.FindAsync(id);
            _context.Personaje.Remove(personaje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonajeExists(int id)
        {
            return _context.Personaje.Any(e => e.Id == id);
        }
    }
}
