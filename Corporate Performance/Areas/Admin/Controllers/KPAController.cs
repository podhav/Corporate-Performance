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
    public class KPAController : Controller
    {
        private readonly ApplicationDbContext _db;

        public KPAController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _db.KPA.ToListAsync());
        }
        //GET FOR CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KPA kpa)
        {
            if (ModelState.IsValid)
            {
                //if valid
                _db.KPA.Add(kpa);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kpa);
        }

        //GET  EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kpa = await _db.KPA.FindAsync(id);
            if (kpa == null)
            {
                return NotFound();
            }
            return View(kpa);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KPA kpa)
        {
            if (ModelState.IsValid)
            {
                _db.Update(kpa);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kpa);
        }

        //GET DELETE 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kpa = await _db.KPA.FindAsync(id);
            if (kpa == null)
            {
                return NotFound();
            }
            return View(kpa);
        }

        //POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var kpa = await _db.KPA.FindAsync(id);
            if (kpa == null)
            {
                return NotFound();
            }
            _db.KPA.Remove(kpa);
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
            var kpa = await _db.KPA.FindAsync(id);
            if (kpa == null)
            {
                return NotFound();
            }
            return View(kpa);
        }

    }
}
