using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate_Performance.Data;
using Corporate_Performance.Models;
using Corporate_Performance.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Corporate_Performance.Area.Admin.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            var kpi = await _db.KPI.Include(s => s.Programme).ToListAsync();
            return View(kpi);

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
