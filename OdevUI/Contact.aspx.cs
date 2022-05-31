using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    string userId = Session["UserId"].ToString();

                    OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where Id=" + userId , WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dtCheck = new DataTable();
                    daCheck.Fill(dtCheck);

                    if (dtCheck.Rows.Count > 0)
                    {
                        hdnUserId.Value = dtCheck.Rows[0]["Id"].ToString();
                        txtEmail.Text = dtCheck.Rows[0]["Email"].ToString();
                        txtName.Text = dtCheck.Rows[0]["FirstName"].ToString() + " " + dtCheck.Rows[0]["LastName"].ToString(); ;
                    }
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtEmail.Text == string.Empty || txtSubject.Text == string.Empty || txtMessage.Text == string.Empty)
            {
                lblInfo.Text = "Lütfen gerekli bilgi alanlarını doldurunuz !";
            }
            else
            {
                string sql = "insert into [Message]([UserId],[SenderName],[Email],[Subject],[Message])  " +
                            "values ('" + Convert.ToInt32(hdnUserId.Value) + "' , " +
                                    "'" + txtName.Text + "' , " +
                                    "'" + txtEmail.Text + "' , " +
                                    "'" + txtSubject.Text + "' , " +
                                    "'" + txtMessage.Text + "' )";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
          
                lblResult.Text = "Mesajınız alındı, en kısa sürede tarafınıza dönüş yapılacaktır.";
                lblInfo.Visible= false;
                tblContact.Visible = false;
            }
        }
    }
}