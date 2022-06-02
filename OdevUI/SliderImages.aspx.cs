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

namespace OdevUI
{
    public partial class SliderResimleri : System.Web.UI.Page
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
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [SliderImage] ", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvSliderImageList.DataSource = dt;
                gvSliderImageList.DataBind();
            }
            else
            {
                DataTable dtEmpty = new DataTable();
                dtEmpty.Columns.Add("Id", typeof(int));
                dtEmpty.Columns.Add("ImageUrl", typeof(string));
                dtEmpty.Columns.Add("NavigateUrl", typeof(string));
                dtEmpty.Columns.Add("AlternateText", typeof(string));
                DataRow datatRow = dtEmpty.NewRow();
                dtEmpty.Rows.Add(datatRow);
                gvSliderImageList.DataSource = dtEmpty;
                gvSliderImageList.DataBind();
                gvSliderImageList.Rows[0].Visible = false;
            }
        }

        protected void gvSliderImageList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSliderImageList.EditIndex = e.NewEditIndex;

            BindGrid();
        }

        protected void gvSliderImageList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSliderImageList.EditIndex = -1;

            BindGrid();
        }

        protected void gvSliderImageList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSliderImageList.PageIndex = e.NewPageIndex;

            BindGrid();
        }

        protected void gvSliderImageList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int sliderImageId = Convert.ToInt32(gvSliderImageList.DataKeys[e.RowIndex].Values["Id"].ToString());

            try
            {
                string sql = " delete from [SliderImage]  where Id=" + sliderImageId + "";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            gvSliderImageList.EditIndex = -1;
            BindGrid();
        }

        protected void gvSliderImageList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                FileUpload fuNSliderImageUrl = (FileUpload)gvSliderImageList.FooterRow.FindControl("fuNSliderImageUrl");

                TextBox txtNNavigateUrl = (TextBox)gvSliderImageList.FooterRow.FindControl("txtNNavigateUrl");
                TextBox txtNAlternateText = (TextBox)gvSliderImageList.FooterRow.FindControl("txtNAlternateText");

                string imageGuid = Guid.NewGuid().ToString();
                string imageUrl = Path.Combine("/Content/Images/", imageGuid + "_" + fuNSliderImageUrl.FileName);

                try
                {
                    string sql = " insert into [SliderImage]([ImageUrl],[NavigateUrl],[AlternateText])  " +
                                 " values ('" + imageUrl + "','" + txtNNavigateUrl.Text + "','" + txtNAlternateText.Text + "')";

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
                    string saveUrl = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/"), imageGuid + "_" + fuNSliderImageUrl.FileName);
                    fuNSliderImageUrl.SaveAs(saveUrl);
                }


                gvSliderImageList.EditIndex = -1;
                BindGrid();
            }
        }

        protected void gvSliderImageList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int sliderImageId = Convert.ToInt32(gvSliderImageList.DataKeys[e.RowIndex].Values["Id"].ToString());
            string imageGuid = Guid.NewGuid().ToString();
            string sliderImageUrl = string.Empty;
            FileUpload fuSliderImageUrl = (FileUpload)gvSliderImageList.Rows[e.RowIndex].FindControl("fuSliderImageUrl");
            Label lblSliderImageUrl = (Label)gvSliderImageList.Rows[e.RowIndex].FindControl("lblSliderImageUrl");

            if (fuSliderImageUrl.FileName == string.Empty)
            {
                sliderImageUrl = lblSliderImageUrl.Text;
            }
            else
            {
                sliderImageUrl = Path.Combine("/Content/Images/", imageGuid + "_" + fuSliderImageUrl.FileName);
            }

            TextBox txtNavigateUrl = (TextBox)gvSliderImageList.Rows[e.RowIndex].FindControl("txtNavigateUrl");
            TextBox txtAlternateText = (TextBox)gvSliderImageList.Rows[e.RowIndex].FindControl("txtAlternateText");


            try
            {
                string sql = " update [SliderImage]" +
                             " set   [ImageUrl] = '" + sliderImageUrl + "'" +
                             "     , [NavigateUrl] = '" + txtNavigateUrl.Text + "'" +
                             "     , [AlternateText] = '" + txtAlternateText.Text + "'" +

                             " where  Id=" + sliderImageId + "";

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
                if (fuSliderImageUrl.FileName != string.Empty)
                {
                    string saveUrl = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/"), imageGuid + "_" + fuSliderImageUrl.FileName);

                    fuSliderImageUrl.SaveAs(saveUrl);
                }
            }
            gvSliderImageList.EditIndex = -1;
            BindGrid();

        }
    }
}