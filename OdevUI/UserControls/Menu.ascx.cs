
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.UserControls
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool isActivePage = false;
 
                if (Request.RawUrl== "/Home.aspx")
                {
                    isActivePage = true;
                }
                
                menuHeader.Items.Add(new MenuItem() { Text = "Anasayfa", NavigateUrl = "/Home.aspx" , Selected=isActivePage});


                MenuItem categoryMenu = new MenuItem();
                categoryMenu.Text = "Kategoriler";


                OleDbDataAdapter da = new OleDbDataAdapter("select * from Category", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        categoryMenu.ChildItems.Add(new MenuItem() { Text = dt.Rows[i]["CategoryName"].ToString(), NavigateUrl = "/Home.aspx?CategoryId=" + dt.Rows[i]["Id"].ToString() ,Selected=isActivePage});
                    }

                }
                menuHeader.Items.Add(categoryMenu);

                

                if (Request.RawUrl == "/About.aspx")
                {
                    isActivePage = true;
                }
                else
                {
                    isActivePage = false;
                }

                menuHeader.Items.Add(new MenuItem() { Text = "Hakkımızda", NavigateUrl = "/About.aspx", Selected = isActivePage });


                if (Request.RawUrl == "/Contact.aspx")
                {
                    isActivePage = true;
                }
                else
                {
                    isActivePage = false;
                }
                menuHeader.Items.Add(new MenuItem() { Text = "İletişim", NavigateUrl = "/Contact.aspx", Selected = isActivePage });
            }


        }
    }
}