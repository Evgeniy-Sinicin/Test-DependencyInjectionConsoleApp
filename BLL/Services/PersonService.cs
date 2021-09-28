using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class PersonService : IPersonService
    {
        private IRepository<Person> _repository;
        private IMapper _mapper;

        public PersonService(IMapper mapper, IRepository<Person> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<PersonDTO> GetPersonsWorksOn(int companyId)
        {
            return _mapper.Map<List<Person>, List<PersonDTO>>(_repository.GetAll()
                .ToList()
                .Where(x => x.Company.Id == companyId)
                .ToList());
        }
    }
}
