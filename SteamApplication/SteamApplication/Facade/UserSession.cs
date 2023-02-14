using SteamApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApplication.Facade
{
    public class UserSession
    {
        public static string CURR_ROLE = "";
        public static string ROLE_COOKIES = "user_cookie";
        public static string USER_ID_COOKIES = "user_id_cookie";

        public static string CURR_ID = "";

        private static void AddUserId(HttpResponse Response, User user)
        {
            HttpCookie cookie = new HttpCookie(USER_ID_COOKIES);
            cookie.Value = user.id.ToString();
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(cookie);
            CURR_ID = user.id.ToString();

        }

        public static void Remove(HttpResponse Response)
        {
            HttpCookie idCookie = new HttpCookie(USER_ID_COOKIES);
            idCookie.Value = null;
            Response.Cookies.Add(idCookie);

            HttpCookie roleCookie = new HttpCookie(ROLE_COOKIES);
            roleCookie.Value = null;
            Response.Cookies.Add(roleCookie);
        }

        private static void AddUserRole(HttpResponse Response, User user)
        {
            HttpCookie cookie = new HttpCookie(ROLE_COOKIES);
            cookie.Value = user.role;
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(cookie);
            CURR_ROLE = user.role;
        }


        public static void AddUser(HttpResponse Response, User user)
        {
            AddUserId(Response, user);
            AddUserRole(Response, user);
        }
        
        public static string GetUserId(HttpRequest Request)
        {
            if (Request.Cookies[USER_ID_COOKIES] != null)
            {
                 CURR_ID= Request.Cookies[USER_ID_COOKIES].Value;
            }
            return CURR_ID;
        }

        public static void CheckRole(HttpRequest Request)
        {
            CURR_ROLE = Request.Cookies[ROLE_COOKIES].Value;
        }

        public static string GetRole(HttpRequest Request)
        {

            if (Request.Cookies[ROLE_COOKIES] != null)
            {
                CURR_ROLE = Request.Cookies[ROLE_COOKIES].Value;
            }
            return CURR_ROLE;
        }
    }
}