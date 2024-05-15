using Project_Revin_InternetShop.AutorizationWindows;
using Project_Revin_InternetShop.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Revin_InternetShop.Login
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private MainWindow _mainWindow;
        private LoginWindow _loginWindow;
        public RegistrationPage(LoginWindow loginWindow, MainWindow mainWindow)
        {
            InitializeComponent();
            _loginWindow = loginWindow;
            _mainWindow = mainWindow;
        }

        private void ClickLabelReg(object sender, MouseButtonEventArgs e)
        {
            _loginWindow.NavigateToAutorizationPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User(UserNameTB.Text, FirstNameTB.Text, LastNameTB.Text, PasswordTB.Password, RootCB.IsChecked.Value);
                _mainWindow.Registration(user);
            }
            catch (Exception)
            {

                _mainWindow.MessageShow("Complete all fields");
            }
                
            
                
            


        }
    }
}
