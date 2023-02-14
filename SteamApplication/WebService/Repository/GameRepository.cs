using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Factory;

namespace WebService.Repository
{
    public class GameRepository
    {
        public static void create(string name, string price)
        {
            GameFactory.Create(name, price);
        }

        public static void update(int id, string name, string price)
        {
            Entities db = new Entities();
            Game game = db.Games.Find(id);
            if (game == null) return;
            game.name = name;
            game.price = price;
            db.SaveChanges();
        }

        public static bool remove(int id)
        {
            Entities db = new Entities();
            Game game = db.Games.Find(id);
            if (game == null) return false;
            db.Games.Remove(game);
            db.SaveChanges();
            return true;
        }

        public static Game Show(int gameId)
        {
            Entities db = new Entities();
            Game game = (from data in db.Games select data).Where(c => c.id == gameId).FirstOrDefault<Game>();
            return game;
        }

        public static List<Game> get()
        {
            Entities db = new Entities();

            Game game = (from data in db.Games select data).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine("First Game : ", game.name);
            List<Game> gameList = (from data in db.Games select data).ToList<Game>();

            System.Diagnostics.Debug.WriteLine("Game List From Repository : ", gameList[0]);
            return gameList;
        }

    }
}