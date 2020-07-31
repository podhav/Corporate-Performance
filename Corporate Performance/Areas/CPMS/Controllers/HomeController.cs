using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Corporate_Performance.Models;
using Corporate_Performance.Models.ViewModels;
using Corporate_Performance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using Corporate_Performance.Extensions;

namespace Corporate_Performance.Controllers
{
    [Area("CPMS")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public IndexViewModel IndexVM { get; set; }

        public HomeController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            IndexVM = new IndexViewModel()
            {
                KPI = _db.KPI,
                KPA = _db.KPA,
                Fiscal = _db.Fiscal,
                Programme = _db.Programme,
                Files = new Models.Files(),
                Performance = new Models.Performance()
            };
        }
        public async Task<IActionResult> Index()
        {
            IndexVM.performance = await _db.Performance.Include(p => p.Fiscal).Include(p => p.KPA).Include(p => p.KPI).ToListAsync();
                
            return View(IndexVM);
        }
               
        //GET : Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IndexVM.Performance = await _db.Performance
                .Include(p => p.Fiscal)
                .Include(p => p.KPI.Programme)
                .Include(p => p.KPA)
                .Include(p => p.KPI)
                .Include(p => p.Files)
                .SingleOrDefaultAsync(p => p.Id == id);
            return View(IndexVM);
        }

        //POST-EDIT

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? Id, IFormFile files)
        {
            if (!ModelState.IsValid)

            {
                return View(IndexVM);
            }

            //Work on the image saving section

            var performanceItemfromDb = await _db.Performance.FindAsync(IndexVM.Performance.Id);

            if (files != null)
            {
                var file = HttpContext.Request.Form.Files;

                if (files.Length > 0)

                {
                    //files has been uploaded

                    var fileName = Path.GetFileName(files.FileName);
                    var fileExtension = Path.GetExtension(file[0].FileName);

                    var objfiles = new Files()
                    {
                        FileName = fileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now,
                        PerformanceId = IndexVM.Performance.Id
                    };
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFiles = target.ToArray();
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Content/Files", files.FileName);

                    var stream = new FileStream(path, FileMode.Create);
                    {
                        files.CopyTo(stream);
                    }
                    await _db.Files.AddAsync(objfiles);
                }
            }
            { 
            performanceItemfromDb.FiscalId = IndexVM.Performance.FiscalId;
            performanceItemfromDb.KPAId = IndexVM.Performance.KPAId;
            performanceItemfromDb.KPIId = IndexVM.Performance.KPIId;
            performanceItemfromDb.Qrt1Actual = IndexVM.Performance.Qrt1Actual;
            performanceItemfromDb.Qrt1Deviation = IndexVM.Performance.Qrt1Actual - IndexVM.Performance.Qrt1Target;
            performanceItemfromDb.Qrt2Actual = IndexVM.Performance.Qrt2Actual;
            performanceItemfromDb.Qrt2Deviation = IndexVM.Performance.Qrt2Actual - IndexVM.Performance.Qrt2Target;
            performanceItemfromDb.Qrt3Actual = IndexVM.Performance.Qrt3Actual;
            performanceItemfromDb.Qrt3Deviation = IndexVM.Performance.Qrt3Actual - IndexVM.Performance.Qrt3Target;
            performanceItemfromDb.Qrt4Actual = IndexVM.Performance.Qrt4Actual;
            performanceItemfromDb.Qrt4Deviation = IndexVM.Performance.Qrt4Actual - IndexVM.Performance.Qrt4Target;
            performanceItemfromDb.AnnualActual = IndexVM.Performance.Qrt1Actual+
                                                 IndexVM.Performance.Qrt2Actual+
                                                 IndexVM.Performance.Qrt3Actual+
                                                 IndexVM.Performance.Qrt4Actual;
            performanceItemfromDb.AnnualDeviation = IndexVM.Performance.AnnualActual - IndexVM.Performance.AnnualTarget;
            performanceItemfromDb.CorrectiveAction = IndexVM.Performance.CorrectiveAction;
            performanceItemfromDb.Comments = IndexVM.Performance.Comments;

            await _db.SaveChangesAsync();
        }  
            return RedirectToAction(nameof(Index));          
    }
      
        // DOWNLOAD FILE FROM DB

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Content/Files", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        //GET : Details 
        [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var performance = await _db.Performance.Include(p => p.Fiscal).Include(p => p.KPA).Include(p => p.KPI).Include(p => p.KPI.Programme).SingleOrDefaultAsync(p => p.Id == id);

        if (performance == null)
        {
            return NotFound();
        }

        return View(performance);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
}
