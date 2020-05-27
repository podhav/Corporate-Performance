using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models
{
    public class KPI
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "KPI Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Programme")]
        public int ProgrammeId { get; set; }

        [ForeignKey("ProgrammeId")]
        public virtual Programme Programme { get; set; }


    }
}
