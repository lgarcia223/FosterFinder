using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Data
{
    public enum ChildGender { Male, Female, [Display(Name = "N/A")] NA };

    public class Child
    {
        [Key]
        public int ChildId { get; set; }
        [Required]
        public Guid UserId { get; set; }
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

        [Display(Name = "Case Worker Name")]
        public string CaseworkerName { get; set; }

        [Display(Name = "Case Worker Contact")]
        public string CaseworkerContact { get; set; }


    }
}
