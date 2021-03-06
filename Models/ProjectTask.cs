﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Planny.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        [Required] 
        [StringLength(255)]
        [RegularExpression(@"^[A-Za-z0-9_'\s-]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]

        public string Name { get; set; }

        
        public UserJourney UserJourney { get; set; }
        [Required]
        public int UserJourneyId { get; set; }
        [Required]
        [StringLength(1000)]
        [Display(Name = "Description")] //exemplu
        public string Description { get; set; }

        public Status Status { get; set; }
        public int? StatusId { get; set; }
        public Priority Priority { get; set; }
        public int? PriorityId { get; set; }


    }
}