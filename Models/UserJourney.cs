using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planny.Models
{
    public class UserJourney
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public int ProjectID { get; set; }
        public Release Release { get; set; }
        public int ReleaseID { get; set; }
        public Sprint Sprint { get; set; }
        public int SprintID { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int StatusID { get; set; }
        public Priority Priority { get; set; }
        public int PriorityID { get; set; }
    }
}