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
    public class TarjetasController : Controller
    {
        private readonly UVirtualContext _context;

        public TarjetasController(UVirtualContext context)
        {
            _context = context;
        }

        // GET: Tarjetas
        public async Task<IActionResult> Index()
        {
            var uVirtualContext = _context.Tarjeta.Include(t => t.Personaje).Include(t => t.Respuesta).Include(t => t.Respuesta2).Include(t => t.Situacion);
            return View(await uVirtualContext.ToListAsync());
        }

        // GET: Tarjetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta
                .Include(t => t.Personaje)
                .Include(t => t.Respuesta)
                .Include(t => t.Respuesta2)
                .Include(t => t.Situacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return View(tarjeta);
        }

        // GET: Tarjetas/Create
        public IActionResult Create()
        {
            ViewData["PersonajeID"] = new SelectList(_context.Personaje, "Id", "Nombre");
            ViewData["SituacionID"] = new SelectList(_context.Situacion, "Id", "Titulo");
            ViewData["RespuestaID"] = new SelectList(_context.Respuesta, "Id", "Texto");
            ViewData["Respuesta2ID"] = new SelectList(_context.Respuesta, "Id", "Texto");
            return View();
        }

        // POST: Tarjetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonajeID,SituacionID,RespuestaID,Respuesta2ID")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonajeID"] = new SelectList(_context.Personaje, "Id", "Nombre", tarjeta.PersonajeID);
            ViewData["SituacionID"] = new SelectList(_context.Situacion, "Id", "Titulo", tarjeta.SituacionID);
            ViewData["RespuestaID"] = new SelectList(_context.Respuesta, "Id", "Texto", tarjeta.RespuestaID);
            ViewData["Respuesta2ID"] = new SelectList(_context.Respuesta, "Id", "Texto", tarjeta.Respuesta2ID);
            return View(tarjeta);
        }

        // GET: Tarjetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta.FindAsync(id);
            if (tarjeta == null)
            {
                return NotFound();
            }
            ViewData["PersonajeID"] = new SelectList(_context.Personaje, "Id", "Nombre", tarjeta.PersonajeID);
            ViewData["SituacionID"] = new SelectList(_context.Situacion, "Id", "Titulo", tarjeta.SituacionID);
            ViewData["RespuestaID"] = new SelectList(_context.Respuesta, "Id", "Texto", tarjeta.RespuestaID);
            ViewData["Respuesta2ID"] = new SelectList(_context.Respuesta, "Id", "Texto", tarjeta.Respuesta2ID);
            return View(tarjeta);
        }

        // POST: Tarjetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonajeID,SituacionID,RespuestaID,Respuesta2ID")] Tarjeta tarjeta)
        {
            if (id != tarjeta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarjeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarjetaExists(tarjeta.Id))
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
            ViewData["PersonajeID"] = new SelectList(_context.Personaje, "Id", "Nombre", tarjeta.PersonajeID);
            ViewData["SituacionID"] = new SelectList(_context.Situacion, "Id", "Titulo", tarjeta.SituacionID);
            ViewData["RespuestaID"] = new SelectList(_context.Respuesta, "Id", "Texto", tarjeta.RespuestaID);
            ViewData["Respuesta2ID"] = new SelectList(_context.Respuesta, "Id", "Texto", tarjeta.Respuesta2ID);
            return View(tarjeta);
        }

        // GET: Tarjetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta
                .Include(t => t.Personaje)
                .Include(t => t.Respuesta)
                .Include(t => t.Respuesta2)
                .Include(t => t.Situacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return View(tarjeta);
        }

        // POST: Tarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarjeta = await _context.Tarjeta.FindAsync(id);
            _context.Tarjeta.Remove(tarjeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarjetaExists(int id)
        {
            return _context.Tarjeta.Any(e => e.Id == id);
        }
    }
}
