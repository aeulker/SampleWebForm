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
    public partial class Messages : System.Web.UI.Page
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
            string sql = "select u.UserName as UserName,m.* from [Message] m left join [User] u on m.UserId=u.Id";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                gvMessages.DataSource = dt;
                gvMessages.DataBind();
            }
            else
            {
                DataTable dtEmpty = new DataTable();
                dtEmpty.Columns.Add("Id", typeof(int));
                dtEmpty.Columns.Add("UserId", typeof(int));
                dtEmpty.Columns.Add("UserName", typeof(string));
                dtEmpty.Columns.Add("SenderName", typeof(string));
                dtEmpty.Columns.Add("Email", typeof(string));
                dtEmpty.Columns.Add("Subject", typeof(string));
                dtEmpty.Columns.Add("Message", typeof(string));

                DataRow datatRow = dtEmpty.NewRow();
                dtEmpty.Rows.Add(datatRow);
                gvMessages.DataSource = dtEmpty;
                gvMessages.DataBind();
                gvMessages.Rows[0].Visible = false;
            }

        }
        protected void gvMessages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvMessages.DataKeys[e.RowIndex].Values["Id"].ToString());

            string sql = "delete from [Message]" +

                 " where Id=" + userId + "";

            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            BindGrid();
        }
        protected void gvMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMessages.PageIndex = e.NewPageIndex;

            BindGrid();
        }
    }
}