using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Linq;

namespace BLL.Services
{
    public class CompanyService
    {
        private IRepository<Company> _repository;

        public CompanyService(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public int GetEmployeeCount(int companyId)
        {
            var count = _repository.GetAll()
                .ToList()
                .FirstOrDefault(x => x.Id == companyId)
                .People.Count;

            return count > 10 ? throw new Exception("Company shouldn't have more than 10 employees.") : count;
        }
    }
}
