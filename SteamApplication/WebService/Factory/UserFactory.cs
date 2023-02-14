using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Factory
{
    public class UserFactory
    {
        public static void Create(string username, string password, string role, string email)
        {
            Entities db = Facade.Helper.GetDb();
            User user = new User();

            string currRole = role == "" ? "Member" : role;
            user.role = currRole;

            user.username = username;
            user.password = password;
            user.email = email;

            db.Users.Add(user);
            Facade.Helper.SaveDb();
        }
    }
}