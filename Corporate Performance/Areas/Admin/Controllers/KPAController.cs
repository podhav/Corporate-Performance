using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate_Performance.Data;
using Corporate_Performance.Models;
using Corporate_Performance.Models.ViewModels;
using Corporate_Performance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Corporate_Performance.Area.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class KPAController : Controller
    {
        private readonly ApplicationDbContext _db;

        public KPAController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public async Task<IActionResult> Index(string sortOrder, int? pageNumber, string currentFilter, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var KPA = from s in _db.KPA
                      select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                KPA = KPA.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    KPA = KPA.OrderByDescending(s => s.Name);
                    break;
                default:
                    KPA = KPA.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<KPA>.CreateAsync(KPA.AsNoTracking(), pageNumber ?? 1, pageSize));
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
