using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planny.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [RegularExpression("^[a - zA - Z0 - 9]{4, 10}$", ErrorMessage = "Name must have only letters and numbers")]

        public string  Name { get; set; }
    }
}