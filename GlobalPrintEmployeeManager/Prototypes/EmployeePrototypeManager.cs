using GlobalPrintEmployeeManager.Models;

namespace GlobalPrintEmployeeManager.Prototypes
{
    public class EmployeePrototypeManager
    {
        private readonly Employee _baseEmployeePrototype;

        public EmployeePrototypeManager()
        {
            // Создаем базовый прототип с данными Global Print
            _baseEmployeePrototype = new Employee
            {
                CompanyName = "Global Print",
                StreetAddress = "Champion Street, 3939",
                City = "Hollywood",
                Street = "Kingly Lane",
                JobTitle = "Developer"
            };
        }

        public Employee CreateEmployee(string firstName, string lastName, string country)
        {
            var employee = _baseEmployeePrototype.Clone();
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Country = country;

            // Назначаем роль на основе первой буквы фамилии
            AssignRole(employee);

            return employee;
        }

        private void AssignRole(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.LastName))
            {
                employee.Role = "User";
                return;
            }

            char firstLetter = char.ToUpper(employee.LastName[0]);
            employee.Role = (firstLetter >= 'A' && firstLetter <= 'N') ? "Administrator" : "User";
        }
    }
}