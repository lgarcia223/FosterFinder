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
        [Display(Name ="Foster Family Name")]
        public int FamilyName { get; set; }
        [Display(Name = "Openings")]
        public int OpenBeds { get; set; }
        [Display(Name = "Gender Preference")]
        public GenderPref genderpref { get; set; }
        [Display(Name = "Minimum Age Preference")]
        public int AgePrefMin { get; set; }
        [Display(Name = "Maximum Age Preference")]
        public int AgePrefMax { get; set; }
        [Display(Name = "School District")]
        public string SchoolDistrict { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
