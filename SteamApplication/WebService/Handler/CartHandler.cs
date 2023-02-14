using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Repository;

namespace WebService.Handler
{
    public class CartHandler
    {
        public static void Insert(int userId, int gameId)
        {
            CartRepository.Insert(userId, gameId);
        }

        public static List<Cart> Get(int userId)
        {

            return CartRepository.Get(userId);
        }

        public static bool Remove(int id)
        {
            return CartRepository.Remove(id);
        }
    }
}