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

namespace OdevUI.Category
{
    public partial class CategoryList : System.Web.UI.Page
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
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [Category] ", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                gvCategoryList.DataSource = dt;
                gvCategoryList.DataBind();
            }
            else
            {
                DataTable dtEmpty = new DataTable();
                dtEmpty.Columns.Add("Id", typeof(int));
                dtEmpty.Columns.Add("CategoryName", typeof(string));
                dtEmpty.Columns.Add("ImageUrl", typeof(string));
                DataRow datatRow = dtEmpty.NewRow();
                dtEmpty.Rows.Add(datatRow);
                gvCategoryList.DataSource = dtEmpty;
                gvCategoryList.DataBind();
                gvCategoryList.Rows[0].Visible = false;
            } 
        }

        protected void gvCategoryList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategoryList.EditIndex = e.NewEditIndex;

            BindGrid();
        }

        protected void gvCategoryList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategoryList.EditIndex = -1;

            BindGrid();
        }

        protected void gvCategoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCategoryList.PageIndex = e.NewPageIndex;

            BindGrid();
        }

        protected void gvCategoryList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvCategoryList.DataKeys[e.RowIndex].Values["Id"].ToString());

            try
            {
                string sql = " delete from [Category]  where Id=" + userId + "";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            gvCategoryList.EditIndex = -1;
            BindGrid();
        }

        protected void gvCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtNCategoryName = (TextBox)gvCategoryList.FooterRow.FindControl("txtNCategoryName");
                FileUpload fuNCategoryImageUrl = (FileUpload)gvCategoryList.FooterRow.FindControl("fuNCategoryImageUrl");

                string imageGuid = Guid.NewGuid().ToString();
                string imageUrl = Path.Combine("/Content/Images/", imageGuid + "_" + fuNCategoryImageUrl.FileName); 
                
                try
                {
                    string sql = " insert into [Category]([CategoryName],[ImageUrl])  " +
                                 " values ('" + txtNCategoryName.Text + "' , " +
                                          "'" + imageUrl + "'" +
                                          ")";
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                finally
                {
                    string saveUrl = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/"), imageGuid + "_" + fuNCategoryImageUrl.FileName);
                    fuNCategoryImageUrl.SaveAs(saveUrl);
                }


                gvCategoryList.EditIndex = -1;
                BindGrid();
            }
        }

        protected void gvCategoryList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int categoryId = Convert.ToInt32(gvCategoryList.DataKeys[e.RowIndex].Values["Id"].ToString());
            TextBox txtCategoryName = (TextBox)gvCategoryList.Rows[e.RowIndex].FindControl("txtCategoryName");
            FileUpload fuCategoryImageUrl = (FileUpload)gvCategoryList.Rows[e.RowIndex].FindControl("fuCategoryImageUrl");

            string imageGuid = Guid.NewGuid().ToString();
            string imageUrl = Path.Combine("/Content/Images/", imageGuid + "_" + fuCategoryImageUrl.FileName);

            try
            {
                string sql = " update [Category]" +
                             " set    [CategoryName] = '" + txtCategoryName.Text + "'" +
                             "       ,[ImageUrl] = '" + imageUrl + "'" +
                             " where  Id=" + categoryId + "";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                string saveUrl = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/"), imageGuid + "_" + fuCategoryImageUrl.FileName);

                fuCategoryImageUrl.SaveAs(saveUrl);
            }
            gvCategoryList.EditIndex = -1;
            BindGrid();

        }

    }
}