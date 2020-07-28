using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate_Performance.Models
{
    public class Files
    {
        [Key]      
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }
        [NotMapped]
        [Display(Name ="Upload Files")]
        public IFormFile File { get; set; }
        [Display(Name = "Performance")]
        public int PerformanceId { get; set; }
        [ForeignKey("PerformanceId")]
        public virtual Performance Performance { get; set; }
    }
}
