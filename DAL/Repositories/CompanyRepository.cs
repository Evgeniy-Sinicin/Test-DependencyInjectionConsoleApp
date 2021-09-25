using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private ListContext _db;

        public CompanyRepository(ListContext db)
        {
            _db = db;
        }

        public void Create(Company item)
        {
            _db.Companies.Add(item);
        }

        public void Delete(int id)
        {
            _db.Companies.Remove(_db.Companies.FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<Company> Find(Func<Company, bool> predicate)
        {
            return _db.Companies.Where(predicate);
        }

        public Company Get(int id)
        {
            return _db.Companies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _db.Companies;
        }

        public void Update(Company item)
        {
            _db.Companies.ForEach(x => x = x.Id == item.Id ? item : x);
        }
    }
}
