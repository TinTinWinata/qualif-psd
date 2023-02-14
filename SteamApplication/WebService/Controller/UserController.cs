using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Handler;

namespace WebService.Controller
{
    public class UserController
    {

        public static List<User> Get()
        {
            return UserHandler.Get();
        }

        public static User login(string username, string password)
        {
            if (username.Equals("") || password.Equals(""))
            {
                return null;
            }
            return UserHandler.login(username, password);
        }

        public static string update(string id, string username, string role, string email, string password)
        {
            if(id == "" || username == "" || role == "" || email == "" || password == "")
            {
                return "Please input a valid inputs!";
            }

            int intId;
            try
            {
                intId = int.Parse(id);
            }catch(Exception e)
            {
                return "Please input a valid id!";
            }

            UserHandler.update(intId, username, role, email, password);
            return "";
        }

        public static bool remove(string id)
        {
            int new_id = -1;
            try
            {
               new_id = int.Parse(id);
            }catch(Exception e)
            {
                return false;
            }
            return UserHandler.remove(new_id);
        }

        public static string register(string email, string username, string password, string role)
        {
            if (username.Equals("") || password.Equals(""))
            {
                return "Please input all input!";
            }
            UserHandler.register(email, username, password, role);
            return "";
        }

        public static User Show(string userId)
        {
            int userIntId = -1;
            try
            {
                userIntId = int.Parse(userId);
            }   catch(Exception e)
            {
                return null;
            }
            return UserHandler.Show(userIntId);
        }
    }

}