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
        public PersonService()
        {

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
                    //.Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                        new PersonListItem
                        {
                            PersonID = e.PersonID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            FullName = e.FullName
                        });
                return query.ToArray();
            }
        }

        public PersonDetail GetPersonByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Person
                    .Single(e => e.PersonID == id); /*&& e.OwnerID == _userID); */
                return
                    new PersonDetail
                    {
                        PersonID = entity.PersonID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FullName = entity.FullName
                    };
            }
        }

        public bool UpdatePerson(PersonEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Person
                    .Single(e => e.PersonID == model.PersonID); /*&& e.OwnerID == _userID);*/

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.FullName = model.FullName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePerson(int personID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Person
                    .Single(e => e.PersonID == personID); /*&& e.OwnerID == _userID);*/

                ctx.Person.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
