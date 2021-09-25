namespace BLL.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual CompanyDTO Company { get; set; }
    }
}
