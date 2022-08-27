using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class DoctorModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DoctorModels
        public async Task<IActionResult> Index()
        {
              return _context.DoctorModels != null ? 
                          View(await _context.DoctorModels.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DoctorModels'  is null.");
        }

        // GET: DoctorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorModels == null)
            {
                return NotFound();
            }

            var doctorModels = await _context.DoctorModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorModels == null)
            {
                return NotFound();
            }

            return View(doctorModels);
        }

        // GET: DoctorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Specialing,Experience")] DoctorModels doctorModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorModels);
        }

        // GET: DoctorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorModels == null)
            {
                return NotFound();
            }

            var doctorModels = await _context.DoctorModels.FindAsync(id);
            if (doctorModels == null)
            {
                return NotFound();
            }
            return View(doctorModels);
        }

        // POST: DoctorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Specialing,Experience")] DoctorModels doctorModels)
        {
            if (id != doctorModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorModelsExists(doctorModels.Id))
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
            return View(doctorModels);
        }

        // GET: DoctorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorModels == null)
            {
                return NotFound();
            }

            var doctorModels = await _context.DoctorModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorModels == null)
            {
                return NotFound();
            }

            return View(doctorModels);
        }

        // POST: DoctorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorModels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DoctorModels'  is null.");
            }
            var doctorModels = await _context.DoctorModels.FindAsync(id);
            if (doctorModels != null)
            {
                _context.DoctorModels.Remove(doctorModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorModelsExists(int id)
        {
          return (_context.DoctorModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
