using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.UserControls
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool isActivePage = false;

                if (Request.FilePath == "/Home.aspx")
                {
                    isActivePage = true;
                }

                menuFooter.Items.Add(new MenuItem() { Text = "Anasayfa", NavigateUrl = "/Home.aspx", Selected = isActivePage });

  


                if (Request.FilePath == "/About.aspx")
                {
                    isActivePage = true;
                }
                else
                {
                    isActivePage = false;
                }

                menuFooter.Items.Add(new MenuItem() { Text = "Hakkımızda", NavigateUrl = "/About.aspx", Selected = isActivePage });


                if (Request.FilePath == "/Contact.aspx")
                {
                    isActivePage = true;
                }
                else
                {
                    isActivePage = false;
                }
                menuFooter.Items.Add(new MenuItem() { Text = "İletişim", NavigateUrl = "/Contact.aspx", Selected = isActivePage });
            }
        }
    }
}