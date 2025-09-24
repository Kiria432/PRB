using System.Windows;
using Login.Pages;

namespace Login
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frmContent.Content = new LoginPage();
        }
    }
}
