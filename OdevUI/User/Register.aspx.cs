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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
 
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where UserName='" + txtUserName.Text + "' or Email='" + txtEmail.Text + "'", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dtCheck = new DataTable();
            daCheck.Fill(dtCheck);

            if (dtCheck.Rows.Count > 0)
            {

                lblError.Text = "Girilen kullanıcı adı veya email ile kayıtlı kullanılı bulunmaktadır";
            }
            else
            {
                int gender = Convert.ToInt32(ddlGender.SelectedValue);
                string sql = "insert into [User]([UserName],[Password],[FirstName],[LastName],[Gender],[Email],[PhoneNumber],[Address],[IsAdmin])  " +
                            "values ('" + txtUserName.Text + "' , " +
                                    "'" + txtPassword.Text + "' , " +
                                    "'" + txtName.Text + "' , " +
                                    "'" + txtSirName.Text + "' , " +
                                    gender + " , " +
                                    "'" + txtEmail.Text + "' , " +
                                    "'" + txtPhoneNumber.Text + "' , " +
                                    "'" + txtAddress.Text + "' ," +
                                    0 + ")";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Response.Redirect("~/User/Login.aspx");

            }
        }
    }
}