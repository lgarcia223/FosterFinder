using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Data
{
    public enum Gender { Male, Female, Other}

    public class Child
    {
        [Key]
        public int ChidId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Child's Name")]
        public string ChildName { get; set; }
        [Required]
        [Display(Name = "Number of Beds needed (siblings?):")]
        public int BedsNeed { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Gender gender;
        [Required]
        public double Age;
        [Display(Name = "School District")]
        public string SchoolDistNeed { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set;}
    }
}
