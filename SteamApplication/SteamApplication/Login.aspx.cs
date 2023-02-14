using Newtonsoft.Json;
using SteamApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void loginBtn_Click(object sender, EventArgs e)
        {
            service_reference.Service ws = new service_reference.Service();
            string text = ws.login(txtUsername.Text, txtPassword.Text);
            if (text.Equals("Login Error"))
            {
                lblError.Text = "Error Login";
            }
            else
            {
                User user = JsonConvert.DeserializeObject<User>(text);
                lblError.Text = "Succesfully Login";

                Facade.UserSession.AddUser(Response, user);
                Response.Redirect("Home.aspx");
            }
        }
    }
}