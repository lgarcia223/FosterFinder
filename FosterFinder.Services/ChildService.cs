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
                Comments = model.Comments,
                ModifiedUtc = DateTimeOffset.Now
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
                            Comments = e.Comments,

                            ModifiedUtc = e.ModifiedUtc
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
                        Comments = entity.Comments,

                        ModifiedUtc = entity.ModifiedUtc
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
                entity.Comments = model.Comments;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
