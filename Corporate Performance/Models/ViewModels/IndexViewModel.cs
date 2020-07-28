using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models.ViewModels
{
    public class IndexViewModel : PerformanceViewModel
    {
        public IEnumerable<Performance> performance { get; set; }
        public Files Files { get; set; }
    }
}