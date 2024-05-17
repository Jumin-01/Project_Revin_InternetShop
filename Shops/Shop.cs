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
            throw new NotImplementedException();
        }
        public void UpdateCatalog()
        {
            throw new NotImplementedException();
        }
        public void EditGame(Game newData, ref Game gameToEdit)
        {
            throw new NotImplementedException();
        }
        public void Registration(string regUsername, string regFirstname, string regLastname, string regPassword, bool root)
        {
            throw new NotImplementedException();
        }

        public void Authorization(string regUsername, string regPassword)
        {
            throw new NotImplementedException();
        }

        public void AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(Game game)
        {
            throw new NotImplementedException();
        }
        public List<Game> SearchGame(string query)
        {
            throw new NotImplementedException();
        }
        
        
    }
}
