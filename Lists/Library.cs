using Project_Revin_InternetShop.Enum;
using Project_Revin_InternetShop.Games;
using Project_Revin_InternetShop.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Revin_InternetShop.Lists
{
    public class Library : Collections
    {
        private User owner;
        private Category category = Category.All;
        private List<Game> games = new List<Game>();

        public Library(User owner)
        {
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner), "Owner cannot be null.");
        }
        public List<Game> Game
        {
            get { return games; }
        }
        public override void AddGame(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game), "Game cannot be null.");
            }

            if (games.FirstOrDefault(g => g.Name == game.Name) != null)
            {
                throw new InvalidOperationException("The game is already in the library.");
            }

            games.Add(game);
            
        }
        public override void RemoveGame(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game), "Game cannot be null.");
            }

            if (!games.Contains(game))
            {
                throw new InvalidOperationException("The game is not found in the library.");
            }

            games.Remove(game);
           
        }
    }
}