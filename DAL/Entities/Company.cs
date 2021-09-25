using System.Collections.Generic;

namespace DAL.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
