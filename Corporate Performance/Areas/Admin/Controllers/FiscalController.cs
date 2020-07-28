using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate_Performance.Data;
using Corporate_Performance.Models;
using Corporate_Performance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Corporate_Performance.Area.Admin.Controllers
{
    
    [Authorize(Roles =SD.ManagerUser)]
    [Area("Admin")]
    public class FiscalController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FiscalController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _db.Fiscal.ToListAsync());
        }

        //GET FOR CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fiscal fiscal)
        {
            if (ModelState.IsValid)
            {
                //if valid
                _db.Fiscal.Add(fiscal);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fiscal);
        }

        //GET  EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fiscal = await _db.Fiscal.FindAsync(id);
            if (fiscal == null)
            {
                return NotFound();
            }
            return View(fiscal);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Fiscal fiscal)
        {
            if (ModelState.IsValid)
            {
                _db.Update(fiscal);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fiscal);
        }

        //GET DELETE 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fiscal = await _db.Fiscal.FindAsync(id);
            if (fiscal == null)
            {
                return NotFound();
            }
            return View(fiscal);
        }

        //POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var fiscal = await _db.Fiscal.FindAsync(id);
            if (fiscal == null)
            {
                return NotFound();
            }
            _db.Fiscal.Remove(fiscal);
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
            var fiscal = await _db.Fiscal.FindAsync(id);
            if (fiscal == null)
            {
                return NotFound();
            }
            return View(fiscal);
        }

    }
}