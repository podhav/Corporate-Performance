using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models
{
    public class Programme
    {
        [Key]
        public int Id{ get; set; }
        
        [Display(Name="Programme Name")]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public bool checkBoxProgramme { get; set; }

    }

}
