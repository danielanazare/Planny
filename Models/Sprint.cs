﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planny.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public Release Release { get; set; }
        public int ReleaseID { get; set; }
        public Project Project { get; set; }
        public int ProjectID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Effort { get; set; } // nr de ore
        public int TimeSpent { get; set; }
        public byte Progress { get; set; } //0-100 %
    }
}