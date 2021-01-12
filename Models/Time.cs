using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Planny.Models
{
    public class Time
    {
        public int Id { get; set; }
        [Required]
        public ProjectTask Task { get; set; }
        public int TaskId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int TimeSpent { get; set; }
        
    }
}