using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Repository;

namespace WebService.Handler
{
    public class UserHandler
    {
        public static List<User> Get()
        {
            return UserRepository.Get();
        }
        public static User login(string username, string password)
        {
            return UserRepository.login(username, password);
        }

        public static void update(int id, string username, string role, string email, string password)
        {
            UserRepository.update(id, username, role, email, password);
        }

        public static bool remove(int id)
        {
            return UserRepository.remove(id);
        }
        public static void register(string email, string username, string password, string role)
        {
            UserRepository.register(email, username, password, role);
        }

        public static User Show(int userId)
        {
            return UserRepository.Show(userId);
        }

    }
}