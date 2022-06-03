using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.Masterpages
{
    public partial class Account : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    string userId = Session["UserId"].ToString();

                    OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where Id=" + userId, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dtCheck = new DataTable();
                    daCheck.Fill(dtCheck);

                    if (dtCheck.Rows.Count > 0)
                    {

                        if (dtCheck.Rows[0]["IsAdmin"].ToString() != "True" &&
                            (Request.FilePath != "/User/UserInfo.aspx" &&
                            Request.FilePath != "/User/UserEdit.aspx" &&
                             Request.FilePath != "/User/UserOrders.aspx"))
                        {
                            Response.Redirect("~/Home.aspx");
                        }
                    }

                }
            }
        }
        protected void btnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}