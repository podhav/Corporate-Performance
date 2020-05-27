using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models
{
    public class Fiscal
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression("^20[1-9][0-9]$")]
        [DisplayName("Fiscal Year")]
        public int FiscalYear { get; set; }

        [Required(ErrorMessage = "Please enter Start Date.")]
        [DisplayName("Fiscal Year Start Date")]
        [DataType(DataType.Date)]
        public DateTime YearStartDate { get; set; }

        [Required(ErrorMessage = "Please enter End Date.")]
        [DisplayName("Fiscal Year End Date")]
        [DataType(DataType.Date)]
        public DateTime YearEndDate { get; set; }
    }
}
