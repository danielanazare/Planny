using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planny.Models
{
    public class UserJourney
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public Sprint Sprint { get; set; }
        public int SprintId { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public Status Status { get; set; }
        public int? StatusId { get; set; }
        public Priority Priority { get; set; }
        public int? PriorityId { get; set; }
    }
}