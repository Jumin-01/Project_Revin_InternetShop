using Project_Revin_InternetShop.Enum;
using Project_Revin_InternetShop.Games;
using Project_Revin_InternetShop.Lists;
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
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        Style customLabelStyle = System.Windows.Application.Current.FindResource("CustomLabelStyle") as Style;
        Style customButtonStyle = System.Windows.Application.Current.FindResource("ButtonStyle") as Style;
        GamePage gamePage;
        private MainWindow mainWindow;
        public LibraryPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            CreateLibraryGrid();
        }
        public void CreateLibraryGrid()
        {

            if (mainWindow.GetShop.authorizedUser != null)
            {


                SPLibraryGame.Children.Clear();
                foreach (var game in mainWindow.GetShop.authorizedUser.Library.Game)
                {
                    Grid itemGrid = new Grid
                    {
                        Height = 80,
                        Background = new SolidColorBrush(ColorConverter.ConvertFromString("#FF292D38") as Color? ?? Colors.Red),
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

                    // Button
                    Button button = new Button { Height = 30, Margin = new Thickness(0, 0, 10, 0), Style = customButtonStyle};
                    button.Tag = game;
                    button.Click += Button_Click;

                    CheckButtonText(button, game);
                    Grid.SetColumn(button, 2);
                    itemGrid.Children.Add(button);

                    // Label for Name
                    Label nameLabel = new Label
                    {
                        Style = customLabelStyle,
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
                        Style = customLabelStyle,
                        Content = game.Publisher,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(0, 30, 0, 0),
                        FontSize = 8
                    };
                    Grid.SetColumn(publisherLabel, 1);
                    itemGrid.Children.Add(publisherLabel);

                    // Додавання itemGrid до StackPanel
                    SPLibraryGame.Children.Add(itemGrid);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = sender as Button;
            if (currentButton == null) return;

            Game currentGame = currentButton.Tag as Game;  // Виправлення отримання гри
            if (currentGame == null) return;  // Перевірка, чи гра дійсно отримана

            if (currentGame.Itinstai)
            {
                currentGame.Launch();
            }
            else
            {
                currentGame.Install();
            }

            CheckButtonText( currentButton, currentGame);
        }
        private void CheckButtonText( Button but, Game game)
        {
            if (game.Itinstai)
            {
                but.Content = "Play";
            }
            else but.Content = "Instal";
        }

        private void ClickGame(Game selectedGame, MouseButtonEventArgs e)
        {
            gamePage = new GamePage(mainWindow, selectedGame);
            mainWindow.ViewFrame.Navigate(gamePage);
        }
    }
}
