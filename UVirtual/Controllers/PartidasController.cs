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
    public class PartidasController : Controller
    {
        private readonly UVirtualContext _context;

        public PartidasController(UVirtualContext context)
        {
            _context = context;
        }

        // GET: Partidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partida.ToListAsync());
        }

        // GET: Partidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // GET: Partidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,NotaAcomulada,EmocionAcomulada,TiempoAcomulado")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }
            return View(partida);
        }

        // POST: Partidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,NotaAcomulada,EmocionAcomulada,TiempoAcomulado")] Partida partida)
        {
            if (id != partida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidaExists(partida.Id))
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
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partida = await _context.Partida.FindAsync(id);
            _context.Partida.Remove(partida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidaExists(int id)
        {
            return _context.Partida.Any(e => e.Id == id);
        }
    }
}
