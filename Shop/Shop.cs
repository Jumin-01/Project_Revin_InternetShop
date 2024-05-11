using Project_Revin_InternetShop.Enum;
using Project_Revin_InternetShop.Games;
using Project_Revin_InternetShop.Lists;
using Project_Revin_InternetShop.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Revin_InternetShop.Shop
{
    public class Shop
    {
        public delegate void PrintHandler(string message);
        event PrintHandler Notify;
        public static int CountUser { get; set; }
        public User authorizedUser { get; set; } = null;

        private List<User> users = new List<User>();
        private List<Game> games = new List<Game>();
        private List<Catalog> catalogs = new List<Catalog>();

        public List<Game> GetGames { get { return games; } }
        public List<Catalog> GetCatalogs { get { return catalogs; } }
        public List<User> GetUsers { get { return users; } }

        public void CreateCatalogs()
        {

            // Перевірка, що список ігор не порожній
            if (games == null || games.Count == 0)
            {
                throw new InvalidOperationException("There are no games to categorize.");
            }

            // Ініціалізація словника для зберігання каталогів за категоріями
            Dictionary<Category, Catalog> catalogMap = new Dictionary<Category, Catalog>();

            // Створення каталогу для кожної категорії
            foreach (Category category in Category.GetValues(typeof(Category)))
            {
                catalogMap[category] = new Catalog(category);
            }

            // Розподіл ігор по каталогам
            foreach (var game in games)
            {
                if (game != null)
                {
                    // Додавання гри до каталогу категорії "All"
                    catalogMap[Category.All].AddGame(game);

                    // Додавання гри до відповідного каталогу за категорією
                    if (catalogMap.ContainsKey(game.Category))
                    {
                        catalogMap[game.Category].AddGame(game);
                    }
                }
            }

            // Додавання всіх каталогів у список каталогів
            catalogs.Clear();
            catalogs.AddRange(catalogMap.Values);

            //throw new NotImplementedException();
        }
        public void UpdateCatalog()
        {
            // Перевірка, що список ігор не порожній
            if (games == null || games.Count == 0)
            {
                throw new InvalidOperationException("There are no games to update in the catalogs.");
            }

            // Ініціалізація словника для зберігання каталогів за категоріями
            Dictionary<Category, Catalog> catalogMap = new Dictionary<Category, Catalog>();

            // Створення каталогу для кожної категорії
            foreach (Category category in Category.GetValues(typeof(Category)))
            {
                catalogMap[category] = new Catalog(category);
            }

            // Розподіл ігор по каталогам заново
            foreach (var game in games)
            {
                if (game != null)
                {
                    // Додавання гри до каталогу категорії "All"
                    catalogMap[Category.All].AddGame(game);

                    // Додавання гри до відповідного каталогу за категорією
                    if (catalogMap.ContainsKey(game.Category))
                    {
                        catalogMap[game.Category].AddGame(game);
                    }
                }
            }

            // Очищення існуючих каталогів і додавання оновлених
            catalogs.Clear();
            catalogs.AddRange(catalogMap.Values);

            // Сповіщення про успішне оновлення каталогів
            Notify?.Invoke("Catalogs have been successfully updated.");
        }
        public void EditGame(Game newData, ref Game gameToEdit)
        {
            if (newData == null || gameToEdit == null)
            {
                throw new ArgumentNullException("Neither the new data nor the game to edit can be null.");
            }

            if (authorizedUser == null || !authorizedUser.Root)
            {
                Notify?.Invoke("Edit failed: Unauthorized access.");
                return;
            }

            // Оновлення властивостей гри згідно з новими даними
            gameToEdit.Name = newData.Name ?? gameToEdit.Name; // Оновлюється, якщо newData.Name не є null
            gameToEdit.Publisher = newData.Publisher ?? gameToEdit.Publisher;
            gameToEdit.Description = newData.Description ?? gameToEdit.Description;
            gameToEdit.Rating = newData.Rating >= 0 && newData.Rating <= 5 ? newData.Rating : gameToEdit.Rating;
            gameToEdit.Price = newData.Price >= 0 ? newData.Price : gameToEdit.Price; // Перевірка на негативну ціну
            gameToEdit.Part = newData.Part ?? gameToEdit.Part;
            gameToEdit.Category = newData.Category; // Припускаючи, що Category завжди має валідне значення

            Notify?.Invoke($"Game {gameToEdit.Name} successfully edited.");
            UpdateCatalog();
        }
        public void Registration(string regUsername, string regFirstname, string regLastname, string regPassword, bool root)
        {
            if (string.IsNullOrEmpty(regUsername) || string.IsNullOrEmpty(regFirstname) ||
                string.IsNullOrEmpty(regLastname) || string.IsNullOrEmpty(regPassword))
            {
                throw new ArgumentException("Registration data cannot be null or empty.");
            }

            if (!users.Any(x => x.Username == regUsername))
            {
                User registeredUser = new User(regUsername, regFirstname, regLastname, regPassword, root);
                users.Add(registeredUser);
                Notify?.Invoke("User successfully registered");
            }
            else
            {
                Notify?.Invoke("Registration failed: username already exists");
            }

            CountUser = users.Count;
        }

        public void Authorization(string regUsername, string regPassword)
        {
            if (string.IsNullOrEmpty(regUsername) || string.IsNullOrEmpty(regPassword))
            {
                throw new ArgumentException("Username or password cannot be null or empty.");
            }

            User user = users.FirstOrDefault(x => x.Username.Equals(regUsername) && x.Password == regPassword);
            if (user != null)
            {
                authorizedUser = user;
                Notify?.Invoke("User successfully authorized");
            }
            else
            {
                Notify?.Invoke("Authorization failed: invalid username or password");
            }
        }

        public void AddGame(Game game)
        {
            if (authorizedUser.Root)
            {
                if (game == null)
                {
                    throw new ArgumentNullException(nameof(game), "Game cannot be null.");
                }

                if (!games.Contains(game))
                {
                    games.Add(game);
                    Notify?.Invoke($"Game {game.Name} successfully added.");
                }
                else
                {
                    Notify?.Invoke("Add failed: Game already exists in the list.");
                }
            }
            else Notify?.Invoke("Add failed: We don't have enough powers");
            
        }

        public void RemoveGame(Game game)
        {
            if (authorizedUser.Root)
            {
                if (game == null)
                {
                    throw new ArgumentNullException(nameof(game), "Game cannot be null.");
                }

                if (games.Contains(game))
                {
                    games.Remove(game);
                    Notify?.Invoke($"Game {game.Name} successfully removed.");
                }
                else
                {
                    Notify?.Invoke("Remove failed: Game not found in the list.");
                }
            }
            else Notify?.Invoke("Remove failed: We don't have enough powers");
           
        }
        public List<Game> SearchGame(string query)
        {
            // Перевірка, що строка запиту не є null або пустою
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Search query cannot be null or empty.", nameof(query));
            }

            // Приведення запиту до нижнього регістру один раз перед пошуком
            var lowerCaseQuery = query.ToLower();

            // Використання делегата Func<T, bool> для фільтрації списку ігор
            Func<Game, bool> matchCriteria = game => game.Name.ToLower().Contains(lowerCaseQuery);

            // Використання LINQ з делегатом для пошуку відповідних ігор
            var selectedGames = games.Where(matchCriteria).ToList();

            return selectedGames;
            
        }


    }
}