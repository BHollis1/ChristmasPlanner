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
                    BoughtGift = model.BoughtGift,
                    PersonID = model.PersonID
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
                            GiftID = e.GiftID,
                            Description = e.Description,
                            BoughtGift = e.BoughtGift,
                            PersonID = e.PersonID
                        });
                return query.ToArray();
            }
        }
        public GiftDetail GetGiftByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gifts
                    .Single(e => e.GiftID == id && e.OwnerID == _userID);
                return
                    new GiftDetail
                    {
                        GiftID = entity.GiftID,
                        Description = entity.Description,
                        BoughtGift = entity.BoughtGift,
                        PersonID = entity.PersonID
                    };
            }
        }

        public bool UpdateGift(GiftEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gifts
                    .Single(e => e.GiftID == model.GiftID && e.OwnerID == _userID);

                entity.Description = model.Description;
                entity.BoughtGift = model.BoughtGift;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGift(int giftID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gifts
                    .Single(e => e.GiftID == giftID && e.OwnerID == _userID);

                ctx.Gifts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
    

