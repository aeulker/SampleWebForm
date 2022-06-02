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
    public partial class Login : System.Web.UI.Page
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["SessionIsActive"] != null && Session["SessionIsActive"].ToString() == "1")
            {
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [User] where UserName='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    Session["SessionIsActive"] = "1";
                    Session["UserId"] = dt.Rows[0]["Id"].ToString();
                    if (dt.Rows[0]["IsAdmin"].ToString() == "True")
                    {
                        Session["IsAdmin"] = "1";
                    }
                    else
                    {
                        Session["IsAdmin"] = "0";
                    }

                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    lblError.Text = "Kullanıcı Adı Ya da Parola Hatalı! Hesabınız yoksa kayıt ol butonu ile kayıt olabilirsiniz.";
                }

            }
        }
    }
}