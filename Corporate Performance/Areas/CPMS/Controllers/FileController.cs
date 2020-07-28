using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate_Performance.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Corporate_Performance.Models;
using Microsoft.EntityFrameworkCore;
using Corporate_Performance.Data.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Corporate_Performance.Areas.CPMS.Controllers
{
    [Area("CPMS")]

    public class FileController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        //GET: FILES
        public async Task<IActionResult> Index()
          {
            
            var model = await _db.Files.ToListAsync();
               
            return View(model);
        }
        //GET: FILES
        public async Task<IActionResult>List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _db.Files
                .Include(p => p.Performance)                
                .Where(p => p.PerformanceId.Equals(id)).ToListAsync();

            return View(model);
        }

        //GET:DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var files = await _db.Files.ToListAsync();
            if (files == null)
            {
                return NotFound();
            }
            return View(files);
        }

        //GET:CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST:CREATE

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]

        public IActionResult CreatePOST(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension, DateTime.Now);

                    var objfiles = new Files()
                    {
                        FileName = fileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFiles = target.ToArray();
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Content/Files", files.FileName);

                    var stream = new FileStream(path, FileMode.Create);
                    {
                        files.CopyToAsync(stream);
                    }

                    _db.Files.Add(objfiles);
                    _db.SaveChanges();
                }
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
        //GET DELETE 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var files = await _db.Files.FindAsync(id);
            if (files == null)
            {
                return NotFound();
            }
            return View(files);
        }
        //POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var files = await _db.Files.FindAsync(id);
            if (files == null)
            {
                return NotFound();
            }
            _db.Files.Remove(files);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //GET  EDIT

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var files = await _db.Files.SingleOrDefaultAsync(p => p.Id == id);

            if (files == null)
            {
                return NotFound();
            }
            return View(files);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Files files)
        {
            if (ModelState.IsValid)
            {
                _db.Update(files);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(files);
        }
     

    }
}
