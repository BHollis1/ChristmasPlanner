using ChristmasPlanner.Data;
using ChristmasPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Services
{
    public class CardServices
    {
        private readonly Guid _userID;

        public CardServices(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateCard(CardCreate model)
        {
            var entity =
                new Card()
                {
                    OwnerID = _userID,
                    SentCard = model.SentCard,
                    PersonID = model.PersonID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CardListItem> GetCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cards
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                        new CardListItem
                        {
                            CardID = e.CardID,
                            SentCard = e.SentCard,
                            Person = e.Person
                        });
                return query.ToArray();
            }
        }
        public CardDetail GetCardByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cards
                    .Single(e => e.CardID == id && e.OwnerID == _userID);
                return
                    new CardDetail
                    {
                        CardID = entity.CardID,
                        SentCard = entity.SentCard,
                        Person = entity.Person
                        
                    };
            }
        }

        public bool UpdateCard(CardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cards
                    .Single(e => e.CardID == model.CardID && e.OwnerID == _userID);

                entity.SentCard = model.SentCard;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCard(int cardID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cards
                    .Single(e => e.CardID == cardID && e.OwnerID == _userID);

                ctx.Cards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
    

