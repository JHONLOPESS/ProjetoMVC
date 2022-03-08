using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sallers.Data;
using Sallers.Models;

namespace Sallers.Controllers
{
    public class DepartmeentsController : Controller
    {
        private readonly SallersContext _context;

        public DepartmeentsController(SallersContext context)
        {
            _context = context;
        }

        // GET: Departmeents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departmeent.ToListAsync());
        }

        // GET: Departmeents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmeent = await _context.Departmeent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmeent == null)
            {
                return NotFound();
            }

            return View(departmeent);
        }

        // GET: Departmeents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departmeents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departmeent departmeent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmeent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmeent);
        }

        // GET: Departmeents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmeent = await _context.Departmeent.FindAsync(id);
            if (departmeent == null)
            {
                return NotFound();
            }
            return View(departmeent);
        }

        // POST: Departmeents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Departmeent departmeent)
        {
            if (id != departmeent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmeent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmeentExists(departmeent.Id))
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
            return View(departmeent);
        }

        // GET: Departmeents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmeent = await _context.Departmeent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmeent == null)
            {
                return NotFound();
            }

            return View(departmeent);
        }

        // POST: Departmeents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmeent = await _context.Departmeent.FindAsync(id);
            _context.Departmeent.Remove(departmeent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmeentExists(int id)
        {
            return _context.Departmeent.Any(e => e.Id == id);
        }
    }
}
