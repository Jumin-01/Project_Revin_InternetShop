using Project_Revin_InternetShop.AutorizationWindows;
using Project_Revin_InternetShop.Enum;
using Project_Revin_InternetShop.Games;
using Project_Revin_InternetShop.Login;
using Project_Revin_InternetShop.Pages;
using Project_Revin_InternetShop.Pages.AdminPages;
using Project_Revin_InternetShop.Shops;
using Project_Revin_InternetShop.Users;
using System;
using System.Collections;
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

namespace Project_Revin_InternetShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow loginWindow ;
        
        ViewPage viewPage;
        LibraryPage libraryPage;
        SearchPage searchPage;
        AdminViewPage adminViewPage;

        Shop shop = new Shop();
        
        public MainWindow()
        {
            InitializeComponent();

            shop.Notify += MessageShow;
            //shop.Registration("jumin", "Revin", "Veniamin", "qwerty", false);
            //shop.Registration("admin", "Admin", "User", "password123", true);
            //shop.Authorization("admin", "password123");
            //shop.authorizedUser.ReplenishBalance(500);
            //shop.AddGame(new Game(1.0, "Alien Shooter", "Sigma Team", 4.5, 100, "Нескінченна темрява і похмурі, протяжні переходи військового комплексу, що став обителлю зла, коли тисячі кровожерливих монстрів заповнили його офіси, склади і таємничі лабораторії.\r\nВаша місія проста: очистити базу від нечисті. Вас забезпечать вибухівкою, щоб отримати доступ до виходів, з яких нескінченною лавиною виливаються тисячі безжальних створінь. Стаціонарна гармата допоможе вам в обороні. Ви зможете купити найпросунутішу зброю, яка тільки продається за гроші. Заробивши достатню кількість папірців, ви зможете екіпірувати себе додатковим озброєнням у збройовій і біомеханічними імплантами, які перетворять вас на надлюдину.\r\nНашестя інопланетних тварюк уже розпочалося, і ми маємо лише один шанс зупинити їх: просто в зоні їхньої висадки! Не дайте їм покинути лабораторний комплекс, ви - наша остання надія. Доля людства залежить тільки від вас!\r\nБлизько 1000 монстрів на кожній карті, до 100 монстрів одночасно на ігровому екрані\r\nБагатогодинні ігри з 10 місіями та режимом \"Виживання\"\r\n\"Живий\" персонаж чоловічої або жіночої статі\r\nМожливості поліпшення персонажа\r\n9 видів зброї масового знищення\r\nЧервона або зелена кров\r\nДуже багатий вибір ворогів\r\nДинамічна музика, що задає бойовий настрій\r\nДодаткове спорядження - ліхтарі, аптечки, бойові дрони", "C:\\Program Files (x86)\\Alien Shooter\\AlienShooter.exe", Category.Shooter));
            //shop.GetGames.Last().AddImage("C:\\Users\\Веніамін Ревін\\Desktop\\Alien ShooterImage.jpg");

            //shop.AddGame(new Game(1.2, "Diplomacy is Not an Option", "Door 407", 3, 75, "Ви народилися феодалом. Звучить непогано, правда? Але Вам набридли полювання, страти і турніри. Навіть бенкети з прекрасними дівчатами вже не надихають. Залишилася єдина мрія - Ваш замок, оточений ордами ворогів. Ви б точно не стали вести переговори.", "C:\\GOG Games\\Diplomacy is Not an Option\\Diplomacy is Not an Option.exe", Category.Strategy));
            //shop.GetGames.Last().AddImage("C:\\Users\\Веніамін Ревін\\Desktop\\Diplomacy is Not an OptionImage1.jpg");

            //shop.AddGame(new Game(1.0, "DoorKickers2", "KillHouse Games", 4, 96, "Довгоочікуване продовження популярної тактичної гри Door Kickers, Оперативна група Північ пропонує вам найкраще зображення сучасного ближнього бою та тактики у відеогрі. Відтепер доступна у ранньому доступі!\r\n\r\nDoor Kickers 2 - це тактико-стратегічна гра про використання засобів розвідки та управління підрозділами спеціального призначення у відчайдушних рейдах для нейтралізації та захоплення терористів у вигаданій країні Новеракі, що на Близькому Сході.", "C:\\Program Files (x86)\\Door Kickers 2 Task Force North v0.35\\DoorKickers2.exe", Category.Shooter));
            //shop.GetGames.Last().AddImage("C:\\Users\\Веніамін Ревін\\Desktop\\DoorKickers2Image.jpg");

            //shop.AddGame(new Game(1.0, "Factorio", "Wube Software LTD", 5, 200, "Factorio - це гра, в якій ви будуєте та обслуговуєте фабрики. Ви будете видобувати ресурси, досліджувати технології, будувати інфраструктуру, автоматизувати виробництво та боротися з ворогами. На початку ви будете рубати дерева, видобувати руди, створювати механічну зброю та транспортні ремені вручну, але за короткий час ви зможете стати індустріальною електростанцією з величезними сонячними полями, нафтопереробкою та крекінгом, виробництвом та впровадженням будівельних та логістичних роботів, і все це для задоволення ваших потреб у ресурсах. Однак така інтенсивна експлуатація ресурсів планети не подобається місцевим жителям, тому вам доведеться бути готовим захистити себе і свою машинну імперію.\r\n\r\nОб'єднайте зусилля з іншими гравцями в кооперативному режимі, створюйте величезні заводи, співпрацюйте та делегуйте завдання між собою та друзями. Додавайте модифікації, щоб збільшити задоволення від гри, від невеликих налаштувань і допоміжних модів до повної перебудови гри, підтримка модифікацій від Factorio дозволила творцям контенту з усього світу створювати цікаві та інноваційні функції. Хоча основний ігровий процес відбувається за сценарієм вільної гри, існує ціла низка цікавих завдань у вигляді Сценаріїв. Якщо ви не знайшли жодної карти або сценарію, який би вам сподобався, ви можете створити власну за допомогою вбудованого редактора карт, розмістити об'єкти, ворогів і місцевість так, як вам подобається, і навіть додати свій власний сценарій, щоб зробити ігровий процес цікавішим.", "D:\\GAMES\\Factorio\\bin\\x64\\factorio.exe", Category.Strategy));
            //shop.GetGames.Last().AddImage("C:\\Users\\Веніамін Ревін\\Desktop\\factorioimage1.jpg");

            //shop.AddGame(new Game(1.0, "Far Cry 3", "Ubisoft", 4, 96, "Far Cry 3 - це шутер від першої особи у відкритому світі, дія якого розгортається на острові, не схожому на інші. Місці, де озброєні до зубів воєначальники торгують рабами. Де полюють на чужинців заради викупу. І коли ви вирушаєте у відчайдушну подорож, щоб врятувати своїх друзів, ви розумієте, що єдиний спосіб врятуватися від цієї темряви... це прийняти її.", "C:\\Program Files (x86)\\Far Cry 3\\bin\\FC3Updater.exe", Category.Action));
            //shop.GetGames.Last().AddImage("C:\\Users\\Веніамін Ревін\\Desktop\\Far cru image1.jpg");

            //shop.AddGame(new Game(1.0, "Grey Hack", "Loading Home", 4, 96, "Grey Hack - багатокористувацька гра - симулятор хакера.\r\n\r\nВи граєте за хакера з повною свободою дій у великій мережі процедурно генерованих комп'ютерів.\r\n\r\nНа початку гри вам будуть доступні такі програми, як File Explorer, Terminal і Text Editor. У міру того, як ви розвиватимете свої навички, ви зможете встановлювати і використовувати нові утиліти.\r\n\r\nТермінал має фундаментальне значення і заснований на реальних командах UNIX. Це основний інструмент для успішного проведення хакерських атак.", "D:\\Игры\\Grey Hack v0.8.5115\\Grey Hack v0.8.5115\\Grey Hack.exe", Category.Simulation));
            //shop.GetGames.Last().AddImage("C:\\Users\\Веніамін Ревін\\Desktop\\header.jpg");
            //shop.CreateCatalogs();
            //shop.SaveToJson("Shop");
            shop = Shop.LoadFromJson("Shop");
            loginWindow = new LoginWindow(this);
            
            viewPage = new ViewPage(this);
            libraryPage = new LibraryPage(this);
            searchPage = new SearchPage(this);
            adminViewPage = new AdminViewPage(this);
            UpdateUserLabel();
            OpenMainPages();



        }
        public Shop GetShop { get { return shop; } }

        public void Registration(User user)
        {
            shop.Registration(user.Username, user.Firstname, user.Lastname, user.Password, user.Root);
            shop.SaveToJson("Shop");
        }
        public void LogIn(string username, string pass)
        {
            shop.Authorization(username, pass);
            UpdateUserLabel();
            shop.SaveToJson("Shop");
        }
        public void UpdateUserLabel() 
        {
            if (shop.authorizedUser != null)
            {            
                UserLabel.Content = $"User: {shop.authorizedUser.Username} \nBalance: {shop.authorizedUser.Balance}";
            }else UserLabel.Content = $"User: ... \nBalance: 0";
        }
        public void MessageShow(String str)
        {
            MessageBox.Show(str);
        }

        public void OpenMainPages()
        {
            if (shop.authorizedUser != null && shop.authorizedUser.Root == true)
            {
                adminViewPage.CreateAllCustomGrid();
                ViewFrame.Navigate(adminViewPage);
            }
            else
            {
                viewPage.CreateAllCustomGrid();
                ViewFrame.Navigate(viewPage);
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMainPages();
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            libraryPage.CreateLibraryGrid();
            ViewFrame.Navigate(libraryPage);
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                searchPage.CreateSearchGrid(shop.SearchGame(SearchBox.Text));
                ViewFrame.Navigate(searchPage);
            } 
            
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            //loginWindow = new LoginWindow(this);
            MyPopup.IsOpen = true;
            
            
        }
        public void CloseLoginWindow()
        {
            loginWindow.Close();
            OpenMainPages();

        }
        public static BitmapImage LoadImage(string imagePath)
        {
            // Створення нового об'єкту BitmapImage
            BitmapImage bitmap = new BitmapImage();

            // Ініціалізація BitmapImage з Uri
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();

            // Встановлення BitmapImage як Source для елемента Image
            return bitmap;
        }
        private void LogButo_Click(object sender, RoutedEventArgs e)
        {
            loginWindow = new LoginWindow(this);
            loginWindow.Show();
            loginWindow.Owner = this;
        }

        private void OutButo_click(object sender, RoutedEventArgs e)
        {
            shop.LogOut();
            OpenMainPages();
            UpdateUserLabel();
            shop.SaveToJson("Shop");
        }

        private void ReplenishBalanceBut_Click(object sender, RoutedEventArgs e)
        {
            
            if (shop.authorizedUser != null )
            {
                int bal = 0;
                int.TryParse(ReplenishBalanceTB.Text, out bal);
                if (bal>=0)
                {
                    shop.authorizedUser.ReplenishBalance(bal);
                    UpdateUserLabel();                   
                    shop.SaveToJson("Shop");
                }
                ReplenishBalanceTB.Text = "";

            }

            
        }
    }
}
