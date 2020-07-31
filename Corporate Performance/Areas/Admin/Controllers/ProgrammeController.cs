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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Corporate_Performance.Area.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class ProgrammeController : Controller
    {
        private readonly ApplicationDbContext _db;       
        public ProgrammeController(ApplicationDbContext db)
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

            var Programme = from s in _db.Programme
                      select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Programme = Programme.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Programme = Programme.OrderByDescending(s => s.Name);
                    break;
                default:
                    Programme = Programme.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Programme>.CreateAsync(Programme.AsNoTracking(), pageNumber ?? 1, pageSize));
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