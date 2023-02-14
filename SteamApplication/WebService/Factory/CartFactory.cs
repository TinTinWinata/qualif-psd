using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Factory
{
    public class CartFactory
    {
        public static void Create(int gameId, int userId)
        {
            Entities db = new Entities();
            Cart cart = new Cart();
            cart.game_id = gameId;
            cart.user_id = userId;
            db.Carts.Add(cart);
            try
            {
                db.SaveChanges();
            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}