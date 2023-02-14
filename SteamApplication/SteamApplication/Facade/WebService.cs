using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApplication.Facade
{
    public class WebService
    {
        private static service_reference.Service ws;


        public static service_reference.Service GetService()
        {
            if(ws == null)
            {
                ws = new service_reference.Service();
            }
            return ws;
        }

    }
}