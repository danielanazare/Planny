using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Planny.Models
{
    public class Time
    {
        public int Id { get; set; }
        public ProjectTask Task { get; set; }
        public int TaskID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int TimeSpent { get; set; }
        
    }
}