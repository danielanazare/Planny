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
        [RegularExpression(@"^[A-Za-z0-9_'\s-]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]

        public string  Name { get; set; }
    }
}