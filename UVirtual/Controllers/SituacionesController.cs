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
    public class SituacionesController : Controller
    {
        private readonly UVirtualContext _context;

        public SituacionesController(UVirtualContext context)
        {
            _context = context;
        }

        // GET: Situaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Situacion.ToListAsync());
        }

        // GET: Situaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacion = await _context.Situacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (situacion == null)
            {
                return NotFound();
            }

            return View(situacion);
        }

        // GET: Situaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Situaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Texto,Inicio,Estado")] Situacion situacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(situacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(situacion);
        }

        // GET: Situaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacion = await _context.Situacion.FindAsync(id);
            if (situacion == null)
            {
                return NotFound();
            }
            return View(situacion);
        }

        // POST: Situaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Texto,Inicio,Estado")] Situacion situacion)
        {
            if (id != situacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(situacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SituacionExists(situacion.Id))
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
            return View(situacion);
        }

        // GET: Situaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacion = await _context.Situacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (situacion == null)
            {
                return NotFound();
            }

            return View(situacion);
        }

        // POST: Situaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var situacion = await _context.Situacion.FindAsync(id);
            _context.Situacion.Remove(situacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SituacionExists(int id)
        {
            return _context.Situacion.Any(e => e.Id == id);
        }
    }
}
