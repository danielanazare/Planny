using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planny.Models;

namespace Planny.ViewModel
{
    public class TimeFormViewModel
    {
        public Time Time { get; set; }
        public IEnumerable<ProjectTask> ProjectTasks { get; set; }
        

        public string Title
        {
            get
            {
                if (Time != null && Time.Id != 0)
                    return "Edit Time";

                return "New Time";
            }
        }
    }
}