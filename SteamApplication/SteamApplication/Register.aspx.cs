using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApplication
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            service_reference.Service ws = new service_reference.Service();
            string txt = ws.register(txtEmail.Text.Trim(), txtName.Text.Trim(), txtPassword.Text.Trim(), "");
            if (txt != "")
            {
                lblError.Text = txt;
                return;
            }
            Response.Redirect("~/Login.aspx");
        }
    }
}