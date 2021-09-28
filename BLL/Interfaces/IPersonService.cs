using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IPersonService
    {
        List<PersonDTO> GetPersonsWorksOn(int companyId);
    }
}
