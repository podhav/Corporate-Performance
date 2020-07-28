using AspNetCore;
using Corporate_Performance.Data.Migrations;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models.ViewModels
{
    public class PerformanceViewModel
    {
        public Performance Performance{ get; set; }
        public IEnumerable<KPI> KPI { get; set; }
        public IEnumerable<KPA> KPA { get; set; }
        public IEnumerable<Fiscal> Fiscal{ get; set; }
        public IEnumerable<Programme> Programme { get; set; }
        public IEnumerable<Files> files { get; set; }
      
    }
    
  
}
