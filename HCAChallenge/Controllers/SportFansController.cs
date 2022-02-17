using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HCAChallenge.Data;
using HCAChallenge.Models;

namespace HCAChallenge.Controllers
{
    public class SportFansController : Controller
    {
        private readonly SportContext _context;

        public SportFansController(SportContext context)
        {
            _context = context;
        }

        // GET: SportFans
        public async Task<IActionResult> Index()
        {
            return View(await _context.SportsFans.ToListAsync());
        }

        // GET: SportFans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportFan = await _context.SportsFans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sportFan == null)
            {
                return NotFound();
            }

            return View(sportFan);
        }

        // GET: SportFans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportFans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,Birthdate,Sport")] SportFan sportFan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportFan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportFan);
        }

        // GET: SportFans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportFan = await _context.SportsFans.FindAsync(id);
            if (sportFan == null)
            {
                return NotFound();
            }
            return View(sportFan);
        }

        // POST: SportFans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName,Birthdate,Sport")] SportFan sportFan)
        {
            if (id != sportFan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportFan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportFanExists(sportFan.ID))
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
            return View(sportFan);
        }

        // GET: SportFans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportFan = await _context.SportsFans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sportFan == null)
            {
                return NotFound();
            }

            return View(sportFan);
        }

        // POST: SportFans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportFan = await _context.SportsFans.FindAsync(id);
            _context.SportsFans.Remove(sportFan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportFanExists(int id)
        {
            return _context.SportsFans.Any(e => e.ID == id);
        }
    }
}
