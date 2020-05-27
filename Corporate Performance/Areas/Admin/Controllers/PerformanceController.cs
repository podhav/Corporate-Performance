using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate_Performance.Data;
using Corporate_Performance.Models;
using Corporate_Performance.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

namespace Corporate_Performance.Areas.Admin.Controllers
{
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
                KPA =_db.KPA,
                Period = _db.Period,
                Programme =_db.Programme,
                Fiscal= _db.Fiscal,
                Performance = new Models.Performance()
            };
        }

        public async Task<IActionResult> Index()
        {
            var performance = await _db.Performance.Include(p=>p.Period).Include(p=>p.KPA).Include(p=>p.KPI).Include(p =>p.Programme).ToListAsync();
            return View(performance);
        }

        //GET-CREATE
        public IActionResult Create()
        {
            return View(PerformanceVM);
        }

        
    }
}