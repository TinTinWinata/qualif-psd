using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApplication.Facade
{
    public class Middleware
    {
        public static string REDIRECT_PAGE = "Login.aspx";

        public static void UserOnly(HttpRequest Request, HttpResponse Response)
        {
            string userId = UserSession.GetUserId(Request);
            if(userId == null || userId == "")
            {
                Response.Redirect(REDIRECT_PAGE);
            }
        }
    }
}