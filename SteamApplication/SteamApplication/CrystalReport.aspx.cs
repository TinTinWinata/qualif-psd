using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApplication
{
    public partial class CrystalReport : System.Web.UI.Page
    {

        private void SetData()
        {
            Report.CrystalReport4 report = new Report.CrystalReport4();
            
            CrystalReportViewer1.ReportSource = report;
            Dataset.DataSet data = GetData();
            report.SetDataSource(data);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Facade.Middleware.UserOnly(Request, Response);
            SetData();
        }

        private Dataset.DataSet GetData()
        {
            service_reference.Service ws = Facade.WebService.GetService();
            string userId = Facade.UserSession.GetUserId(Request);

            Dataset.DataSet data = new Dataset.DataSet();
            var headerTable = data.transaction_header;
            var detailTable = data.transaction_detail;

            string res = ws.getHeader(userId);
            List<Model.TransactionHeader> transactionHeaders = JsonConvert.DeserializeObject<List<Model.TransactionHeader>>(res);

            foreach (Model.TransactionHeader curr in transactionHeaders)
            {
                System.Diagnostics.Debug.WriteLine("Header! --");
                var hrow = headerTable.NewRow();
                hrow["id"] = curr.id;
                hrow["user_id"] = curr.user_id;
                hrow["date"] = curr.date.ToString("MMM dd yyyy");

                headerTable.Rows.Add(hrow);

                // Search Detail
                string res_detail= ws.getDetail(curr.id.ToString());
                List<Model.TransactionDetail> transactionDetails = JsonConvert.DeserializeObject<List<Model.TransactionDetail>>(res_detail);

                // Make Dictionary to save the quantity
                Dictionary<int, int> dict = new Dictionary<int, int>();

                // List For Select Distinct
                List<Model.TransactionDetail> newDetailList = new List<Model.TransactionDetail>();

                foreach (Model.TransactionDetail curr_detail in transactionDetails)
                {
                    try
                    {
                        // Second Occured
                        dict[curr_detail.game_id] += 1;
                    }
                    catch (KeyNotFoundException e)
                    {
                        // First Occured
                        dict[curr_detail.game_id] = 1;
                        newDetailList.Add(curr_detail);
                    }

                }

                foreach (Model.TransactionDetail curr_detail in newDetailList)
                {
                    var drow = detailTable.NewRow();


                    drow["game_id"] = curr_detail.game_id;
                    drow["transaction_id"] = curr_detail.transaction_id;
                    drow["quantity"] = dict[curr_detail.game_id];

                    detailTable.Rows.Add(drow);
                }
            }
            return data;      
        }
    }
}