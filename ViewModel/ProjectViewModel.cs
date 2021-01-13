using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Release> Releases { get; set; }
    }
}