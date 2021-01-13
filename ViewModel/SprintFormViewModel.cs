using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class SprintFormViewModel
    {
        public Sprint Sprint { get; set; }
        public IEnumerable<Release> Releases { get; set; }

        public string Title
        {
            get
            {
                if (Sprint != null && Sprint.Id != 0)
                    return "Edit Sprint";

                return "New Sprint";
            }
        }
    }
}