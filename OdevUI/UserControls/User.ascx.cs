
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.UserControls
{
    public partial class User : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session["UserId"] != null)
                {
                    int userId =int.Parse( Session["UserId"].ToString());

                    //TODO:if(!string.IsNullOrEmpty(userName))
                    if (userId !=0)
                    {
                        OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where Id=" + userId, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                        DataTable dtCheck = new DataTable();
                        daCheck.Fill(dtCheck);
                        if (dtCheck.Rows.Count > 0)
                        {
                            lblUserName.Text = dtCheck.Rows[0]["UserName"].ToString();
                        }
                                          
                        lnkLogin.Visible = false;
                        lnkLogout.Visible = true;
                        lnkAccount.Visible = true;
                        lnkCart.Visible = true;
                    }
                }
                else
                {
                    lnkLogin.Visible = true;
                    lnkLogout.Visible = false;
                    lnkAccount.Visible = false;
                    lnkCart.Visible = false;
                }
            }
        }
    }
}
