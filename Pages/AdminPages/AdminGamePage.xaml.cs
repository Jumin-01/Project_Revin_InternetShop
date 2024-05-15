using Microsoft.Win32;
using Project_Revin_InternetShop.Enum;
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

namespace Project_Revin_InternetShop.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminGamePage.xaml
    /// </summary>
    public partial class AdminGamePage : Page
    {
        private MainWindow mainWindow;
        public Game game { get; set; }
       
        public AdminGamePage(MainWindow mainWindow, Game game)
        {

            InitializeComponent();
            this.mainWindow = mainWindow;
            this.game = game;
            PopulateCategoryComboBox();
            UpdateData();
            //MainAdminGameGrid.Children.Add(CreateComplexGrid());
        }
        //private Grid CreateComplexGrid()
        //{
        //    // Створення зовнішнього Grid
        //    Grid mainGrid = new Grid { Background = Brushes.White };

        //    // Створення ScrollViewer
        //    ScrollViewer scrollViewer = new ScrollViewer();
        //    mainGrid.Children.Add(scrollViewer);

        //    // Створення StackPanel у ScrollViewer
        //    StackPanel stackPanel = new StackPanel();
        //    scrollViewer.Content = stackPanel;

        //    Style transparentTextBoxStyle = new Style(typeof(TextBox));
        //    transparentTextBoxStyle.Setters.Add(new Setter(TextBox.BackgroundProperty, Brushes.Transparent));
        //    transparentTextBoxStyle.Setters.Add(new Setter(TextBox.BorderBrushProperty, Brushes.Transparent));
        //    transparentTextBoxStyle.Setters.Add(new Setter(TextBox.ForegroundProperty, Brushes.Black));  // Задаємо колір тексту
        //    // Створення першого внутрішнього Grid
        //    Grid grid1 = new Grid
        //    {
        //        Height = 200,
        //        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFDCCCC")),
        //        Margin = new Thickness(0, 10, 0, 0)
        //    };
        //    stackPanel.Children.Add(grid1);

        //    // Додавання колонок до grid1
        //    grid1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
        //    grid1.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        //    // Додавання Image
        //    Image image = new Image { Margin = new Thickness(10), Source = MainWindow.LoadImage(game.GetImages.First()) };
        //    Grid.SetColumn(image, 0);
        //    grid1.Children.Add(image);

        //    // Внутрішній Grid у другій колонці
        //    Grid innerGrid1 = new Grid();
        //    Grid.SetColumn(innerGrid1, 1);
        //    grid1.Children.Add(innerGrid1);

        //    // Додавання рядків до innerGrid1
        //    innerGrid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
        //    innerGrid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
        //    innerGrid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
        //    innerGrid1.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

        //    // Додавання компонентів до innerGrid1
        //    TextBox nameTextBox = new TextBox { Text = game.Name, FontSize = 24, VerticalAlignment = VerticalAlignment.Center, Style = transparentTextBoxStyle };
        //    Grid.SetRow(nameTextBox, 0);
        //    innerGrid1.Children.Add(nameTextBox);

        //    Button button = new Button { HorizontalAlignment = HorizontalAlignment.Right, Height = 30, Width = 100, Margin = new Thickness(0, 0, 50, 0) };
        //    Grid.SetRow(button, 0);
        //    innerGrid1.Children.Add(button);
        //    button.Click += Button_Click;

        //    TextBox publisherTextBox = new TextBox { Text = game.Publisher, FontSize = 10, Style = transparentTextBoxStyle };
        //    Grid.SetRow(publisherTextBox, 1);
        //    innerGrid1.Children.Add(publisherTextBox);

        //    StackPanel infoPanel = new StackPanel { Orientation = Orientation.Horizontal };
        //    Grid.SetRow(infoPanel, 2);
        //    innerGrid1.Children.Add(infoPanel);

        //    infoPanel.Children.Add(new TextBox { Text = $"{game.Version}", FontSize = 14, HorizontalAlignment = HorizontalAlignment.Center, Style = transparentTextBoxStyle });
        //    infoPanel.Children.Add(new TextBox { Text = $"{game.Rating}", FontSize = 14, HorizontalAlignment = HorizontalAlignment.Center, Style = transparentTextBoxStyle });
        //    infoPanel.Children.Add(new TextBox { Text = $"{game.Category}", FontSize = 14, HorizontalAlignment = HorizontalAlignment.Center, Style = transparentTextBoxStyle });

        //    StackPanel infoPanel2 = new StackPanel { Orientation = Orientation.Horizontal };
        //    Grid.SetRow(infoPanel2, 3);
        //    innerGrid1.Children.Add(infoPanel2);

        //    infoPanel2.Children.Add(new Label { Content = "Version", FontSize = 14, HorizontalAlignment = HorizontalAlignment.Center });
        //    infoPanel2.Children.Add(new Label { Content = "Rating", FontSize = 14, HorizontalAlignment = HorizontalAlignment.Center});
        //    infoPanel2.Children.Add(new Label { Content = "Category", FontSize = 14, HorizontalAlignment = HorizontalAlignment.Center});

        //    // Створення другого внутрішнього Grid
        //    Grid grid2 = new Grid
        //    {
        //        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF19F9F")),
        //        Margin = new Thickness(0, 10, 0, 0)
        //    };
        //    stackPanel.Children.Add(grid2);

        //    // Додавання рядків до grid2
        //    grid2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
        //    grid2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

        //    // Додавання Label і TextBlock до grid2
        //    Label descriptionLabel = new Label { Content = "Description", FontSize = 20, VerticalAlignment = VerticalAlignment.Center };
        //    grid2.Children.Add(descriptionLabel);

        //    TextBox descriptionText = new TextBox { Text = game.Description, FontSize = 14, TextWrapping = TextWrapping.Wrap, Style = transparentTextBoxStyle };
        //    Grid.SetRow(descriptionText, 1);
        //    grid2.Children.Add(descriptionText);

        //    return mainGrid;
        //}
        
        public void UpdateData()
        {
            NameTB.Text = game.Name;
            PriceTB.Text = game.Price.ToString();
            PublisherTB.Text = game.Publisher;
            VersionTB.Text = game.Version.ToString();
            RatingTB.Text = game.Rating.ToString();
            CategoryCB.SelectedItem = game.Category;
            DescriptionTB.Text = game.Description;
            if (game.GetImages.Count>0)
            {
                HeadImage.Source = MainWindow.LoadImage(game.GetImages.First());
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AreAllFieldsFilled())
                {
                    Game editGame = new Game(double.Parse(VersionTB.Text), NameTB.Text, PublisherTB.Text, double.Parse(RatingTB.Text), int.Parse(PriceTB.Text), DescriptionTB.Text, game.Part, game.Category);
                    Game editedgame = game;
                    mainWindow.GetShop.EditGame(editGame, ref editedgame);
                    game = editedgame;
                    mainWindow.GetShop.UpdateCatalog();
                    UpdateData();
                }else mainWindow.MessageShow("Please fill in all fields before saving.");
            }
            catch (Exception ex)
            {

                mainWindow.MessageShow(ex.Message);
            }
            
        }
        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(VersionTB.Text) &&
                   !string.IsNullOrWhiteSpace(NameTB.Text) &&
                   !string.IsNullOrWhiteSpace(PublisherTB.Text) &&
                   !string.IsNullOrWhiteSpace(RatingTB.Text) &&
                   !string.IsNullOrWhiteSpace(PriceTB.Text) &&
                   !string.IsNullOrWhiteSpace(DescriptionTB.Text) &&
                   game.GetImages.Count >0 &&
                   !string.IsNullOrWhiteSpace(game.Part);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (game.GetImages.Count > 0)
            {
                game.RemoveImage(game.GetImages.First().ToString());
            }
            foreach (var item in OpenImageFileDialog())
            {
                game.AddImage(item);
            }
            UpdateData();


        }
        private void CategoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            game.Category = (Category)CategoryCB.SelectedItem;
            
        }
        public string[] OpenImageFileDialog()
        {
            // Створення екземпляру OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true, // Дозволяє вибір декількох файлів
                Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp", // Фільтр для зображень
                Title = "Select images" // Заголовок вікна
            };

            // Відкриття діалогового вікна і перевірка, чи було натиснуто кнопку "Ok"
            if (openFileDialog.ShowDialog() == true)
            {
                // Повернення масиву шляхів до вибраних файлів
                return openFileDialog.FileNames;
            }
            else
            {
                // Повернення порожнього масиву, якщо користувач скасував вибір
                return new string[0];
            }
        }
        public string OpenLaunchFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true, // Дозволяє вибір декількох файлів
                Filter = "Launch files (*.exe;)|*.exe",
                Title = "Select Launch file" // Заголовок вікна
            };
            if (openFileDialog.ShowDialog() == true)
            {
                // Повернення масиву шляхів до вибраних файлів
                return openFileDialog.FileNames.FirstOrDefault();
            }
            else
            {
                // Повернення порожнього масиву, якщо користувач скасував вибір
                return game.Part;
            }
        }
        public void PopulateCategoryComboBox()
        {
            // Отримання всіх значень з перерахування Category
            var categories = Category.GetValues(typeof(Category))
                                 .Cast<Category>()
                                 .Where(c => c != Category.All);  // Фільтруємо, щоб видалити категорію All

            // Додавання кожної категорії до ComboBox
            foreach (var category in categories)
            {
                CategoryCB.Items.Add(category);
            }
        }
        private void ChangePart_Click(object sender, RoutedEventArgs e)
        {
            game.Part = OpenLaunchFileDialog();
        }
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GetShop.RemoveGame(game);           
            mainWindow.OpenMainPages();
        }
        
    }
}


    
        
        

        

