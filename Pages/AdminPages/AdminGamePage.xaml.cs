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
            
        }
       
        
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


    
        
        

        

