namespace DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual Company Company { get; set; }
    }
}
