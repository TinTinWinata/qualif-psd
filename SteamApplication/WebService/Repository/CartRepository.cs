using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Factory;

namespace WebService.Repository
{
    public class CartRepository
    {
        public static void Insert(int userId, int gameId)
        {
            CartFactory.Create(gameId, userId);
        }

        public static List<Cart>  Get(int userId)
        {

            Entities db = new Entities();  
            List<Cart> cartList = (from data in db.Carts  select data).Where(c => c.user_id == userId).ToList<Cart>();
            return cartList;
        }

        public static bool Remove(int id)
        {
            Entities db = new Entities();
            Cart curr = db.Carts.Find(id);
            if (curr == null) return false;
            db.Carts.Remove(curr);
            db.SaveChanges();
            return true;
        }
    }
}