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
    public partial class UserOrders : System.Web.UI.Page
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
            int userId = 0;
            if (Session["UserId"] == null)
                return;

            userId = Convert.ToInt32(Session["UserId"]);

            string sql = "SELECT "
                      + "           o.UserId  "
                      + "         , o.Id                            as OrderId "
                      + "         , MAX(o.OrderDate)                as OrderDate "
                      + "         , SUM(od.Quantity)                as OrderCount "
                      + "         , SUM(od.Quantity * od.UnitPrice) as OrderTotal "
                      + "          FROM  "
                      + "          [Order] o      "
                      + "          INNER JOIN [OrderDetail] od on od.OrderId = o.Id "
                      + "          WHERE o.UserId =" + userId.ToString()
                      + "          GROUP BY o.UserId,o.Id ";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                hdnActiveOrderId.Value = string.Empty;
                //tblOrderDetail.Visible = false;


            }
            gvOrders.DataSource = dt;
            gvOrders.DataBind();
        }

        private void BindOrderDetailGrid()
        {
            if (hdnActiveOrderId.Value != string.Empty)
            {
                string sql = "Select  p.ProductName,od.* from [OrderDetail] od inner join [Product] p on od.ProductId=p.Id  where od.OrderId=" + hdnActiveOrderId.Value.ToString();

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    //tblOrderDetail.Visible = true;

                   
                }
                gvOrderDetail.DataSource = dt;
                gvOrderDetail.DataBind();
            }

        }
        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            var orderId = Convert.ToInt32(gvOrders.SelectedRow.Cells[0].Text);
            if (orderId > 0)
            {
                hdnActiveOrderId.Value = orderId.ToString();
                BindOrderDetailGrid();
            }
        }
        protected void gvOrderDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrderDetail.PageIndex = e.NewPageIndex;

            BindOrderDetailGrid();
        }
        protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrders.PageIndex = e.NewPageIndex;

            BindGrid();
        }
    }
}