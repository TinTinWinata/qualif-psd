using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Handler;
using WebService.Facade;

namespace WebService.Controller
{
    public class GameController
    {
        public static string validation(string name, string price)
        {
            if(name == "" || price == "")
            {
                return "Please input a valid string";
            }
            return Helper.EMPTY;
        }
        public static string create(string name, string price)
        {
            string err = validation(name, price);
            if(err != Helper.EMPTY)
            {
                return err;
            }
            GameHandler.create(name, price);
            return Helper.EMPTY;
        }

        public static string update(int id, string name, string price)
        {
            string err = validation(name, price);
            if (err != Helper.EMPTY)
            {
                return err;
            }
            GameHandler.update(id, name, price);
            return Helper.EMPTY;
        }

        public static bool remove(int id)
        {
            return GameHandler.remove(id);
        }

        public static List<Game> get()
        {
            return GameHandler.get();
        }
        
        public static Game Show(string gameId)
        {
            int intGameId = -1;
            try
            {
                intGameId = int.Parse(gameId);
            }catch(Exception e)
            {
                return null;
            }
            return GameHandler.Show(intGameId);
        }
    }
}