using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate_Performance.Data;
using Corporate_Performance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Corporate_Performance.Area.Admin.Controllers
{
    [Area("Admin")]
    public class ProgrammeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProgrammeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _db.Programme.ToListAsync());
        }

        //GET FOR CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Programme programme)
        {
            if (ModelState.IsValid)
            {
                //if valid
                _db.Programme.Add(programme);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programme);
        }

        //GET  EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var programme = await _db.Programme.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }
            return View(programme);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Programme programme)
        {
            if (ModelState.IsValid)
            {
                _db.Update(programme);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programme);
        }

        //GET DELETE 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var programme = await _db.Programme.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }
            return View(programme);
        }

        //POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var programme = await _db.Programme.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }
            _db.Programme.Remove(programme);
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
            var programme = await _db.Programme.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }
            return View(programme);
        }

    }
}