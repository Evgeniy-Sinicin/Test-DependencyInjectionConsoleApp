using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace UI.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }
}
