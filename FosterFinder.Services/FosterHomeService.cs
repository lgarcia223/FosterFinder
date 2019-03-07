using FosterFinder.Data;
using FosterFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Services
{
    public class FosterHomeService
    {
        private readonly Guid _userId;

        public FosterHomeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFosterHome(FosterHomeCreate model)
        {
            var entity = new FosterHome()
            {
                UserId = _userId,
                FamilyName = model.FamilyName,
                OpenBeds = model.OpenBeds,
                GenderPref = model.genderPref,
                AgePrefMin = model.AgePrefMax,
                AgePrefMax = model.AgePrefMax,
                SchoolDistrict = model.SchoolDistrict,
                Comments = model.Comments,
                ModifiedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Homes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FosterHomeListItem> GetFosterHomes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                     .Homes
                     .Select(e =>
                     new FosterHomeListItem
                     {
                         HomeId = e.HomeId,
                         FamilyName = e.FamilyName,
                         OpenBeds = e.OpenBeds,
                         GenderPref = e.GenderPref,
                         AgePrefMin = e.AgePrefMin,
                         AgePrefMax = e.AgePrefMax,
                         SchoolDistrict = e.SchoolDistrict,
                         Comments = e.Comments,

                         ModifiedUtc = e.ModifiedUtc
                     }
               );
                return query.ToArray();

            }
        }

    }
}
