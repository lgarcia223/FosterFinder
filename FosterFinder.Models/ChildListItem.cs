using FosterFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Models
{

    public class ChildListItem
    {
        [Key]
        public int ChildId { get; set; }
        [Display(Name="Name")]
        public string ChildName { get; set; }
        [Display(Name ="Sibling Group")]
        public int BedsNeed { get; set; }
        [Display(Name ="Gender")]
        public ChildGender ChildGender { get; set; }
        [Display(Name ="Age")]        
        public double ChildAge { get; set; }
        [Display(Name ="School District")]
        public string SchoolDistNeed { get; set; }
        [Display(Name = "Case Worker")]
        public string CaseworkerName { get; set; }
        [Display(Name = "Contact")]
        public string CaseworkerContact { get; set; }
        public string Comments { get; set; }
        //[Display(Name = "Photo")]
        //public string PhotoUrl { get; set; }

        //[DisplayFormat(DataFormatString = "{mm/dd/yy}")]
        //public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
