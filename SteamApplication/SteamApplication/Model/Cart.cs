using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApplication.Model
{
    public class Cart
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int game_id { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}