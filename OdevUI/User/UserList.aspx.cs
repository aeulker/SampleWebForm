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
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }

        }

        private void BindGrid()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [User] ", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            grdUserList.DataSource = dt;
            grdUserList.DataBind();

        }

        protected void grdUserList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdUserList.EditIndex = e.NewEditIndex;
          
            BindGrid();
        }
        protected void grdUserList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdUserList.EditIndex = -1;

            BindGrid();
        }
        protected void grdUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUserList.EditIndex = e.NewPageIndex;

            BindGrid();
        }
        protected void grdUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(grdUserList.DataKeys[e.RowIndex].Values["Id"].ToString());

            string sql = "delete from [User]" +

                 " where Id=" + userId + "";

            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdUserList.EditIndex = -1;
            BindGrid();
        }

        protected void grdUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {

                TextBox txtUserName = (TextBox)grdUserList.FooterRow.FindControl("txtNUserName");
                TextBox txtFirstName = (TextBox)grdUserList.FooterRow.FindControl("txtNFirstName");
                TextBox txtPassword = (TextBox)grdUserList.FooterRow.FindControl("txtNPassword");
                TextBox txtLastName = (TextBox)grdUserList.FooterRow.FindControl("txtNLastName");
                DropDownList ddlGender = (DropDownList)grdUserList.FooterRow.FindControl("ddlNGender");
                TextBox txtEmail = (TextBox)grdUserList.FooterRow.FindControl("txtNEmail");
                TextBox txtPhoneNumber = (TextBox)grdUserList.FooterRow.FindControl("txtNPhoneNumber");
                TextBox txtAddress = (TextBox)grdUserList.FooterRow.FindControl("txtNAddress");
                CheckBox cbxIsAdmin = (CheckBox)grdUserList.FooterRow.FindControl("cbxNIsAdmin");

                string sql = "insert into [User]([UserName],[Password],[FirstName],[LastName],[Gender],[Email],[PhoneNumber],[Address],[IsAdmin])  " +
                    "values ('" + txtUserName.Text + "' , " +
                            "'" + txtPassword.Text + "' , " +
                            "'" + txtFirstName.Text + "' , " +
                            "'" + txtLastName.Text + "' , " +
                            "'" + ddlGender.SelectedValue.ToString() + "' , " +
                            "'" + txtEmail.Text + "' , " +
                            "'" + txtPhoneNumber.Text + "' , " +
                            "'" + txtAddress.Text + "' ," +
                                 cbxIsAdmin.Checked + 
                            ")";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdUserList.EditIndex = -1;
                BindGrid();
            }
        }



        protected void grdUserList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userId = Convert.ToInt32(grdUserList.DataKeys[e.RowIndex].Values["Id"].ToString());
            TextBox txtUserName = (TextBox)grdUserList.Rows[e.RowIndex].FindControl("txtUserName");
            TextBox txtFirstName = (TextBox)grdUserList.Rows[e.RowIndex].FindControl("txtFirstName");
            TextBox txtPassword = (TextBox)grdUserList.Rows[e.RowIndex].FindControl("txtPassword");
            TextBox txtLastName = (TextBox)grdUserList.Rows[e.RowIndex].FindControl("txtLastName");
            DropDownList ddlGender = (DropDownList)grdUserList.Rows[e.RowIndex].FindControl("ddlGender");
            TextBox txtEmail = (TextBox)grdUserList.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox txtPhoneNumer = (TextBox)grdUserList.Rows[e.RowIndex].FindControl("txtPhoneNumber");
            TextBox txtAddress = (TextBox)grdUserList.Rows[e.RowIndex].FindControl("txtAddress");
            CheckBox cbxIsAdmin = (CheckBox)grdUserList.Rows[e.RowIndex].FindControl("cbxIsAdmin");

            string sql = "update [User]" +
                          "set    [UserName] ='" + txtUserName.Text + "'" +
                             " ,  [Password] = '" + txtPassword.Text + "'" +
                             " ,  [FirstName] = '" + txtFirstName.Text + "'" +
                             " ,  [LastName] = '" + txtLastName.Text + "'" +
                             " ,  [Gender] = '" + ddlGender.SelectedValue.ToString() + "'" +
                             " ,  [Email] = '" + txtEmail.Text + "'" +
                             " ,  [PhoneNumber] = '" + txtPhoneNumer.Text + "'" +
                             " ,  [Address] = '" + txtAddress.Text + "'" +
                             " ,  [IsAdmin] = " + cbxIsAdmin.Checked + 

                             " where Id=" + userId + "";

            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdUserList.EditIndex = -1;
            BindGrid();
         
        }

 
    }
}