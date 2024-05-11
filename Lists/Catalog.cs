using Project_Revin_InternetShop.Enum;
using Project_Revin_InternetShop.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Revin_InternetShop.Lists
{
    public class Catalog : Collections
    {
        
        private Category category;
        private List<Game> games = new List<Game>();
        public Catalog()
        {

        }
        public List<Game> Game
        {
            get { return games; }
        }
        public Catalog(Category cat)
        {
            Category = cat;
        }
        public Catalog(Category cat, List<Game> game) : this(cat)
        {
            games = game;
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public override void AddGame(Game game)
        {
            throw new NotImplementedException();
        }
        public override void RemoveGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
