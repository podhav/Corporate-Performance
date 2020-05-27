using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models.ViewModels
{
    public class KPIandProgrammeModel
    {
        public IEnumerable<Programme> ProgrammeList { get; set; }
        public KPI KPI { get; set; }
        public string StatusMessage { get; set; }
    }
}
