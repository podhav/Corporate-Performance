using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models
{
    public class Performance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fiscal Year")]
        public int FiscalId { get; set; }

        [ForeignKey("FiscalId")]
        public virtual Fiscal Fiscal { get; set; }

        [Required]
        [Display(Name = "Period")]
        public int PeriodId { get; set; }

        [ForeignKey("PeriodId")]
        public virtual Period Period { get; set; }

        [Required]
        [Display(Name = "KPA")]
        public int KPAId { get; set; }

        [ForeignKey("KPAId")]
        public virtual KPA KPA { get; set; }

        [Required]
        [Display(Name = "KPI")]
        public int KPIId { get; set; }

        [ForeignKey("KPIId")]
        public virtual KPI KPI { get; set; }

        [Required]
        [Display(Name = "Programme")]
        public int ProgramId { get; set; }

        [ForeignKey("ProgramId")]
        public virtual Programme Programme { get; set; }


        [Display(Name ="Quarter Target")]
        public int QrtTarget { get; set; }

        [Display(Name = "Quarter Actual")]
        public int QrtActual { get; set; }

        [Display(Name = "Quarterly Deviation ")]
        public int QrtDeviation { get; set; }

        [Display(Name = "Annual Target")]
        public int AnnualTarget { get; set; }

        [Display(Name = "Annual Actual")]
        public int AnnualActual { get; set; }

        [Display(Name = "Annual Deviation")]
        public int AnnualDeviation { get; set; }

        [Display(Name = "Corrective Action")]
        public string CorrectiveAction { get; set; }

        [Display(Name = "Comments")]          
        public string Comments { get; set; }

        [Display(Name = "POE Attachments")]
        public string Files { get; set; }

    }
}
