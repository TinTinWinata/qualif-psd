using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Handler;

namespace WebService.Controller
{
    public class CartController
    {
        public static string Insert(string userId, string gameId)
        {
            int userIntId = -1, gameIntId = -1;
            if(userId == "" || gameId == "")
            {
                return "Please input all fields!";
            }
            try
            {
                userIntId = int.Parse(userId);
                gameIntId = int.Parse(gameId);
            }catch(Exception e)
            {
                return "Please input a valid id";
            }
            CartHandler.Insert(userIntId, gameIntId);
            return "";
        }
        public static bool Remove(string id)
        {
            int newId = -1;
            try
            {
                newId = int.Parse(id);
            }catch(Exception e)
            {
                return false;
            }
            return CartHandler.Remove(newId);
        }

        public static string Buy(string userId)
        {
            int intUserId = -1; 
            
            try
            {
                intUserId = int.Parse(userId);
            }catch(Exception e)
            {
                return "Please input a valid id";
            }

            List<Cart> cartList = CartController.Get(userId);

            // Create Header
            TransactionHeader header =  TransactionHandler.InsertHeader(intUserId);

            foreach(Cart cart in cartList)
            {
                // Create Detail
                TransactionHandler.InsertDetail(header.id, cart.game_id);


                // Remove Current Cart
                CartHandler.Remove(cart.id);
            }

            return "";
            
        }

        public static List<Cart> Get(string userId)
        {
            int newId = -1;
            try
            {
                newId = int.Parse(userId);
            }catch(Exception e)
            {
                return null;
            }
            return CartHandler.Get(newId);
        }

    }
}