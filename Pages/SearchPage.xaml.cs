using Project_Revin_InternetShop.Games;
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

namespace Project_Revin_InternetShop.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        GamePage gamePage;
        private MainWindow mainWindow;
        public SearchPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            
        }
        public void CreateSearchGrid(List<Game> searchGames)
        {
            if (searchGames != null)
            {
                SPSearchGame.Children.Clear();
                foreach (var game in searchGames)
                {
                    Grid itemGrid = new Grid
                    {
                        Height = 80,
                        Background = Brushes.Silver,
                        Margin = new Thickness(0, 10, 0, 0)
                    };

                    itemGrid.Tag = game;  // Зберігаємо гру в Tag для доступу в обробнику події

                    itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
                    itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                    itemGrid.MouseLeftButtonUp += (sender, e) =>
                    {
                        Game selectedGame = (sender as Grid).Tag as Game;
                        ClickGame(selectedGame, e);
                    };
                    // Image
                    Image image = new Image { Margin = new Thickness(10), Source = MainWindow.LoadImage(game.GetImages.First()) };
                    itemGrid.Children.Add(image);



                    // Label for Name
                    Label nameLabel = new Label
                    {
                        Content = game.Name,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 16
                    };
                    Grid.SetColumn(nameLabel, 1);
                    itemGrid.Children.Add(nameLabel);

                    // Label for Publisher
                    Label publisherLabel = new Label
                    {
                        Content = game.Publisher,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(0, 30, 0, 0),
                        FontSize = 8
                    };
                    Grid.SetColumn(publisherLabel, 1);
                    itemGrid.Children.Add(publisherLabel);

                    // Додавання itemGrid до StackPanel
                    SPSearchGame.Children.Add(itemGrid);
                }
            }
        }

        private void ClickGame(Game selectedGame, MouseButtonEventArgs e)
        { 
                gamePage = new GamePage(mainWindow, selectedGame);
                mainWindow.ViewFrame.Navigate(gamePage);
            

        }
    }
}
