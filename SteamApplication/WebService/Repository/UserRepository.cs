using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Factory;

namespace WebService.Repository
{
    public class UserRepository
    {
        public static User login(string username, string password)
        {
            Entities db = new Entities();
            User u = (from data in db.Users
                      where data.username.Equals(username) &&
                data.password.Equals(password)
                      select data).FirstOrDefault();
            return u;
        }

        public static void update(int id, string username, string role, string email, string password)
        {
            Entities db = new Entities();

            User user = db.Users.Find(id);
            if (user == null) return;

            user.username = username;
            user.role = role;
            user.email = email;
            user.password = password;

            db.SaveChanges();
        }

        public static bool remove(int id)
        {
            Entities db = new Entities();
            User user = db.Users.Find(id);
            if (user == null) return false;
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }


        public static void register(string email, string username, string password, string role)
        {
            UserFactory.Create(username, password, role, email);
        }

        public static List<User> Get()
        {
            Entities db = new Entities();
            List<User> userList = (from data in db.Users select data).ToList<User>();
            return userList;

        }
        public static User Show(int userId)
        {
            Entities db = new Entities();
            User user= (from data in db.Users select data).Where(c => c.id == userId).FirstOrDefault<User>();
            return user;
        }
    }

}