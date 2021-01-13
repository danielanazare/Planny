using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planny.Models
{
    public class Release
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Project Project { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int Effort { get; set; } // nr de ore
        public int TimeSpent { get; set; }
        public byte Progress { get; set; } //0-100 %
        
    }
}