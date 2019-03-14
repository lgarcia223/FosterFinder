using FosterFinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Models
{
    public class ChildEdit
    {
        public int ChildId { get; set; }
        public string ChildName { get; set; }
        public int BedsNeed { get; set; }
        public ChildGender ChildGender { get; set; }
        public double ChildAge { get; set; }
        public string SchoolDistNeed { get; set; }
        public string CaseworkerName { get; set; }
        public string CaseworkerContact { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
