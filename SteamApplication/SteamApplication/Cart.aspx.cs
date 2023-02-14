using SteamApplication.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApplication
{
    public partial class Cart : System.Web.UI.Page
    {

        private void LoadData()
        {
            service_reference.Service ws = WebService.GetService();
            string userId = UserSession.GetUserId(Request);
            string res = ws.getCart(userId);
            System.Diagnostics.Debug.WriteLine("Res : ", res);
            List<Model.Cart> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.Cart>>(res);
            if(list == null || list.Count == 0)
            {
                errorLbl.Text = "Empty List";
            }
            cartGridView.DataSource = list;
            cartGridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Middleware.UserOnly(Request, Response);
            LoadData();
        }

        protected void buyBtn_Click(object sender, EventArgs e)
        {
            service_reference.Service ws = WebService.GetService();
            string userId = UserSession.GetUserId(Request);
            ws.buy(userId);
        }
    }
}