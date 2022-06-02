using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.User
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    string userId = Session["UserId"].ToString();

                    OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where Id=" + userId, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dtCheck = new DataTable();
                    daCheck.Fill(dtCheck);

                    if (dtCheck.Rows.Count > 0)
                    {
                        lblUserName.Text = dtCheck.Rows[0]["UserName"].ToString();
                        lblPassword.Text = dtCheck.Rows[0]["Password"].ToString();
                        lblName.Text = dtCheck.Rows[0]["FirstName"].ToString() + " " + dtCheck.Rows[0]["LastName"].ToString();

                        lblGender.Text = dtCheck.Rows[0]["Gender"].ToString();
                        lblEmail.Text = dtCheck.Rows[0]["Email"].ToString();
                        lblPhoneNumber.Text = dtCheck.Rows[0]["PhoneNumber"].ToString();
                        lblAddress.Text = dtCheck.Rows[0]["Address"].ToString();


                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                int userId = int.Parse(Session["UserId"].ToString());

                OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where Id=" + userId, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dtCheck = new DataTable();
                daCheck.Fill(dtCheck);

                if (dtCheck.Rows.Count > 0)
                {
                    Response.Redirect("~/User/UserEdit.aspx?UserId=" + userId.ToString());
                }
            }
        }
    }
}