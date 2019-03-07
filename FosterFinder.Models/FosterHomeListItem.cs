using FosterFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Models
{
    public class FosterHomeListItem
    {
        public int HomeId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Foster Family Name")]
        public string FamilyName { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Please choose a number between 0 and 5")]
        [Display(Name = "# of Openings")]
        public int OpenBeds { get; set; }
        [Required]
        [Display(Name = "Gender Preference")]
        public GenderPref GenderPref { get; set; }
        [Required]
        [Range(0, 18, ErrorMessage = "Please choose a number between 0 and 18")]
        [Display(Name = "Minimum Age Preference")]
        public double AgePrefMin { get; set; }
        [Required]
        [Range(0, 18, ErrorMessage = "Please choose a number between 0 and 18")]
        [Display(Name = "Maximum Age Preference")]
        public double AgePrefMax { get; set; }
        [Display(Name = "School District")]
        public string SchoolDistrict { get; set; }
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string Comments { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
