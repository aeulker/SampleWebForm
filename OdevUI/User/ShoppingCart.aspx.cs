using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.User
{
    public partial class ShoppingCart : System.Web.UI.Page
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
            string sql = " Select p.ProductName " +
                        ", (select top 1 pi.ImageUrl from ProductImage pi where pi.ProductId = p.Id ) as ProductImageUrl " +
                        ", sc.* " +
                        " from [ShoppingCart] sc inner join Product p on sc.ProductId =p.Id where sc.SessionId='" + Session.SessionID + "'";

            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvShoppingCartList.DataSource = dt;
            gvShoppingCartList.DataBind();
        }
        protected void gvShoppingCartList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblMessage.Text=string.Empty; 
            if (Session["UserId"] == null)
            {
                gvShoppingCartList.EditIndex = -1;
                lblMessage.Text = "Satın alma işlemi gerçekleştirmek  için giriş yapmalısınız ";
            }
            else
            {
                gvShoppingCartList.EditIndex = e.NewEditIndex;
            }
            
            BindGrid();
        }

        protected void gvShoppingCartList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            lblMessage.Text = string.Empty;
            gvShoppingCartList.EditIndex = -1;

            BindGrid();
        }

        protected void gvShoppingCartList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShoppingCartList.PageIndex = e.NewPageIndex;

            BindGrid();
        }

        protected void gvShoppingCartList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMessage.Text = string.Empty;
            int shoppingCartId = Convert.ToInt32(gvShoppingCartList.DataKeys[e.RowIndex].Values["Id"].ToString());

            try
            {
                string sql = " delete from [ShoppingCart]  where Id=" + shoppingCartId + "";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            gvShoppingCartList.EditIndex = -1;
            BindGrid();
        }

        protected void gvShoppingCartList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblMessage.Text = string.Empty;
            int userId = 0;
            int orderId = 0;
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/User/Login.aspx");

            }
            else
            {
                userId = Convert.ToInt32((string)Session["UserId"]);
                int shoppingCartId = Convert.ToInt32(gvShoppingCartList.DataKeys[e.RowIndex].Values["Id"].ToString());
                TextBox txtQuantity = (TextBox)gvShoppingCartList.Rows[e.RowIndex].FindControl("txtQuantity");
                TextBox txtShippingInfo = (TextBox)gvShoppingCartList.Rows[e.RowIndex].FindControl("txtShippingInfo");

                try
                {
                    int quantity = int.Parse(txtQuantity.Text);
                    string sessionId = Session.SessionID;


                    string checkSql = "    Select sc.*             " +
                                       "         ,  p.UnitPrice       " +
                                       "         ,  p.Discount        " +
                                       "    from ShoppingCart sc     " +
                                       "    inner join Product p on sc.ProductId=p.Id  " +
                                       "    where sc.SessionId='" + sessionId + "' and sc.Id=" + shoppingCartId;

                    OleDbDataAdapter daCheckShoppingCart = new OleDbDataAdapter(checkSql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dtCheckShoppingCartTable = new DataTable();
                    daCheckShoppingCart.Fill(dtCheckShoppingCartTable);

                    if (dtCheckShoppingCartTable.Rows.Count > 0)
                    {
                        string unitPrice = dtCheckShoppingCartTable.Rows[0]["UnitPrice"].ToString();
                        string discount = dtCheckShoppingCartTable.Rows[0]["Discount"].ToString();
                        string productId = dtCheckShoppingCartTable.Rows[0]["ProductId"].ToString();

                        string insertOrderSql = "insert into [Order] (UserId,OrderDate,ShippingInfo) values(" + userId + ",'" + DateTime.Now.ToString("G") + "','" + txtShippingInfo.Text + "')";
                        string lastRecordIdSql = "select @@Identity ";

                        using (OleDbConnection con = new OleDbConnection(WebConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                        {
                            try
                            {
                                using (OleDbCommand cmdInsertOrderCommand = new OleDbCommand(insertOrderSql, con))
                                {
                                    if (con.State == ConnectionState.Closed)
                                        con.Open();

                                    using (OleDbCommand cmdLastRecord = new OleDbCommand(lastRecordIdSql, con))
                                    {
                                        cmdInsertOrderCommand.ExecuteNonQuery();
                                        orderId = (int)cmdLastRecord.ExecuteScalar();

                                        if (orderId > 0)
                                        {
                                            string insertOrderDetailSql = " insert into OrderDetail (OrderId,ProductId,UnitPrice,Quantity,Discount) " +
                                                                          " values(" + orderId + "," + productId + "," + unitPrice + "," + txtQuantity.Text + "," + discount + ")";

                                            using (OleDbCommand orderDetailCommand = new OleDbCommand(insertOrderDetailSql, con))
                                            {

                                                using (OleDbCommand orderDetailLastRecordCommand = new OleDbCommand(lastRecordIdSql, con))
                                                {
                                                    orderDetailCommand.ExecuteNonQuery();
                                                    int orderDetailId = (int)orderDetailLastRecordCommand.ExecuteScalar();

                                                    if (orderDetailId > 0)
                                                    {
                                                        string deleteShoppingCart = " Delete from ShoppingCart where Id=" + shoppingCartId;

                                                        OleDbDataAdapter daDeleteShoppingCart = new OleDbDataAdapter(deleteShoppingCart, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                                                        DataTable dtDeleteShoppingCartTable = new DataTable();
                                                        daDeleteShoppingCart.Fill(dtDeleteShoppingCartTable);
                                                        lblMessage.Text = "Siparişiniz alınmıştır.";
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                lblMessage.Text = ex.Message;
                            }
                            finally
                            {
                                if (con.State == ConnectionState.Open)
                                    con.Close();
                            }
                        }


                    }

                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                finally
                {

                }
            }
            gvShoppingCartList.EditIndex = -1;
            BindGrid();

        }
    }
}