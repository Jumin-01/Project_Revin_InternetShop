using Project_Revin_InternetShop.AutorizationWindows;
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
using System.Windows.Shapes;

namespace Project_Revin_InternetShop.Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow mainWindow;
        private AutorizationPage autorizationPage;
        private RegistrationPage registrationPage;
        public LoginWindow(MainWindow mainWindow)
        {
            InitializeComponent();
             autorizationPage = new AutorizationPage(this, mainWindow);
             registrationPage = new RegistrationPage(this, mainWindow);
            this.mainWindow = mainWindow;
            LoginFrame.Content = autorizationPage;
            
            
        }
        public void NavigateToAutorizationPage()
        {
            LoginFrame.Content = autorizationPage;
            
        }

        public void NavigateToRegistrationPage()
        {
            LoginFrame.Content = registrationPage;
        }
    }
}
