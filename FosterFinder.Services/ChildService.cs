 using FosterFinder.Data;
using FosterFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterFinder.Services
{
    public class ChildService
    {
        private readonly Guid _userId;

        public ChildService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateChild(ChildCreate model)
        {
            var entity = new Child()
            {
                UserId = _userId,
                ChildName = model.ChildName,
                BedsNeed = model.BedsNeed,
                ChildGender = model.ChildGender,
                ChildAge = model.ChildAge,
                SchoolDistNeed = model.SchoolDistNeed,
                CaseworkerName = model.CaseworkerName,
                CaseworkerContact = model.CaseworkerContact,
                Comments = model.Comments,
                PhotoUrl = model.PhotoUrl,
                ModifiedUtc = model.ModifiedUtc,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Children.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ChildListItem> GetChildren()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Children
                    .Select(e =>
                        new ChildListItem
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
                            PhotoUrl = e.PhotoUrl,
                            ModifiedUtc = e.ModifiedUtc,
                        }
                );
                return query.ToArray();
            }
        }
        public ChildDetail GetChildById(int childId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Children
                    .Single(e => e.ChildId == childId);
                return
                    new ChildDetail
                    {
                        ChildId = entity.ChildId,
                        ChildName = entity.ChildName,
                        BedsNeed = entity.BedsNeed,
                        ChildGender = entity.ChildGender,
                        ChildAge = entity.ChildAge,
                        SchoolDistNeed = entity.SchoolDistNeed,
                        CaseworkerName = entity.CaseworkerName,
                        CaseworkerContact = entity.CaseworkerContact,
                        Comments = entity.Comments,
                        PhotoUrl = entity.PhotoUrl,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }
        public bool UpdateChild(ChildEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Children
                    .Single(e => e.ChildId == model.ChildId);

                entity.ChildId = model.ChildId;
                entity.ChildName = model.ChildName;
                entity.BedsNeed = model.BedsNeed;
                entity.ChildGender = model.ChildGender;
                entity.ChildAge = model.ChildAge;
                entity.SchoolDistNeed = model.SchoolDistNeed;
                entity.CaseworkerName = model.CaseworkerName;
                entity.CaseworkerContact = model.CaseworkerContact;
                entity.Comments = model.Comments;
                entity.PhotoUrl = model.PhotoUrl;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteChild(int childId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Children
                    .Single(e => e.ChildId == childId);

                    ctx.Children.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FosterHomeListItem> GetHomeMatches (int childId)
        {
            var child = GetChildById(childId);
            using (var context = new ApplicationDbContext())
            {
                var homes = context.Homes.Where(h => h.OpenBeds >= child.BedsNeed && 
                                                h.AgePrefMax >= child.ChildAge && 
                                                h.AgePrefMin <= child.ChildAge && 
                                                h.GenderPref == child.ChildGender ||
                                                h.GenderPref == ChildGender.NA)
                    .Select(e => new FosterHomeListItem
                    {
                        HomeId = e.HomeId,
                        FamilyName = e.FamilyName,
                        OpenBeds = e.OpenBeds,
                        GenderPref = e.GenderPref,
                        AgePrefMin = e.AgePrefMin,
                        AgePrefMax = e.AgePrefMax,
                        SchoolDistrict = e.SchoolDistrict,
                        CaseworkerName = e.CaseworkerName,
                        CaseworkerContact = e.CaseworkerContact, 
                        Comments = e.Comments,
                        PhotoUrl = e.PhotoUrl,
                    });

                return homes.ToArray();
            }
        }
    }
}
