using SteamApplication.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApplication
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void manageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageUser.aspx");
        }

        protected void cartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void transactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transaction.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            UserSession.Remove(Response);
            Response.Redirect("Login.aspx");
        }
    }
}