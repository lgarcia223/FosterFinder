﻿using FosterFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Models
{
    public class FosterHomeCreate
    {
        
        public int HomeId { get; set; }
        [Required]
        [Display(Name = "Foster Family Name")]
        public string FamilyName { get; set; }
        [Required]
        [Display(Name = "Openings")]
        [Range(0, 5, ErrorMessage = "Please choose a number between 0 and 5")]
        public int OpenBeds { get; set; }
        [Required]
        [Display(Name = "Gender Preference")]
        public ChildGender GenderPref { get; set; }
        [Required]
        [Display(Name = "Minimum Age Preference")]
        [Range(0, 18, ErrorMessage = "Please choose a number between 0 and 18")]
        public double AgePrefMin { get; set; }
        [Required]
        [Display(Name = "Maximum Age Preference")]
        [Range(0, 18, ErrorMessage = "Please choose a number between 0 and 18")]
        public double AgePrefMax { get; set; }
        [Required]
        [Display(Name = "School District")]
        public string SchoolDistrict { get; set; }
        public string Agency { get; set; }

        [Display(Name = "Licensing Worker Name")]
        public string CaseworkerName { get; set; }

        [Display(Name = "Licensing Worker Contact")]
        public string CaseworkerContact { get; set; }

        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string Comments { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }

        [DisplayFormat(DataFormatString = "{mm/dd/yy}")]
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
