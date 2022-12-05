using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HenryTest.Models;

namespace HenryTest.Controllers
{
    public class BookandcostsController : Controller
    {
        private readonly cottrelldbContext _context;

        public BookandcostsController(cottrelldbContext context)
        {
            _context = context;
        }

        // GET: Bookandcosts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Bookandcosts.ToListAsync());
        }

        // GET: Bookandcosts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Bookandcosts == null)
            {
                return NotFound();
            }

            var bookandcost = await _context.Bookandcosts
                .FirstOrDefaultAsync(m => m.Bookcode == id);
            if (bookandcost == null)
            {
                return NotFound();
            }

            return View(bookandcost);
        }

        // GET: Bookandcosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookandcosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bookcode,Title,Type,Price")] Bookandcost bookandcost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookandcost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookandcost);
        }

        // GET: Bookandcosts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Bookandcosts == null)
            {
                return NotFound();
            }

            var bookandcost = await _context.Bookandcosts.FindAsync(id);
            if (bookandcost == null)
            {
                return NotFound();
            }
            return View(bookandcost);
        }

        // POST: Bookandcosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Bookcode,Title,Type,Price")] Bookandcost bookandcost)
        {
            if (id != bookandcost.Bookcode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookandcost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookandcostExists(bookandcost.Bookcode))
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
            return View(bookandcost);
        }

        // GET: Bookandcosts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Bookandcosts == null)
            {
                return NotFound();
            }

            var bookandcost = await _context.Bookandcosts
                .FirstOrDefaultAsync(m => m.Bookcode == id);
            if (bookandcost == null)
            {
                return NotFound();
            }

            return View(bookandcost);
        }

        // POST: Bookandcosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Bookandcosts == null)
            {
                return Problem("Entity set 'cottrelldbContext.Bookandcosts'  is null.");
            }
            var bookandcost = await _context.Bookandcosts.FindAsync(id);
            if (bookandcost != null)
            {
                _context.Bookandcosts.Remove(bookandcost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookandcostExists(string id)
        {
          return _context.Bookandcosts.Any(e => e.Bookcode == id);
        }
    }
}
