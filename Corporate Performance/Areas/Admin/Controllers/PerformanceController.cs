using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Corporate_Performance.Data;
using Corporate_Performance.Models;
using Corporate_Performance.Models.ViewModels;
using Corporate_Performance.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace Corporate_Performance.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class PerformanceController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public PerformanceViewModel PerformanceVM { get; set; }


        public PerformanceController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            PerformanceVM = new PerformanceViewModel()
            {
                KPI = _db.KPI,
                KPA = _db.KPA,
                Fiscal = _db.Fiscal,
                Performance = new Models.Performance()
            };
        }

        public async Task<IActionResult> Index()
        {
            var performance = await _db.Performance.Include(p => p.Fiscal).Include(p => p.KPA).Include(p => p.KPI).ToListAsync();
            return View(performance);
        }

        public IActionResult Images(int id)
        {
            Performance images = _db.Performance.SingleOrDefault(img=>img.Id==id);
            return View(images);
        }

        //GET-CREATE

        public IActionResult Create()
        {
            return View(PerformanceVM);
        }

        //CREATE-POST

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(PerformanceVM);
            }
           

            _db.Performance.Add(PerformanceVM.Performance);
            
            await _db.SaveChangesAsync();

            //image saving section

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var performanceItemfromDb = await _db.Performance.FindAsync(PerformanceVM.Performance.Id);

            if (files.Count>0)
            {
                //files have been uploaded

                var uploads = Path.Combine(webRootPath,"images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, PerformanceVM.Performance.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                //performanceItemfromDb.Files = @"\images\" + PerformanceVM.Performance.Id + extension;
            }
                        
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET-EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PerformanceVM.Performance = await _db.Performance.Include(p => p.Fiscal).Include(p => p.KPA).Include(p => p.KPI).SingleOrDefaultAsync(p => p.Id == id);

            return View(PerformanceVM);
        }

        //POST-EDIT

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                               
                return View(PerformanceVM);
            }

            //image saving section

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var performanceItemfromDb = await _db.Performance.FindAsync(PerformanceVM.Performance.Id);

            if (files.Count > 0)
            {
                //files have been uploaded

                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, PerformanceVM.Performance.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                //performanceItemfromDb.Files = @"\images\" + PerformanceVM.Performance.Id + extension;
            }
            performanceItemfromDb.FiscalId = PerformanceVM.Performance.FiscalId;
            performanceItemfromDb.KPAId = PerformanceVM.Performance.KPAId;
            performanceItemfromDb.KPIId = PerformanceVM.Performance.KPIId;
            performanceItemfromDb.Comments = PerformanceVM.Performance.Comments;
            performanceItemfromDb.Qrt1Target = PerformanceVM.Performance.Qrt1Target;
            performanceItemfromDb.Qrt2Target = PerformanceVM.Performance.Qrt2Target;
            performanceItemfromDb.Qrt3Target = PerformanceVM.Performance.Qrt3Target;
            performanceItemfromDb.Qrt4Target = PerformanceVM.Performance.Qrt4Target;
            performanceItemfromDb.AnnualTarget = PerformanceVM.Performance.Qrt1Target +
                                                 PerformanceVM.Performance.Qrt2Target +
                                                 PerformanceVM.Performance.Qrt3Target +
                                                 PerformanceVM.Performance.Qrt4Target;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET : Details 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PerformanceVM.Performance = await _db.Performance.Include(p => p.Fiscal).Include(p => p.KPA).Include(p => p.KPI).SingleOrDefaultAsync(p => p.Id == id);

            if (PerformanceVM.Performance == null)
            {
                return NotFound();
            }

            return View(PerformanceVM);
        }

        //GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PerformanceVM.Performance = await _db.Performance.Include(p => p.Fiscal).Include(p => p.KPA).Include(p => p.KPI).SingleOrDefaultAsync(p => p.Id == id);
            if (PerformanceVM == null)
            {
                return NotFound();
            }

            return View(PerformanceVM);
        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performance = await _db.Performance.SingleOrDefaultAsync(m => m.Id == id);
            _db.Performance.Remove(performance);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
