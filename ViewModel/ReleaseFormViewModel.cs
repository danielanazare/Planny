using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class ReleaseFormViewModel
    {
        public Release Release { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}