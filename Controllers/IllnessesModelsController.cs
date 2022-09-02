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
    public class IllnessesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IllnessesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IllnessesModels
        public async Task<IActionResult> Index()
        {
              return _context.IllnessesModel != null ? 
                          View(await _context.IllnessesModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.IllnessesModel'  is null.");
        }

        // GET: IllnessesModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.IllnessesModel == null)
            {
                return NotFound();
            }

            var illnessesModel = await _context.IllnessesModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (illnessesModel == null)
            {
                return NotFound();
            }

            return View(illnessesModel);
        }

        // GET: IllnessesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IllnessesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IllnessesType")] IllnessesModel illnessesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(illnessesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(illnessesModel);
        }

        // GET: IllnessesModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.IllnessesModel == null)
            {
                return NotFound();
            }

            var illnessesModel = await _context.IllnessesModel.FindAsync(id);
            if (illnessesModel == null)
            {
                return NotFound();
            }
            return View(illnessesModel);
        }

        // POST: IllnessesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,IllnessesType")] IllnessesModel illnessesModel)
        {
            if (id != illnessesModel.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(illnessesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IllnessesModelExists(illnessesModel.Name))
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
            return View(illnessesModel);
        }

        // GET: IllnessesModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.IllnessesModel == null)
            {
                return NotFound();
            }

            var illnessesModel = await _context.IllnessesModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (illnessesModel == null)
            {
                return NotFound();
            }

            return View(illnessesModel);
        }

        // POST: IllnessesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.IllnessesModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.IllnessesModel'  is null.");
            }
            var illnessesModel = await _context.IllnessesModel.FindAsync(id);
            if (illnessesModel != null)
            {
                _context.IllnessesModel.Remove(illnessesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IllnessesModelExists(string id)
        {
          return (_context.IllnessesModel?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
