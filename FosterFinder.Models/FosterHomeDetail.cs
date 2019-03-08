using FosterFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Models
{
    public class FosterHomeDetail
    {
        public int HomeId { get; set; }
        [Display(Name = "Foster Family Name")]
        public string FamilyName { get; set; }
        [Display(Name = "# of Openings")]
        public int OpenBeds { get; set; }
        [Display(Name = "Gender Preference")]
        public GenderPref GenderPref { get; set; }
        [Display(Name = "Minimum Age Preference")]
        public double AgePrefMin { get; set; }
        [Display(Name = "Maximum Age Preference")]
        public double AgePrefMax { get; set; }
        [Display(Name = "School District")]
        public string SchoolDistrict { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
