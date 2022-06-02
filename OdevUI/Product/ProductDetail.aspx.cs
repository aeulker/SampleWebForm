using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.Product
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductId"] != null)
            {
                try
                {
                    hdnProductId.Value = Request.QueryString["ProductId"].ToString();
                    LoadProductInfo();
                }
                catch
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        private void LoadProductInfo()
        {
            if (hdnProductId.Value != null)
            {
                int productId = Convert.ToInt32(hdnProductId.Value);

                string sql = "SELECT  c.CategoryName" +
                            ", p.* " +
                            ", (p.UnitPrice * (1+ p.Discount/100) ) as OldUnitPrice" +
                            //", (select top 1 pi.ImageUrl from ProductImage pi where pi.ProductId = p.Id ) as ImageUrl" +
                            " from [Product] p inner join [Category] c on c.Id=p.CategoryId" +
                            " where p.Id=" + productId.ToString();

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lblProductName.Text = dt.Rows[0]["ProductName"].ToString();
                    lblProductDescription.Text = dt.Rows[0]["Description"].ToString();
                    lblAgeRange.Text = dt.Rows[0]["AgeRange"].ToString();
                    lblCategoryName.Text = dt.Rows[0]["CategoryName"].ToString();
                    lblUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                    lblDiscount.Text = dt.Rows[0]["Discount"].ToString();
                    try
                    {
                        decimal unitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"].ToString());
                        decimal discount = Convert.ToDecimal(dt.Rows[0]["Discount"].ToString());
                        decimal oldUnitPrice = unitPrice * (1 + (decimal.Divide(discount, 100)));
                        lblOldUnitPrice.Text = oldUnitPrice.ToString();
                    }
                    catch { }

                    string productPictureSql = "Select * from ProductImage where ProductId = " + productId.ToString();

                    OleDbDataAdapter daProductImages = new OleDbDataAdapter(productPictureSql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dtProductImageTable = new DataTable();
                    daProductImages.Fill(dtProductImageTable);

                    //ListView categoryProducts = (ListView)e.Item.FindControl("lvCategoryProduts");

                    if (dtProductImageTable.Rows.Count > 0)
                    {
                        imgProductShowCasePicture.ImageUrl = "~" + dtProductImageTable.Rows[0]["ImageUrl"].ToString();
                        lstProductPictures.DataSource = dtProductImageTable;
                        lstProductPictures.DataBind();
                    }

                }
            }
        }

        protected void btnAddToCart_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";
            int shoppingCartId = 0;
            if (hdnProductId.Value != null && Session != null && txtProductCount.Text != "")
            {
                int productId = Convert.ToInt32(hdnProductId.Value);
                int quantity = int.Parse(txtProductCount.Text);
                string sessionId = Session.SessionID;


                string checkSql = "Select * from ShoppingCart where SessionId='" + sessionId + "' and ProductId=" + productId;

                OleDbDataAdapter daCheckShoppingCart = new OleDbDataAdapter(checkSql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dtCheckShoppingCartTable = new DataTable();
                daCheckShoppingCart.Fill(dtCheckShoppingCartTable);

                if (dtCheckShoppingCartTable.Rows.Count > 0)
                {
                    shoppingCartId = Convert.ToInt32(dtCheckShoppingCartTable.Rows[0]["Id"].ToString());
                    string updateSql = " update ShoppingCart set"
                                     + " Quantity = " + txtProductCount.Text
                                     + " where Id = " + shoppingCartId;

                    OleDbDataAdapter daUpdateShoppingCart = new OleDbDataAdapter(updateSql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dtUpdateShoppingCartTable = new DataTable();
                    daUpdateShoppingCart.Fill(dtUpdateShoppingCartTable);
                    lblMessage.Text = "Sepet güncellendi!";
                }
                else
                {
                    string insertSql = "insert into ShoppingCart (SessionId,ProductId,Quantity) values('" + sessionId + "'," + productId + "," + quantity + ")";
                    string lastRecordIdSql = "select @@Identity ";

                    using (OleDbConnection con = new OleDbConnection(WebConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                    {
                        try
                        {
                            using (OleDbCommand cmd = new OleDbCommand(insertSql, con))
                            {
                                if (con.State == ConnectionState.Closed)
                                    con.Open();

                                using (OleDbCommand cmdLastRecord = new OleDbCommand(lastRecordIdSql, con))
                                {
                                    cmd.ExecuteNonQuery();
                                    shoppingCartId = (int)cmdLastRecord.ExecuteScalar();
                                }

                                if (con.State == System.Data.ConnectionState.Open)
                                    con.Close();
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

                    if (shoppingCartId > 0)
                    {
                        lblMessage.Text = "Ürün sepete eklendi !";
                    }
                }

           
            }
        }
    }
}