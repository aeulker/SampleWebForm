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
            string sql = "select u.UserName as UserName,m.* from [Message] m inner join [User] u on m.UserId=u.Id";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvMessages.DataSource = dt;
            gvMessages.DataBind();

        }
        protected void gvMessages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvMessages.DataKeys[e.RowIndex].Values["Id"].ToString());

            string sql = "delete from [Message]" +

                 " where Id=" + userId + "";

            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //gvMessages.EditIndex = -1;
            BindGrid();
        }
    }
}