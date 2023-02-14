using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Repository;

namespace WebService.Handler
{
    public class GameHandler
    {

        public static Game Show(int gameId)
        {
            return GameRepository.Show(gameId);
        }
        public static void create(string name, string price)
        {
            GameRepository.create(name, price);
        }

        public static void update(int id, string name, string price)
        {
            GameRepository.update(id, name, price);
        }

        public static bool remove(int id)
        {
            return GameRepository.remove(id);
        }

        public static List<Game> get()
        {
            return GameRepository.get();
        }
    }
}