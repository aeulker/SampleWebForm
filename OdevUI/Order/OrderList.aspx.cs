using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.Order
{
    public partial class OrderList : System.Web.UI.Page
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
            string sql = "SELECT "
                      + "          userOrder.UserName as UserName "
                      + "         , MAX(userOrder.Id) as OrderId "
                      + "         , MAX(userOrder.OrderDate) as OrderDate "
                      + "         , SUM(od.Quantity) as OrderCount "
                      + "         , SUM(od.Quantity * od.UnitPrice) as OrderTotal "
                      + "          FROM "
                      + "          ( "
                      + "              SELECT u.UserName, o.* from[Order] o "
                      + "              INNER JOIN[User] u on o.UserId = u.Id "
                      + "          ) as userOrder "
                      + "          INNER JOIN OrderDetail od on od.OrderId = userOrder.Id "
                      + "         GROUP BY userOrder.UserName ";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                hdnActiveOrderId.Value = string.Empty;
                //tblOrderDetail.Visible = false;

                gvOrders.DataSource = dt;
                gvOrders.DataBind();
            }

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

                    gvOrderDetail.DataSource = dt;
                    gvOrderDetail.DataBind();
                }
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