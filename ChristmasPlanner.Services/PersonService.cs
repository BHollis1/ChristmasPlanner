using ChristmasPlanner.Data;
using ChristmasPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPlanner.Services
{
    public class PersonService
    {
        private readonly Guid _userID;

        public PersonService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePerson(PersonCreate model)
        {
            var entity =
                new Person()
                {
                    OwnerID = _userID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FullName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Person.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PersonListItem> GetPerson()
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Person
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                        new PersonListItem
                        {
                            PersonID = e.ID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            FullName = e.FullName
                        });
                return query.ToArray();
            }
        }
    }
}
