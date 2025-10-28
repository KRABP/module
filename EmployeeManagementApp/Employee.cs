using System;

namespace EmployeeManagementApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Employee()
        {
            HireDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} - {Position}";
        }
    }

    public enum Department
    {
        IT,
        HR,
        Finance,
        Marketing,
        Sales,
        Production,
        Management
    }
}