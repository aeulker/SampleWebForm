using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.Product
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                FillCategories();
                BindProductGrid();
            }
        }

        private void FillCategories()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [Category] ", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlProductCategory.DataSource = dt;
                ddlProductCategory.DataTextField = "CategoryName";
                ddlProductCategory.DataValueField = "Id";
                ddlProductCategory.DataBind();
            }
        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == "")
            {
                lblError.Text = "Lütfen Ürün Adını Giriniz !";
                return;
            }
            try
            {

                string sql = "select * from [Product] where  ProductName='" + txtProductName.Text + "' and CategoryId=" + Convert.ToInt32(ddlProductCategory.SelectedValue);

                OleDbDataAdapter daCheck = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dtCheck = new DataTable();
                daCheck.Fill(dtCheck);

                if (dtCheck.Rows.Count > 0)
                {
                    lblError.Text = "Aynı kategoride aynı isimle ürün bulunmaktadır";
                }
                else
                {

                    int categoryId = Convert.ToInt32(ddlProductCategory.SelectedValue);
                    decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    int productId = 0;

                    string insertSql = "insert into [Product]([ProductName],[CategoryId],[UnitPrice],[Discount],[AgeRange],[Description],[Campaign])  " +
                                        "values ('" + txtProductName.Text + "', " +
                                                      categoryId + ", " +
                                                      unitPrice + ", " +
                                                      discount + ", " +
                                                "'" + txtAgeRange.Text + "', " +
                                                "'" + txtDescription.Text + "', " +
                                                "'" + txtCampaign.Text + "' ) ";
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
                                    productId = (int)cmdLastRecord.ExecuteScalar();
                                }

                                if (con.State == System.Data.ConnectionState.Open)
                                    con.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            lblError.Text = ex.Message;
                        }
                        finally
                        {
                            if (con.State == ConnectionState.Open)
                                con.Close();
                        }
                    }


                    if (productId > 0)
                    {
                        hdnActiveProductId.Value = productId.ToString();
                        btnSaveProduct.Visible = false;
                        btnUpdateProduct.Visible = true;
                        lblImagesInfo.Visible = false;
                        tblImages.Visible = true;
                        BindProductImagesGrid();
                    }

                    BindProductGrid();

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == "")
            {
                lblError.Text = "Lütfen Ürün Adını Giriniz !";
                return;
            }
            if (hdnActiveProductId.Value == "")
            {
                ClearForm();
                return;
            }
            int productId = Convert.ToInt32(hdnActiveProductId.Value);

            string sql = "select * from [Product] where ID<>" + productId + " and ProductName='" + txtProductName.Text + "' and CategoryId=" + Convert.ToInt32(ddlProductCategory.SelectedValue);

            OleDbDataAdapter daCheck = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dtCheck = new DataTable();
            daCheck.Fill(dtCheck);

            if (dtCheck.Rows.Count > 0)
            {

                lblError.Text = "Girilen kullanıcı adı veya email ile kayıtlı kullanılı bulunmaktadır";
            }
            else
            {

                int categoryId = Convert.ToInt32(ddlProductCategory.SelectedValue);
                decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                decimal discount = Convert.ToDecimal(txtDiscount.Text);

                string updateSql = "update [Product]" +
                                    "set [ProductName] ='" + txtProductName.Text + "'" +
                                    " ,  [CategoryId] = " + categoryId +
                                    " ,  [UnitPrice] = " + unitPrice +
                                    " ,  [Discount] = " + discount +
                                    " ,  [AgeRange] = '" + txtAgeRange.Text + "'" +
                                    " ,  [Description] = '" + txtDescription.Text + "'" +
                                    " ,  [Campaign] = '" + txtCampaign.Text + "'" +
                                     " where Id=" + productId + ""; ;

                OleDbDataAdapter da = new OleDbDataAdapter(updateSql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                BindProductGrid();

                lblImagesInfo.Visible = false;
                tblImages.Visible = true;
                BindProductImagesGrid();
            }
        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            hdnActiveProductId.Value = string.Empty;
            lblError.Text = string.Empty;
            txtProductName.Text = string.Empty;
            ddlProductCategory.SelectedIndex = -1;
            txtUnitPrice.Text = "0";
            txtDiscount.Text = "0";
            txtAgeRange.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtCampaign.Text = string.Empty;

            tblImages.Visible = false;
            lblImagesInfo.Visible = true;
            lblImagesMessage.Text = string.Empty;
            lblImagesMessage.Visible = false;
            tblImages.Visible = false;
            gvProductImageList.DataSource = null;
            gvProductImageList.DataBind();

            gvProductList.SelectedIndex= -1;
        }

        private void BindProductGrid()
        {
            string sql = "Select c.CategoryName, p.* from [Product] p inner join [Category] c on p.CategoryId=c.Id ";

            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gvProductList.DataSource = dt;
                gvProductList.DataBind();
            }
        }

        protected void gvProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductList.PageIndex = e.NewPageIndex;
            BindProductGrid();
        }

        protected void gvProductList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(gvProductList.DataKeys[e.RowIndex].Values["Id"].ToString());

            try
            {
                string sql = " delete from [Product]  where Id=" + productId + "";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

            gvProductList.EditIndex = -1;
        }

        protected void gvProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var productId = Convert.ToInt32(gvProductList.SelectedRow.Cells[0].Text);
            if (productId > 0)
            {
                hdnActiveProductId.Value = productId.ToString();
            }

            string sql = "Select  * from [Product]  where Id=" + productId;

            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
                ddlProductCategory.SelectedValue = dt.Rows[0]["CategoryId"].ToString();
                txtUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                txtDiscount.Text = dt.Rows[0]["Discount"].ToString();
                txtAgeRange.Text = dt.Rows[0]["AgeRange"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                txtCampaign.Text = dt.Rows[0]["Campaign"].ToString();

        

                btnSaveProduct.Visible = false;
                btnUpdateProduct.Visible = true;

                lblImagesInfo.Visible = false;
                tblImages.Visible = true;
                BindProductImagesGrid();
            }
        }

        #region Product Image Works

        private void BindProductImagesGrid()
        {
            if (hdnActiveProductId.Value == "")
            {
                ClearForm();
                return;
            }
            string sql = "select * from [ProductImage] where ProductId=" + hdnActiveProductId.Value.ToString();

            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvProductImageList.DataSource = dt;
                gvProductImageList.DataBind();
            }
            else
            {
                DataTable dtEmpty = new DataTable();
                dtEmpty.Columns.Add("Id", typeof(int));
                dtEmpty.Columns.Add("ImageUrl", typeof(string));
                DataRow datatRow = dtEmpty.NewRow();
                dtEmpty.Rows.Add(datatRow);
                gvProductImageList.DataSource = dtEmpty;
                gvProductImageList.DataBind();
                gvProductImageList.Rows[0].Visible = false;
            }
        }

        protected void gvProductImageList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductImageList.EditIndex = e.NewEditIndex;

            BindProductImagesGrid();
        }

        protected void gvProductImageList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductImageList.EditIndex = -1;

            BindProductImagesGrid();
        }

        protected void gvProductImageList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductImageList.PageIndex = e.NewPageIndex;

            BindProductImagesGrid();
        }

        protected void gvProductImageList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productImageId = Convert.ToInt32(gvProductImageList.DataKeys[e.RowIndex].Values["Id"].ToString());

            try
            {
                string sql = " delete from [ProductImage]  where Id=" + productImageId + "";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lblImagesMessage.Text = ex.Message;
            }
            gvProductImageList.EditIndex = -1;
            BindProductImagesGrid();
        }

        protected void gvProductImageList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew") && hdnActiveProductId.Value != "")
            {

                FileUpload fuNProductImageUrl = (FileUpload)gvProductImageList.FooterRow.FindControl("fuNProductImageUrl");

                string imageGuid = Guid.NewGuid().ToString();
                string imageUrl = Path.Combine("/Content/Images/", imageGuid + "_" + fuNProductImageUrl.FileName);

                try
                {
                    string sql = " insert into [ProductImage]([ProductId],[ImageUrl])  " +
                                 " values (" + hdnActiveProductId.Value.ToString() + " , " +
                                          "'" + imageUrl + "'" +
                                          ")";
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    lblImagesMessage.Text = ex.Message;
                }
                finally
                {
                    string saveUrl = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/"), imageGuid + "_" + fuNProductImageUrl.FileName);
                    fuNProductImageUrl.SaveAs(saveUrl);
                }


                gvProductImageList.EditIndex = -1;
                BindProductImagesGrid();
            }
        }

        protected void gvProductImageList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (hdnActiveProductId.Value == "")
            {
                return;
            }
            int productImageId = Convert.ToInt32(gvProductImageList.DataKeys[e.RowIndex].Values["Id"].ToString());
            FileUpload fuProductImageUrl = (FileUpload)gvProductImageList.Rows[e.RowIndex].FindControl("fuProductImageUrl");

            string imageGuid = Guid.NewGuid().ToString();
            string imageUrl = Path.Combine("/Content/Images/", imageGuid + "_" + fuProductImageUrl.FileName);

            try
            {
                string sql = " update [ProductImage]" +
                             " set    [ProductId] = " + hdnActiveProductId.Value.ToString() +
                             "       ,[ImageUrl] = '" + imageUrl + "'" +
                             " where  Id=" + productImageId + "";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lblImagesMessage.Text = ex.Message;
            }
            finally
            {
                string saveUrl = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/"), imageGuid + "_" + fuProductImageUrl.FileName);

                fuProductImageUrl.SaveAs(saveUrl);
            }
            gvProductImageList.EditIndex = -1;
            BindProductImagesGrid();

        }

        #endregion


    }
}