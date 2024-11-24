using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolProjectASPNET.Data;
using SchoolProjectASPNET.Models;

namespace SchoolProjectASPNET.Controllers
{
    public class AlumnoGradosController : Controller
    {
        private readonly SchoolDbContext _context;

        public AlumnoGradosController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: AlumnoGrados
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlumnoGrados.ToListAsync());
        }

        // GET: AlumnoGrados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnoGrado = await _context.AlumnoGrados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnoGrado == null)
            {
                return NotFound();
            }

            return View(alumnoGrado);
        }

        // GET: AlumnoGrados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlumnoGrados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlumnoId,GradoId,Seccion")] AlumnoGrado alumnoGrado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnoGrado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumnoGrado);
        }

        // GET: AlumnoGrados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);
            if (alumnoGrado == null)
            {
                return NotFound();
            }
            return View(alumnoGrado);
        }

        // POST: AlumnoGrados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlumnoId,GradoId,Seccion")] AlumnoGrado alumnoGrado)
        {
            if (id != alumnoGrado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnoGrado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoGradoExists(alumnoGrado.Id))
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
            return View(alumnoGrado);
        }

        // GET: AlumnoGrados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnoGrado = await _context.AlumnoGrados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnoGrado == null)
            {
                return NotFound();
            }

            return View(alumnoGrado);
        }

        // POST: AlumnoGrados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);
            if (alumnoGrado != null)
            {
                _context.AlumnoGrados.Remove(alumnoGrado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoGradoExists(int id)
        {
            return _context.AlumnoGrados.Any(e => e.Id == id);
        }
    }
}
