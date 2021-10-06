using AutoMapper;
using BLL.DTO;
using BLL.Profiles;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Services
{
    [TestClass]
    public class PersonServiceTest
    {
        private Mock<IRepository<Person>> _repository;
        private IMapper _mapper;
        private PersonService _service;

        private List<Person> _people;
        private List<Company> _companies;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new Mock<IRepository<Person>>();
            _mapper = new Mapper(new MapperConfiguration(cfg => 
            {
                cfg.AddProfile<PersonProfile>();
                cfg.AddProfile<CompanyProfile>();
            }));
            _service = new PersonService(_mapper, _repository.Object);

            InitMockEntities();
        }
        
        [TestMethod]
        public void GetPersonsWorksOn_PassCompanyWithId1_ShouldSuccessfullyReturnEmployeesOfThisCompany()
        {
            var companyId = 1;
            var expected = _mapper.Map<List<Person>, List<PersonDTO>>(_people)
                .Where(x => x.Company.Id == companyId)
                .ToList();

            _repository.Setup(x => x.GetAll()).Returns(_people);

            var actual = _service.GetPersonsWorksOn(companyId);

            AssertEmployeeListsAreEqual(expected, actual);
        }

        private void InitMockEntities()
        {
            _people = new List<Person>()
            {
                new Person() { Id = 1, Name = "Матвей Радуга", Age = 36 },
                new Person() { Id = 2, Name = "Акуна Матата", Age = 14 },
                new Person() { Id = 3, Name = "Хан Карыдов", Age = 23 },
                new Person() { Id = 4, Name = "Ярослав Лютобор", Age = 55 },
                new Person() { Id = 5, Name = "Саммерсет Оушен", Age = 91 },
                new Person() { Id = 6, Name = "Ыхлас Ырбетов", Age = 16 },
                new Person() { Id = 7, Name = "Салат Петухов", Age = 17 },
                new Person() { Id = 8, Name = "Хьюберт Блейн", Age = 26 },
                new Person() { Id = 9, Name = "Вольф Флегштайн", Age = 31 },
                new Person() { Id = 10, Name = "Барнаби Мармадюк", Age = 20 },
                new Person() { Id = 11, Name = "Блюриа Азия", Age = 21 },
                new Person() { Id = 12, Name = "Элси Выдра", Age = 49 },
                new Person() { Id = 13, Name = "Чарли Волк", Age = 25 },
                new Person() { Id = 14, Name = "Зоуи Дешанель", Age = 30 },
                new Person() { Id = 15, Name = "Сэм Уортингтон", Age = 18 },
                new Person() { Id = 16, Name = "Джейсона Ли", Age = 17 },
            };

            _companies = new List<Company>()
            {
                new Company
                {
                    Id = 1,
                    Name = "ООО «‎Хахали твоей мамки»",
                    People = new List<Person>()
                },
                new Company
                {
                    Id = 2,
                    Name = "«Пидрильный клуб любителей пощекотать очко»",
                    People = new List<Person>()
                },
            };

            _people.ForEach(x =>
            {
                if (x.Id % 3 == 0)
                {
                    x.Company = _companies[0];
                    _companies[0].People.Add(x);
                }
                else
                {
                    x.Company = _companies[1];
                    _companies[1].People.Add(x);
                }
            });
        }
    
        private void AssertEmployeeListsAreEqual(List<PersonDTO> expected, List<PersonDTO> actual)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            
            Assert.AreEqual(expected.Count, actual.Count);

            for (var i = 0; i < actual.Count; i++)
            {
                AssertEmployeesAreEqual(expected[i], actual[i]);
            }
        }

        private void AssertEmployeesAreEqual(PersonDTO expected, PersonDTO actual)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);

            Assert.IsNotNull(expected.Company);
            Assert.IsNotNull(actual.Company);

            Assert.AreEqual(expected.Company.Id, actual.Company.Id);
            Assert.AreEqual(expected.Company.Name, actual.Company.Name);
        }
    }
}
