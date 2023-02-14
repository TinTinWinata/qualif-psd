using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApplication
{
    public partial class ManageUser : System.Web.UI.Page
    {
        private service_reference.Service ws;

        private void CheckAdmin()
        {
            string role = Facade.UserSession.GetRole(Request);
            if(role != "Admin")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAdmin();
            ws = new service_reference.Service();
            string res = ws.getUserList();
            List<Model.User> userList = JsonConvert.DeserializeObject<List<Model.User>>(res);
            userGv.DataSource = userList;
            userGv.DataBind();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string username = txUpdateUserName.Text.Trim();
            string password = txUpdateUserPassword.Text.Trim();
            string id = txUpdateUserId.Text.Trim();
            string email = txUpdateUserEmail.Text.Trim();
            string role = txUpdateUserRole.Text.Trim();
            string res = ws.updateUser(id, username, role, email, password);

            if(res != null)
            {
                errorLblUpdate.Text = res;
            }
            else
            {
                RefreshPage();
            }
           

    }

        private void RefreshPage()
        {
            Response.Redirect("ManageUser.aspx");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            string id = txDeleteId.Text.Trim();
            ws.removeUser(id);
        }
    }
}