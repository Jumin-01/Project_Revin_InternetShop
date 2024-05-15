using Project_Revin_InternetShop.Login;
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

namespace Project_Revin_InternetShop.AutorizationWindows
{
    /// <summary>
    /// Interaction logic for AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        private MainWindow _mainWindow;
        private LoginWindow _loginWindow;
        public AutorizationPage(LoginWindow loginWindow, MainWindow mainWindow)
        {
            InitializeComponent();
            _loginWindow = loginWindow;
            _mainWindow = mainWindow;
        }
        
        private void ClickLabel(object sender, MouseButtonEventArgs e)
        {
            _loginWindow.NavigateToRegistrationPage();
            
        }

        private void Log_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _mainWindow.LogIn(LoginTextBox.Text, PasswordBox.Password);
            }
            catch (Exception)
            {

                _mainWindow.MessageShow("Complete all fields");
            }
                

            if (_mainWindow.GetShop.authorizedUser!=null)
            {
                _mainWindow.CloseLoginWindow();
            }
          
        }
    }
}
