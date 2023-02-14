using Newtonsoft.Json;
using SteamApplication.Facade;
using SteamApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApplication
{
    public partial class Transaction : System.Web.UI.Page
    {

        private void LoadData()
        {
            service_reference.Service ws = WebService.GetService();
            string userId = Facade.UserSession.GetUserId(Request);
            string res = ws.getHeader(userId);
            List<TransactionHeader> headerList = JsonConvert.DeserializeObject<List<TransactionHeader>>(res);

            if(headerList.Count == 0)
            {
                errorLbl.Text = "Empty Transaction";
            }

            foreach(TransactionHeader th in headerList)
            {
                string res2 = ws.getDetail(th.id.ToString());
                List<TransactionDetail> detailList = JsonConvert.DeserializeObject<List<TransactionDetail>>(res2);

                // Create Label
                Label label = new Label();
                label.Text = th.date.ToString("MMMM dd, yyyy");
                PlaceHolder1.Controls.Add(label);
                
                // Create Grid View
                GridView gridView = new GridView();
                gridView.DataSource = detailList;
                gridView.DataBind();

                PlaceHolder1.Controls.Add(gridView);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Middleware.UserOnly(Request, Response);
            LoadData();
        }
    }
}