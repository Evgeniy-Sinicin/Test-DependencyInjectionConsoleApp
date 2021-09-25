using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace UI.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
