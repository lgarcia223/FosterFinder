using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Models
{
    public class ChildCreate
    {
        [Required]
        [Display(Name = "Child's Name")]
        public string ChildName { get; set; }
        [Required]
        [Display(Name = "Number of Beds Needed (sibling group?)")]
        public int BedsNeed { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public ChildGender ChildGender { get; set; }
        [Required]
        [Display(Name = "Child's Age")]
        [Range(0, 18, ErrorMessage = "Please choose a number between 0 and 18")]
        public double ChildAge { get; set; }
        [Display(Name = "School District")]
        public string SchoolDistNeed { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
