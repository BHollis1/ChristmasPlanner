using ChristmasPlanner.Data;
using ChristmasPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Services
{
    public class GiftService
    {
        private readonly Guid _userID;

        public GiftService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateGift(GiftCreate model)
        {
            var entity =
                new Gift()
                {
                    OwnerID = _userID,
                    Description = model.Description,
                    BoughtGift = model.BoughtGift
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Gifts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GiftListItem> GetGift()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Gifts
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                        new GiftListItem
                        {
                            GiftID = e.ID,
                            Description = e.Description,
                            BoughtGift = e.BoughtGift,
                            PersonID = e.PersonID
                        });
                return query.ToArray();
            }
        }
}
