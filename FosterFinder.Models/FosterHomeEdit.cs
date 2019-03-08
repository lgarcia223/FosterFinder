using FosterFinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Models
{
    public class FosterHomeEdit
    {
        public int HomeId { get; set; }
        public string FamilyName { get; set; }
        public int OpenBeds { get; set; }
        public GenderPref GenderPref { get; set; }
        public double AgePrefMin { get; set; }
        public double AgePrefMax { get; set; }
        public string SchoolDistrict { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
