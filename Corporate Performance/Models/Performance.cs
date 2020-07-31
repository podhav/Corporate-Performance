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
        [Display(Name = "KPA")]
        public int KPAId { get; set; }

        [ForeignKey("KPAId")]
        public virtual KPA KPA { get; set; }

        [Required]
        [Display(Name = "KPI")]
        public int KPIId { get; set; }

        [ForeignKey("KPIId")]
        public virtual KPI KPI { get; set; }

        [Display(Name ="Qrt1 Target")]
        public int Qrt1Target { get; set; }

        [Display(Name = "Qrt1 Actual")]
        public int Qrt1Actual { get; set; }

        [Display(Name = "Qrt2 Target")]
        public int Qrt2Target { get; set; }

        [Display(Name = "Qrt2 Actual")]
        public int Qrt2Actual { get; set; }

        [Display(Name = "Qrt3 Target")]
        public int Qrt3Target { get; set; }

        [Display(Name = "Qrt3 Actual")]
        public int Qrt3Actual { get; set; }

        [Display(Name = "Qrt4 Target")]
        public int Qrt4Target { get; set; }

        [Display(Name = "Qrt4 Actual")]
        public int Qrt4Actual { get; set; }

        [Display(Name = "Qrt1 Deviation ")]        
        public int Qrt1Deviation { get; set; }

        [Display(Name = "Qrt2 Deviation ")]        
        public int Qrt2Deviation { get; set; }

        [Display(Name = "Qrt3 Deviation ")]       
        public int Qrt3Deviation { get; set; }

        [Display(Name = "Qrt4 Deviation ")]       
        public int Qrt4Deviation { get; set; }

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

        public ICollection<Files> Files { get; set; }

    }
}
