using System;
using System.Windows;
using System.Windows.Controls;
using Login.Infrastructura;
using System.Windows.Threading;
using Login.Models;
using System.Linq;
using Login.Windows;

namespace Login.Pages
{
    public partial class LoginPage : Page
    {
        private int personID, personRole;
        private int _attempts = 0;
        private DateTime _blockTime;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        public LoginPage()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }
        private void btnPassword_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, не заблокирован ли вход
            if (DateTime.Now < _blockTime)
            {
                MessageBox.Show($"Пожалуйста, подождите {_blockTime - DateTime.Now:mm\\:ss} перед повторной попыткой.");
                return;
            }
            string login = txbLogin.Text;
            string password = psbPassword.Password;
            bool isAuthenticated = AuthenticateUser(login, password);
            if (isAuthenticated)
            {
                // Успешная аутентификация
                int authenticatedUserID = personID;
                int authenticatedRoleID = personRole;
                // Получаем MainWindow
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            }
            else
            {
                // Неудачная аутентификация
                _attempts++;
                MessageBox.Show("Неверный логин или пароль. Повторите попытку.");
                if (_attempts >= 3)
                {
                    // Блокируем кнопку
                    _blockTime = DateTime.Now.AddSeconds(10);
                    btnPassword.IsEnabled = false;
                    txbLogin.IsEnabled = false;
                    psbPassword.IsEnabled = false;
                    Timer.Visibility = Visibility.Visible;
                    _timer.Start();
                }
            }
        }
        private bool AuthenticateUser(string login, string password)
        {
            CursePerson findUser = DSConn.db.CursePerson.Where(u => u.PersonLogin == login && u.personPassword == password).FirstOrDefault();
            if (findUser != null)
            {
                personID = findUser.personID;
                personRole = findUser.personRole;
                switch (findUser.personRole)
                {
                    case 1:
                        {
                            NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/AdminPage.xaml", UriKind.RelativeOrAbsolute));
                            return true;
                        }
                    case 2:
                        {
                            NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/UserPage.xaml", UriKind.RelativeOrAbsolute));
                            return true;
                        }
                    default: { break; }
                }
            }
            return false;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= _blockTime)
            {
                btnPassword.IsEnabled = true;
                txbLogin.IsEnabled = true;
                psbPassword.IsEnabled = true;
                _attempts = 0;
                _timer.Stop();
                Timer.Content = "";
            }
            else
            {
                Timer.Content = $"Пожалуйста, подождите {(_blockTime - DateTime.Now).Seconds} сек.";
            }
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            registration.ShowDialog();
        }
    }
}

