using System.Collections.Generic;
using System.IO;
using System.Text;
using GlobalPrintEmployeeManager.Models;
using GlobalPrintEmployeeManager.Prototypes;

namespace GlobalPrintEmployeeManager.Services
{
    public class CsvParser
    {
        private readonly EmployeePrototypeManager _prototypeManager;

        public CsvParser(EmployeePrototypeManager prototypeManager)
        {
            _prototypeManager = prototypeManager;
        }

        public List<Employee> ParseEmployees(string csvContent)
        {
            var employees = new List<Employee>();
            var lines = csvContent.Split('\n');

            // Пропускаем заголовок
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                var columns = ParseCsvLine(lines[i]);
                if (columns.Length >= 8)
                {
                    var employee = _prototypeManager.CreateEmployee(
                        columns[1].Trim(), // FirstName
                        columns[2].Trim(), // LastName
                        columns[4].Trim()  // Country
                    );
                    employees.Add(employee);
                }
            }

            return employees;
        }

        private string[] ParseCsvLine(string line)
        {
            var result = new List<string>();
            var current = new StringBuilder();
            bool inQuotes = false;
            bool skipComma = false;

            foreach (char c in line)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    skipComma = inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(current.ToString());
                    current.Clear();
                    skipComma = false;
                }
                else if (!skipComma)
                {
                    current.Append(c);
                }
            }

            result.Add(current.ToString());
            return result.ToArray();
        }

        public List<Employee> ParseEmployeesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"CSV file not found: {filePath}");

            string csvContent = File.ReadAllText(filePath, Encoding.UTF8);
            return ParseEmployees(csvContent);
        }
    }
}