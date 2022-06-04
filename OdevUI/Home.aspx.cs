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
    public partial class Home : System.Web.UI.Page
    {
   

        protected void Page_Load(object sender, EventArgs e)
        {
            int categoryId = 0;
            if (Request.QueryString["CategoryId"] != null)
            {
                try
                {
                    categoryId = Convert.ToInt32(Request.QueryString["CategoryId"].ToString());
                }
                catch
                { }

            }
            if (Page.IsPostBack == false)
            {
                LoadProductCategories(categoryId);
            }
            LoadAddRotator();
        }

        private void LoadAddRotator()
        {
            string sql = "select AlternateText,ImageUrl,NavigateUrl from SliderImage";

            OleDbDataAdapter adsa = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dtAdds = new DataTable();
            adsa.Fill(dtAdds);
            if (dtAdds.Rows.Count>0)
            {
                adBanner.DataSource = dtAdds;
                adBanner.DataBind();
            }
            else
            {
                adBanner.AdvertisementFile = "~/Content/adv.xml";
            }
        }

        private void LoadProductCategories(int categoryId)
        {
            string sql = "Select * from Category";
            if (categoryId > 0)
            {
                sql += " where Id=" + categoryId;
            }
            OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rptCategoryProducts.DataSource = dt;
            rptCategoryProducts.DataBind();
        }

        protected void rptCategoryProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField categoryId = (HiddenField)e.Item.FindControl("hdnCategoryId");
            if (categoryId != null)
            {
                string sql = "SELECT  c.CategoryName" +
                    ", p.* " +
                    ", (p.UnitPrice * (1+ p.Discount/100) ) as OldUnitPrice"+
                    ", (select top 1 pi.ImageUrl from ProductImage pi where pi.ProductId = p.Id ) as ImageUrl" +
                    " from [Product] p inner join [Category] c on c.Id=p.CategoryId" +
                    " where c.Id=" + categoryId.Value.ToString();
                OleDbDataAdapter da = new OleDbDataAdapter(sql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    ListView categoryProducts = (ListView)e.Item.FindControl("lvCategoryProduts");
                    categoryProducts.DataSource = dt;
                    categoryProducts.DataBind();
                }
            }
        }
       

    }
}