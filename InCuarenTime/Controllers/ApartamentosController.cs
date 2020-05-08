using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InCuarenTime.Data;
using InCuarenTime.Models;

namespace InCuarenTime.Controllers
{
    public class ApartamentosController : Controller
    {
        private readonly InCuarenTimeContext _context;

        public ApartamentosController(InCuarenTimeContext context)
        {
            _context = context;
        }

        // GET: Apartamentos
        public async Task<IActionResult> Index()
        {
            var inCuarenTimeContext = _context.Apartamento.Include(a => a.Unidad_Residencial);
            return View(await inCuarenTimeContext.ToListAsync());
        }

        // GET: Apartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento
                .Include(a => a.Unidad_Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // GET: Apartamentos/Create
        public IActionResult Create()
        {
            ViewData["Unidad_ResidencialID"] = new SelectList(_context.Unidad_Residencial, "Id", "Nombre");
            return View();
        }

        // POST: Apartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Piso,Bloque,Estado,Unidad_ResidencialID")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Unidad_ResidencialID"] = new SelectList(_context.Unidad_Residencial, "Id", "Nombre", apartamento.Unidad_ResidencialID);
            return View(apartamento);
        }

        // GET: Apartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento.FindAsync(id);
            if (apartamento == null)
            {
                return NotFound();
            }
            ViewData["Unidad_ResidencialID"] = new SelectList(_context.Unidad_Residencial, "Id", "Nombre", apartamento.Unidad_ResidencialID);
            return View(apartamento);
        }

        // POST: Apartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Piso,Bloque,Estado,Unidad_ResidencialID")] Apartamento apartamento)
        {
            if (id != apartamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartamentoExists(apartamento.Id))
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
            ViewData["Unidad_ResidencialID"] = new SelectList(_context.Unidad_Residencial, "Id", "Nombre", apartamento.Unidad_ResidencialID);
            return View(apartamento);
        }

        // GET: Apartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento
                .Include(a => a.Unidad_Residencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // POST: Apartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartamento = await _context.Apartamento.FindAsync(id);
            _context.Apartamento.Remove(apartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartamentoExists(int id)
        {
            return _context.Apartamento.Any(e => e.Id == id);
        }
    }
}
