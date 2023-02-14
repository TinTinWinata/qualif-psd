using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService.Controller;

namespace WebService
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string login(string username, string password)
        {
            User user = UserController.login(username, password);

            if (user == null)
                return "Login Error";


            return serealize<User>(user);
        }

        [WebMethod]
        public string register(string email, string username, string password, string role)
        {
            return UserController.register(email, username, password, role);
        }

        [WebMethod]
        public string createGame(string name, string price)
        {
            return GameController.create(name, price);
        }

        [WebMethod]
        public string updateGame(int id, string name, string price)
        {
            return GameController.update(id, name, price);
        }

        [WebMethod]                                                                     
        public bool removeGame(int id)
        {
            return GameController.remove(id);
        }

        [WebMethod]
        public string getGame()
        {
            List<Game> gameList = GameController.get();

            return serealize<List<Game>>(gameList);
        }

        public string serealize<T>(T temp)
        {
            return JsonConvert.SerializeObject(temp, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        


        [WebMethod]
        public  string updateUser(string id, string username, string role, string email, string password)
        {
            return UserController.update(id, username, role, email, password);
        }

        [WebMethod]
        public  bool removeUser(string id)
        {
            return UserController.remove(id);
        }

        [WebMethod]
        public bool removeCart(string cartId)
        {
            return CartController.Remove(cartId);
        }

        [WebMethod]
        public string insertHeader(string userId)
        {
            return TransactionController.InsertHeader(userId);
        }

        [WebMethod]
        public string insertDetail(string gameId, string transactionId)
        {
            return TransactionController.InsertDetail(transactionId, gameId);
        }


        [WebMethod]
        public string addCart(string gameId, string userId)
        {
            return CartController.Insert(userId, gameId);
        }

        [WebMethod]
        public string getCart(string userId)
        {
            List<Cart> cartList = CartController.Get(userId);
            return serealize<List<Cart>>(cartList);
        }

        [WebMethod]
        public string buy(string userId)
        {
            return CartController.Buy(userId);
        }

        [WebMethod]
        public string showGame(string gameId)
        {
            Game game = GameController.Show(gameId);
            return serealize<Game>(game);
        }

        [WebMethod]
        public string getUserList()
        {
            return serealize<List<User>>(UserController.Get());
        }

        [WebMethod]
        public string getHeader(string userId)
        {
            return serealize<List<TransactionHeader>>(TransactionController.GetHeader(userId));
        }

        [WebMethod]
        public string getDetail(string headerId)
        {
            return serealize<List<TransactionDetail>>(TransactionController.GetDetail(headerId));
        }

        [WebMethod]
        public string showUser(string userId)
        {
            User user = UserController.Show(userId);
            return serealize<User>(user);
        }
    }
}
