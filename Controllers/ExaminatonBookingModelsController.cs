using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Data.Migrations;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class ExaminatonBookingModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExaminatonBookingModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExaminatonBookingModels
        public async Task<IActionResult> Index(string patientId)
        {
            var examinatonBookingModel = from m in _context.ExaminatonBookingModel
                                select m;

            if (!String.IsNullOrEmpty(patientId))
            {
                examinatonBookingModel = examinatonBookingModel.Where(s => s.Name!.Contains(patientId));
            }
            
            return View(await examinatonBookingModel.ToListAsync());

        }

        // GET: ExaminatonBookingModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExaminatonBookingModel == null)
            {
                return NotFound();
            }

            var examinatonBookingModel = await _context.ExaminatonBookingModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examinatonBookingModel == null)
            {
                return NotFound();
            }

            return View(examinatonBookingModel);
        }

        // GET: ExaminatonBookingModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExaminatonBookingModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Illness,Title")] ExaminatonBookingModel examinatonBookingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examinatonBookingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examinatonBookingModel);
        }

        // GET: ExaminatonBookingModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExaminatonBookingModel == null)
            {
                return NotFound();
            }

            var examinatonBookingModel = await _context.ExaminatonBookingModel.FindAsync(id);
            if (examinatonBookingModel == null)
            {
                return NotFound();
            }
            return View(examinatonBookingModel);
        }

        // POST: ExaminatonBookingModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Illness,Title")] ExaminatonBookingModel examinatonBookingModel)
        {
            if (id != examinatonBookingModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examinatonBookingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExaminatonBookingModelExists(examinatonBookingModel.Id))
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
            return View(examinatonBookingModel);
        }

        // GET: ExaminatonBookingModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExaminatonBookingModel == null)
            {
                return NotFound();
            }

            var examinatonBookingModel = await _context.ExaminatonBookingModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examinatonBookingModel == null)
            {
                return NotFound();
            }

            return View(examinatonBookingModel);
        }

        // POST: ExaminatonBookingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExaminatonBookingModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExaminatonBookingModel'  is null.");
            }
            var examinatonBookingModel = await _context.ExaminatonBookingModel.FindAsync(id);
            if (examinatonBookingModel != null)
            {
                _context.ExaminatonBookingModel.Remove(examinatonBookingModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExaminatonBookingModelExists(int id)
        {
          return (_context.ExaminatonBookingModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
