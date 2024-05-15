﻿using Project_Revin_InternetShop.Enum;
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

namespace Project_Revin_InternetShop.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminViewPage.xaml
    /// </summary>
    public partial class AdminViewPage : Page
    {
        AdminGamePage gamePage;
        private MainWindow mainWindow;
        public AdminViewPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            //gamePage = new GamePage(mainWindow);
            CreateAllCustomGrid();
        }
        public void CreateAllCustomGrid()
        {
            AdminCategorySP.Children.Clear();
            foreach (var category in mainWindow.GetShop.GetCatalogs)
            {
                if (category.Game.Count > 0)
                {
                    AdminCategorySP.Children.Add(CreateCustomGrid(category));

                }
            }

        }
        public Grid CreateCustomGrid(Catalog catalog)
        {
            // Створення Grid
            Grid dynamicGrid = new Grid
            {
                Background = new SolidColorBrush(ColorConverter.ConvertFromString("#FF2E2E2E") as Color? ?? Colors.Red),
                Margin = new Thickness(0, 10, 0, 0),
                Height = 200
            };

            // Додавання рядків
            dynamicGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            dynamicGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            // Додавання Label у перший рядок
            Label categoryLabel = new Label
            {
                Content = catalog.Category,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(10, 5, 0, 0)
            };
            Grid.SetRow(categoryLabel, 0);
            dynamicGrid.Children.Add(categoryLabel);

            // Створення StackPanel для другого рядка
            StackPanel panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            Grid.SetRow(panel, 1);
            dynamicGrid.Children.Add(panel);
            Action<Game> createItemGrid = AddItemGrid(panel);

            // Створення  Grid в StackPanel
            foreach (var game in catalog.Game)
            {
                createItemGrid(game);
            }
            return dynamicGrid;
        }

        private Action<Game> AddItemGrid(StackPanel panel)
        {
            // Функція для створення окремих Grid в середині StackPanel
            Action<Game> createItemGrid = (game) =>
            {
                Grid itemGrid = new Grid { Width = 100, Margin = new Thickness(10, 0, 0, 0) };
                itemGrid.Tag = game;  // Зберігаємо гру в Tag для доступу в обробнику події
                itemGrid.MouseLeftButtonUp += (sender, e) =>
                {
                    Game selectedGame = (sender as Grid).Tag as Game;
                    ClickGame(selectedGame, e);
                };
                // Image
                System.Windows.Controls.Image image = new System.Windows.Controls.Image { Stretch = Stretch.Fill };
                if (game.GetImages.Count > 0)
                {
                    image.Source = MainWindow.LoadImage(game.GetImages.First());
                } 
                    itemGrid.Children.Add(image);

                // Label for Name
                Label nameLabel = new Label
                {
                    Content = game.Name,
                    Height = 30,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 0, 50),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Background = Brushes.AliceBlue
                };
                itemGrid.Children.Add(nameLabel);

                // Label for Price
                Label priceLabel = new Label
                {
                    Content = game.Price,
                    Height = 30,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 0, 5),
                    HorizontalContentAlignment = HorizontalAlignment.Center
                };
                itemGrid.Children.Add(priceLabel);

                // Додавання Grid до StackPanel
                panel.Children.Add(itemGrid);
            };
            return createItemGrid;
        }

        private void ClickGame(Game game, MouseButtonEventArgs e)
        {
            gamePage = new AdminGamePage(mainWindow, game);
            mainWindow.ViewFrame.Navigate(gamePage);
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            Game addgame = new Game();
            gamePage = new AdminGamePage(mainWindow, addgame);
            mainWindow.GetShop.AddGame(addgame);
            mainWindow.ViewFrame.Navigate(gamePage);

        }
    }
}


    
        
        
        


    

