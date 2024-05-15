using Project_Revin_InternetShop.Enum;
using Project_Revin_InternetShop.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace Project_Revin_InternetShop.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private MainWindow mainWindow;
        public Game game { get; set; }
        public GamePage(MainWindow mainWindow, Game game)
        {
            
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.game = game;
            CheckButtonText(ref GameButton);
            UpdateData();

        }
       
        public void UpdateData()
        {
            NameLabel.Content = game.Name;
            PriceLabel.Content = game.Price.ToString();
            PublisherLabel.Content = game.Publisher;
            VersionLabel.Content = game.Version.ToString();
            RatingLabel.Content = game.Rating.ToString();
            CategoryLabel.Content = game.Category.ToString();
            DescriptionLabel.Text = game.Description;
            HeadImage.Source = MainWindow.LoadImage(game.GetImages.First());
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (mainWindow.GetShop.authorizedUser != null)
            {
                if (!mainWindow.GetShop.authorizedUser.Library.Game.Contains(game))
                {
                    try
                    {
                        mainWindow.GetShop.authorizedUser.BuyGame(game);
                        mainWindow.UpdateUserLabel();
                    }
                    catch (Exception ex)
                    {

                        mainWindow.MessageShow(ex.Message);
                    }


                }
                else if (game.Itinstai)
                {
                    game.Launch();
                }
                else game.Install();

                CheckButtonText(ref GameButton);
            }
            else mainWindow.MessageShow("Log in to purchase");
        }
        private void CheckButtonText(ref Button but)
        {
            if (mainWindow.GetShop.authorizedUser !=null)
            {
                if (!mainWindow.GetShop.authorizedUser.Library.Game.Contains(game))
                {
                    but.Content = "Bay";
                }
                else if (game.Itinstai)
                {
                    but.Content = "Play";
                }
                else but.Content = "Instal";
            }
            
        }
    }
}
