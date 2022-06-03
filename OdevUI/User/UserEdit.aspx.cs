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
    public partial class UserEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    int userId =int.Parse(Session["UserId"].ToString());

                    OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where Id=" + userId, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dtCheck = new DataTable();
                    daCheck.Fill(dtCheck);

                    if (dtCheck.Rows.Count > 0)
                    {
                        hdnUserId.Value = userId.ToString();
                        txtUserName.Text = dtCheck.Rows[0]["UserName"].ToString();
                        txtPassword.Text = dtCheck.Rows[0]["Password"].ToString();
                        txtName.Text = dtCheck.Rows[0]["FirstName"].ToString();
                        txtSirName.Text = dtCheck.Rows[0]["LastName"].ToString();
                        ddlGender.SelectedValue = dtCheck.Rows[0]["Gender"].ToString();
                        txtEmail.Text = dtCheck.Rows[0]["Email"].ToString();
                        txtPhoneNumber.Text = dtCheck.Rows[0]["PhoneNumber"].ToString();
                        txtAddress.Text = dtCheck.Rows[0]["Address"].ToString();

                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where Id<>"+hdnUserId.Value+" and (UserName='" + txtUserName.Text + "' or Email='" + txtEmail.Text + "') ", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dtCheck = new DataTable();
            daCheck.Fill(dtCheck);

            if (dtCheck.Rows.Count > 0)
            {

                lblError.Text = "Girilen kullanıcı adı veya email ile kayıtlı kullanıcı bulunmaktadır";
            }
            else
            {
  

                string sql = "update [User]" +
                             "set [UserName] ='" + txtUserName.Text + "'" +
                             " ,  [Password] = '" + txtPassword.Text + "'" +
                             " ,  [FirstName] = '" + txtName.Text + "'" +
                             " ,  [LastName] = '" + txtSirName.Text + "'" +
                             " ,  [Gender] =' " + ddlGender.SelectedValue + "'" +
                             " ,  [Email] = '" + txtEmail.Text + "'" +
                             " ,  [PhoneNumber] = '" + txtPhoneNumber.Text + "'" +
                             " ,  [Address] = '" + txtAddress.Text + "'" +
                             " where Id=" + hdnUserId.Value + "";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Response.Redirect("~/User/UserInfo.aspx?UserId="+hdnUserId.Value);

            }
        }
    }
}