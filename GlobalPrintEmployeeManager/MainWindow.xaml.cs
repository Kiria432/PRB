using System.Windows;
using System.Windows.Controls;
using GlobalPrintEmployeeManager.Services;
using GlobalPrintEmployeeManager.Prototypes;
using GlobalPrintEmployeeManager.Models;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;

namespace GlobalPrintEmployeeManager
{
    public partial class MainWindow : Window
    {
        private readonly CsvParser _csvParser;

        public MainWindow()
        {
            InitializeComponent();

            var prototypeManager = new EmployeePrototypeManager();
            _csvParser = new CsvParser(prototypeManager);

            // Автоматически загружаем данные при запуске
            LoadEmployees();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                string csvFilePath = "ExportCSV.csv";

                if (!File.Exists(csvFilePath))
                {
                    MessageBox.Show($"CSV file not found: {csvFilePath}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    StatusText.Text = "CSV file not found";
                    return;
                }

                var employees = _csvParser.ParseEmployeesFromFile(csvFilePath);

                DisplayEmployees(employees);
                UpdateStatistics(employees);

                StatusText.Text = $"Loaded {employees.Count} employees from {csvFilePath}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StatusText.Text = "Error loading employees";
            }
        }

        private void DisplayEmployees(List<Employee> employees)
        {
            var admins = new List<Employee>();
            var users = new List<Employee>();

            foreach (var employee in employees)
            {
                if (employee.Role == "Administrator")
                    admins.Add(employee);
                else
                    users.Add(employee);
            }

            AllDataGrid.ItemsSource = employees;
            AdminDataGrid.ItemsSource = admins;
            UserDataGrid.ItemsSource = users;
        }

        private void UpdateStatistics(List<Employee> employees)
        {
            int adminCount = 0;
            int userCount = 0;

            foreach (var employee in employees)
            {
                if (employee.Role == "Administrator")
                    adminCount++;
                else
                    userCount++;
            }

            AdminCountText.Text = $"Total Administrators: {adminCount}";
            UserCountText.Text = $"Total Users: {userCount}";

            TotalCountText.Text = employees.Count.ToString();
            AdminCountStatusText.Text = adminCount.ToString();
            UserCountStatusText.Text = userCount.ToString();
        }

    }
}