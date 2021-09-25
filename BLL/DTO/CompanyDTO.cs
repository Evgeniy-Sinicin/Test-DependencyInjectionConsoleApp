using System.Collections.Generic;

namespace BLL.DTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonDTO> People { get; set; }
    }
}
