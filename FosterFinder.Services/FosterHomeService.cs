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
                HomeId = model.HomeId,
                FamilyName = model.FamilyName,
                OpenBeds = model.OpenBeds,
                GenderPref = model.genderPref,
                AgePrefMin = model.AgePrefMin,
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
        public FosterHomeDetail GetHomeById(int HomeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Homes
                    .Single(e => e.HomeId == HomeId);
                return
                    new FosterHomeDetail
                    {
                        HomeId = entity.HomeId,
                        FamilyName = entity.FamilyName,
                        OpenBeds = entity.OpenBeds,
                        GenderPref = entity.GenderPref,
                        AgePrefMin = entity.AgePrefMin,
                        AgePrefMax = entity.AgePrefMax,
                        SchoolDistrict = entity.SchoolDistrict,
                        Comments = entity.Comments,

                        ModifiedUtc = entity.ModifiedUtc

                    };
            }

        }
        public bool UpdateFosterHome(FosterHomeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Homes
                    .Single(e => e.HomeId == model.HomeId);

                entity.HomeId = model.HomeId;
                entity.FamilyName = model.FamilyName;
                entity.OpenBeds = model.OpenBeds;
                entity.GenderPref = model.GenderPref;
                entity.AgePrefMin = model.AgePrefMin;
                entity.AgePrefMax = model.AgePrefMax;
                entity.SchoolDistrict = model.SchoolDistrict;
                entity.Comments = model.Comments;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteHome(int HomeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Homes
                    .Single(e => e.HomeId == HomeId);

                ctx.Homes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

