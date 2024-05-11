using Project_Revin_InternetShop.Enum;
using Project_Revin_InternetShop.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Revin_InternetShop.Lists
{
    public abstract class Collections
    {
        Category category;
        List<Game> game;

        public abstract void RemoveGame(Game game);
        public abstract void AddGame(Game game);
    }
}
