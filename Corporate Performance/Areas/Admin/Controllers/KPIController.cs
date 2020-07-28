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


namespace Corporate_Performance.Area.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class KPIController : Controller
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }

        public KPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public async Task<IActionResult> Index(string sortOrder, int? pageNumber, string currentFilter, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ProgSortParam"] = string.IsNullOrEmpty(sortOrder) ? "prog_desc" : "";
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

            var KPI = from s in _db.KPI.Include(s=>s.Programme)
                      select s;

            if (!String.IsNullOrEmpty(searchString))
            {
               KPI = KPI.Where(s => s.Name.Contains(searchString)
                                       || s.Programme.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    KPI = KPI.OrderByDescending(s => s.Name);                   
                    break;
                case "prog_desc":
                    KPI = KPI.OrderByDescending(s => s.Programme.Name);
                    break;
                default:
                    KPI = KPI.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 4;
            return View(await PaginatedList<KPI>.CreateAsync(KPI.AsNoTracking(), pageNumber ?? 1, pageSize));

        }           

        //GET FOR CREATE
        public async Task<IActionResult> Create()
        {
            KPIandProgrammeModel model = new KPIandProgrammeModel()
            {
                ProgrammeList = await _db.Programme.ToListAsync(),
                KPI = new Models.KPI(),
            };
            return View(model);
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KPIandProgrammeModel model)
        {
            if (ModelState.IsValid)
            {
                var doesKPIExists = _db.KPI.Include(s => s.Programme).Where(s => s.Name == model.KPI.Name && s.Programme.Id == model.KPI.ProgrammeId);

                if (doesKPIExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error : KPI already exists under " + doesKPIExists.First().Programme.Name + " Programme. Please use another name.";
                }
                else
                {
                    _db.KPI.Add(model.KPI);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            KPIandProgrammeModel modelVM = new KPIandProgrammeModel
            {
                ProgrammeList = await _db.Programme.ToListAsync(),
                KPI = model.KPI,
                StatusMessage = StatusMessage
            };
            return View(modelVM);

        }
        //GET  EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kpi = await _db.KPI.SingleOrDefaultAsync(m => m.Id == id);

            if (kpi == null)
            {
                return NotFound();
            }

            KPIandProgrammeModel model = new KPIandProgrammeModel()
            {
                ProgrammeList = await _db.Programme.ToListAsync(),
                KPI = kpi
            };

            return View(model);
        }
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KPIandProgrammeModel model)
        {
            if (ModelState.IsValid)
            {
                var doesKPIExists = _db.KPI.Include(s => s.Programme).Where(s => s.Name == model.KPI.Name && s.Programme.Id == model.KPI.ProgrammeId);

                if (doesKPIExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error : KPI exists under " + doesKPIExists.First().Programme.Name + " programme. Please use another name.";
                }
                else
                {
                    var kpiFromDb = await _db.KPI.FindAsync(id);
                    kpiFromDb.Name = model.KPI.Name;

                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            KPIandProgrammeModel modelVM = new KPIandProgrammeModel()
            {
                ProgrammeList = await _db.Programme.ToListAsync(),
                KPI = model.KPI,
                StatusMessage = StatusMessage
            };
            //modelVM.SubCategory.Id = id;
            return View(modelVM);
        }

        //GET DELETE 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kpi = await _db.KPI.Include(s => s.Programme).SingleOrDefaultAsync(m => m.Id == id);
            if (kpi == null)
            {
                return NotFound();
            }
            return View(kpi);
        }

        //POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var kpi = await _db.KPI.SingleOrDefaultAsync(m => m.Id == id);
            _db.KPI.Remove(kpi);
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
            var kpi = await _db.KPI.Include(s => s.Programme).SingleOrDefaultAsync(m => m.Id == id);
            if (kpi == null)
            {
                return NotFound();
            }
            return View(kpi);
        }

    }
}
