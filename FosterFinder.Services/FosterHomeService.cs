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
                GenderPref = model.GenderPref,
                AgePrefMin = model.AgePrefMin,
                AgePrefMax = model.AgePrefMax,
                SchoolDistrict = model.SchoolDistrict,
                Agency = model.Agency,
                CaseworkerName = model.CaseworkerName,
                CaseworkerContact = model.CaseworkerContact,
                PhotoUrl = model.PhotoUrl,
                ModifiedUtc = model.ModifiedUtc,
                Comments = model.Comments,
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
                         Agency = e.Agency,
                         CaseworkerName = e.CaseworkerName,
                         CaseworkerContact = e.CaseworkerContact,
                         PhotoUrl = e.PhotoUrl,
                         ModifiedUtc = e.ModifiedUtc,
                         Comments = e.Comments,
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
                        Agency = entity.Agency,
                        CaseworkerName = entity.CaseworkerName,
                        CaseworkerContact = entity.CaseworkerContact,
                        Comments = entity.Comments,
                        PhotoUrl = entity.PhotoUrl,
                        ModifiedUtc = entity.ModifiedUtc,
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
                entity.Agency = model.Agency;
                entity.CaseworkerName = model.CaseworkerName;
                entity.CaseworkerContact = model.CaseworkerContact;
                entity.Comments = model.Comments;
                entity.PhotoUrl = model.PhotoUrl;
                entity.ModifiedUtc = model.ModifiedUtc;

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
        public IEnumerable<ChildListItem> GetChildMatches (int homeId)
        {
            var home = GetHomeById(homeId);
            using (var context = new ApplicationDbContext())
            {
                var children = context.Children.Where(c => c.BedsNeed >= home.OpenBeds && 
                                                      c.ChildAge <= home.AgePrefMax && 
                                                      c.ChildAge >= home.AgePrefMin && 
                                                      c.ChildGender == home.GenderPref ||
                                                      home.GenderPref == ChildGender.NA)
                    .Select(e => new ChildListItem
                     {
                         ChildId = e.ChildId,
                         ChildName = e.ChildName,
                         BedsNeed = e.BedsNeed,
                         ChildGender = e.ChildGender,
                         ChildAge = e.ChildAge,
                         SchoolDistNeed = e.SchoolDistNeed,
                         CaseworkerName = e.CaseworkerName,
                         CaseworkerContact = e.CaseworkerContact,
                         Comments = e.Comments,
                     });
                return children.ToArray();
            }
        }
    }
}

