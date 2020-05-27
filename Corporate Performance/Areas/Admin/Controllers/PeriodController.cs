using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate_Performance.Data;
using Corporate_Performance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Corporate_Performance.Area.Admin.Controllers
{
    [Area("Admin")]
    public class PeriodController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PeriodController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _db.Period.ToListAsync());
        }

        //GET FOR CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Period period)
        {
            if (ModelState.IsValid)
            {
                //if valid
                _db.Period.Add(period);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(period);
        }

        //GET  EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var period = await _db.Period.FindAsync(id);
            if (period == null)
            {
                return NotFound();
            }
            return View(period);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Period period)
        {
            if (ModelState.IsValid)
            {
                _db.Update(period);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(period);
        }

        //GET DELETE 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var period = await _db.Period.FindAsync(id);
            if (period == null)
            {
                return NotFound();
            }
            return View(period);
        }

        //POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var period = await _db.Period.FindAsync(id);
            if (period == null)
            {
                return NotFound();
            }
            _db.Period.Remove(period);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var period = await _db.Period.FindAsync(id);
            if (period == null)
            {
                return NotFound();
            }
            return View(period);
        }

    }
}