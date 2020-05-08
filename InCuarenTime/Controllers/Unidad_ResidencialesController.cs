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
    public class Unidad_ResidencialesController : Controller
    {
        private readonly InCuarenTimeContext _context;

        public Unidad_ResidencialesController(InCuarenTimeContext context)
        {
            _context = context;
        }

        // GET: Unidad_Residenciales
        public async Task<IActionResult> Index()
        {
            var inCuarenTimeContext = _context.Unidad_Residencial.Include(u => u.Ciudad);
            return View(await inCuarenTimeContext.ToListAsync());
        }

        // GET: Unidad_Residenciales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Residencial = await _context.Unidad_Residencial
                .Include(u => u.Ciudad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad_Residencial == null)
            {
                return NotFound();
            }

            return View(unidad_Residencial);
        }

        // GET: Unidad_Residenciales/Create
        public IActionResult Create()
        {
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "Id", "Nombre");
            return View();
        }

        // POST: Unidad_Residenciales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Telefono,Estado,CiudadID")] Unidad_Residencial unidad_Residencial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidad_Residencial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "Id", "Nombre", unidad_Residencial.CiudadID);
            return View(unidad_Residencial);
        }

        // GET: Unidad_Residenciales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Residencial = await _context.Unidad_Residencial.FindAsync(id);
            if (unidad_Residencial == null)
            {
                return NotFound();
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "Id", "Nombre", unidad_Residencial.CiudadID);
            return View(unidad_Residencial);
        }

        // POST: Unidad_Residenciales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Telefono,Estado,CiudadID")] Unidad_Residencial unidad_Residencial)
        {
            if (id != unidad_Residencial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad_Residencial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Unidad_ResidencialExists(unidad_Residencial.Id))
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
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "Id", "Nombre", unidad_Residencial.CiudadID);
            return View(unidad_Residencial);
        }

        // GET: Unidad_Residenciales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Residencial = await _context.Unidad_Residencial
                .Include(u => u.Ciudad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad_Residencial == null)
            {
                return NotFound();
            }

            return View(unidad_Residencial);
        }

        // POST: Unidad_Residenciales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidad_Residencial = await _context.Unidad_Residencial.FindAsync(id);
            _context.Unidad_Residencial.Remove(unidad_Residencial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Unidad_ResidencialExists(int id)
        {
            return _context.Unidad_Residencial.Any(e => e.Id == id);
        }
    }
}
