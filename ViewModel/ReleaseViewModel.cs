using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Controllers;
using Planny.Models;

namespace Planny.ViewModel
{
    public class ReleaseViewModel
    {
        public Release Release { get; set; }
        public IEnumerable<Sprint> Sprintses { get; set; }

    }
}