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
    public class PrescriptionsModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrescriptionsModels
        public async Task<IActionResult> Index(string patientId)
        {
            var Prescriptions = from m in _context.PrescriptionsModel
                         select m;

            if (!String.IsNullOrEmpty(patientId))
            {
                Prescriptions = Prescriptions.Where(s => s.Name!.Contains(patientId));
            }

            return View(await Prescriptions.ToListAsync());

        }

        // GET: PrescriptionsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrescriptionsModel == null)
            {
                return NotFound();
            }

            var prescriptionsModel = await _context.PrescriptionsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescriptionsModel == null)
            {
                return NotFound();
            }

            return View(prescriptionsModel);
        }

        // GET: PrescriptionsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrescriptionsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PrescriptionsModel prescriptionsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescriptionsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prescriptionsModel);
        }

        // GET: PrescriptionsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrescriptionsModel == null)
            {
                return NotFound();
            }

            var prescriptionsModel = await _context.PrescriptionsModel.FindAsync(id);
            if (prescriptionsModel == null)
            {
                return NotFound();
            }
            return View(prescriptionsModel);
        }

        // POST: PrescriptionsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PrescriptionsModel prescriptionsModel)
        {
            if (id != prescriptionsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescriptionsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionsModelExists(prescriptionsModel.Id))
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
            return View(prescriptionsModel);
        }

        // GET: PrescriptionsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrescriptionsModel == null)
            {
                return NotFound();
            }

            var prescriptionsModel = await _context.PrescriptionsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescriptionsModel == null)
            {
                return NotFound();
            }

            return View(prescriptionsModel);
        }

        // POST: PrescriptionsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrescriptionsModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PrescriptionsModel'  is null.");
            }
            var prescriptionsModel = await _context.PrescriptionsModel.FindAsync(id);
            if (prescriptionsModel != null)
            {
                _context.PrescriptionsModel.Remove(prescriptionsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionsModelExists(int id)
        {
          return (_context.PrescriptionsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
