using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private ListContext _db;

        public PersonRepository(ListContext db)
        {
            _db = db;
        }

        public void Create(Person item)
        {
            _db.People.Add(item);
        }

        public void Delete(int id)
        {
            _db.People.Remove(_db.People.FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<Person> Find(Func<Person, bool> predicate)
        {
            return _db.People.Where(predicate);
        }

        public Person Get(int id)
        {
            return _db.People.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _db.People;
        }

        public void Update(Person item)
        {
            _db.People.ForEach(x => x = x.Id == item.Id ? item : x);
        }
    }
}
