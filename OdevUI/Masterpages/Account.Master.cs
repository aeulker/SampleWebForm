using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.Masterpages
{
    public partial class Account : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }
        protected void btnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}