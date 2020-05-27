using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models
{
    public enum Quarter
    {
        Qrt1 = 1,
        Qrt2 = 2,
        Qrt3 = 3,
        Qrt4 = 4
    }
    public class Period
    {
        [Key]
        public int Id { get; set; }

        public Quarter Quarter { get; set; }

        [Required(ErrorMessage = "Please enter Start Date.")]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime QrtStartDate { get; set; }

        [Required(ErrorMessage = "Please enter End Date.")]
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        public DateTime QrtEndDate { get; set; }
    }
}
