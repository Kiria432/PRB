using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GlobalPrintEmployeeManager.Models;

namespace GlobalPrintEmployeeManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Employee> _administrators;
        private ObservableCollection<Employee> _users;
        private string _statusMessage;
        private int _adminCount;
        private int _userCount;
        private int _totalCount;

        public MainViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            Administrators = new ObservableCollection<Employee>();
            Users = new ObservableCollection<Employee>();
            StatusMessage = "Ready to load employees";
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }

        public ObservableCollection<Employee> Administrators
        {
            get => _administrators;
            set => SetProperty(ref _administrators, value);
        }

        public ObservableCollection<Employee> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public int AdminCount
        {
            get => _adminCount;
            set => SetProperty(ref _adminCount, value);
        }

        public int UserCount
        {
            get => _userCount;
            set => SetProperty(ref _userCount, value);
        }

        public int TotalCount
        {
            get => _totalCount;
            set => SetProperty(ref _totalCount, value);
        }

        public void UpdateEmployees(List<Employee> employees)
        {
            Employees = new ObservableCollection<Employee>(employees);

            var admins = new List<Employee>();
            var users = new List<Employee>();

            foreach (var employee in employees)
            {
                if (employee.Role == "Administrator")
                    admins.Add(employee);
                else
                    users.Add(employee);
            }

            Administrators = new ObservableCollection<Employee>(admins);
            Users = new ObservableCollection<Employee>(users);

            AdminCount = admins.Count;
            UserCount = users.Count;
            TotalCount = employees.Count;

            StatusMessage = $"Loaded {TotalCount} employees ({AdminCount} admins, {UserCount} users)";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}