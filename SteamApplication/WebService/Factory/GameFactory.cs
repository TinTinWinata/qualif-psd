using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Factory
{
    public class GameFactory
    {
        public static void Create(string name, string price)
        {
            Entities db = new Entities();
            Game game = new Game();
            game.name = name;
            game.price = price;
            db.Games.Add(game);
            db.SaveChanges();
        }
    }
}