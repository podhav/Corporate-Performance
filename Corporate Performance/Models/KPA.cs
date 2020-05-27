using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models
{
    public class KPA
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "KPA Name")]
        [Required]
        public string Name { get; set; }

    }
}
