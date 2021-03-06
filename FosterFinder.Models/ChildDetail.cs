﻿using FosterFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Models
{
    public class ChildDetail
    {   
        [Display(Name = "Child ID")]
        public int ChildId { get; set; }
        [Display(Name = "Child's Name")]
        public string ChildName { get; set; }
        [Display(Name = "Sibling Group Size")]
        public int BedsNeed { get; set; }
        [Display(Name = "Gender")]
        public ChildGender ChildGender { get; set; }
        [Display(Name = "Child's Age")]
        public double ChildAge { get; set; }
        [Display(Name = "School District")]
        public string SchoolDistNeed { get; set; }
        public string Comments { get; set; }
        [Display(Name = "Case Worker Name")]
        public string CaseworkerName { get; set; }
        [Display(Name = "Case Worker Contact")]
        public string CaseworkerContact { get; set; }
        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }


        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
