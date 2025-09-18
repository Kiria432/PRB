using System;

namespace GlobalPrintEmployeeManager.Models
{
    public class Employee : ICloneable
    {
        public string JobTitle { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public Employee Clone()
        {
            return new Employee
            {
                JobTitle = this.JobTitle,
                FirstName = this.FirstName,
                LastName = this.LastName,
                CompanyName = this.CompanyName,
                Country = this.Country,
                StreetAddress = this.StreetAddress,
                City = this.City,
                Street = this.Street,
                Role = this.Role
            };
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Role}";
        }
    }
}