using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class ProjectTaskViewModel
    {
        public ProjectTask ProjectTask { get; set; }
        public IEnumerable<Time> Times { get; set; }
    }
}