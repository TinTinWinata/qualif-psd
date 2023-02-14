
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApplication
{
    public partial class Home : System.Web.UI.Page
    {

        private service_reference.Service ws;

        private void LoadGameData()
        {
            string res = ws.getGame();
            if (res != null)
            {
                List<Model.Game> gameList = JsonConvert.DeserializeObject<List<Model.Game>>(res);
                gameGv.DataSource = gameList;
                gameGv.DataBind();
            }
        }

        private void InitiateData()
        {
            ws = new service_reference.Service();
        }

        private void CheckAdminView()
        {
            if (Facade.UserSession.GetRole(Request).Equals("Admin"))
            {
                adminView.Visible = true;
            }
            else 
            {
                adminView.Visible = false;
            }
        }

        private void CheckUserView()
        {
            if (Facade.UserSession.GetRole(Request).Equals(""))
            {
                
                cartView.Visible = false;
            }
            else
            {
                cartView.Visible = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitiateData();
            CheckAdminView();
            CheckUserView();
            LoadGameData();
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            string name = txName.Text.Trim();
            string price = txPrice.Text.Trim();

            string res = ws.createGame(name, price);
            if(res != "")
            {
                errorLbl.Text = res;
            }
            else
            {
                RefreshPage();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string id = txtUpdateGameId.Text.Trim();
            string name = txtUpdateGameName.Text.Trim();
            string price = txtUpdateGamePrice.Text.Trim();

            string res = ws.updateGame(int.Parse(id), name, price);
            if (res != "")
            {
                errorLbl.Text = res;
            }
            else
            {
                RefreshPage();
            }
        }
        private void RefreshPage() { 
            Response.Redirect("Home.aspx");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            string id = txDeleteId.Text.Trim();
            bool res = ws.removeGame(int.Parse(id));
            if (res)
            {
                // Succesfully
                RefreshPage();
            }
            else
            {
                // Failed
                errorLblDelete.Text = "Error Deleting";
            }

        }

        protected void addCart_Click(object sender, EventArgs e)
        {
            string userId = Facade.UserSession.GetUserId(Request);
            string res = ws.addCart(txGameIdCart.Text.Trim(), userId);
            RefreshPage();
        }
    }
}