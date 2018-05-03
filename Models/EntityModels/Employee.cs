namespace BookCave.Models.EntityModels
{
    public class Employee : User
    {
        public int Id { get; set; }
    }

    public class EmployeeType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Admin { get; set; }
    }
}