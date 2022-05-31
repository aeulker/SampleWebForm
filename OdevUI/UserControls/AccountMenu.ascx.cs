using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdevUI.UserControls
{
    public partial class AccountMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool isActivePage = false;
                string requestPath = Request.Url.AbsolutePath;
                if (requestPath == "/User/UserInfo.aspx" || requestPath == "/User/UserEdit.aspx")
                {
                    isActivePage = true;
                }

                menuAccount.Items.Add(new MenuItem() { Text = "Üyelik Bilgilerim", NavigateUrl = "/User/UserInfo.aspx", Selected = isActivePage });


                if (requestPath == "/User/UserOrders.aspx")
                {
                    isActivePage = true;
                }
                else
                {
                    isActivePage = false;
                }
                menuAccount.Items.Add(new MenuItem() { Text = "Siparişlerim", NavigateUrl = "/User/UserOrders.aspx", Selected = isActivePage });

       
                if (Session["IsAdmin"] != null && Session["IsAdmin"].ToString() == "1")
                {
                    if (requestPath == "/Product/ProductList.aspx")
                    {
                        isActivePage = true;
                    }
                    else
                    {
                        isActivePage = false;
                    }

                    menuAccount.Items.Add(new MenuItem() { Text = "Ürün İşlemleri", NavigateUrl = "/Product/ProductList.aspx", Selected = isActivePage });

                    if (requestPath == "/Category/CategoryList.aspx")
                    {
                        isActivePage = true;
                    }
                    else
                    {
                        isActivePage = false;
                    }

                    menuAccount.Items.Add(new MenuItem() { Text = "Ürün Kategori İşlemleri", NavigateUrl = "/Category/CategoryList.aspx", Selected = isActivePage });

                    if (requestPath == "/Order/OrderList.aspx")
                    {
                        isActivePage = true;
                    }
                    else
                    {
                        isActivePage = false;
                    }

                    menuAccount.Items.Add(new MenuItem() { Text = "Sipariş Takibi", NavigateUrl = "/Order/OrderList.aspx", Selected = isActivePage });

                    if (requestPath == "/User/UserList.aspx")
                    {
                        isActivePage = true;
                    }
                    else
                    {
                        isActivePage = false;
                    }

                    menuAccount.Items.Add(new MenuItem() { Text = "Kullanıcı İşlemleri", NavigateUrl = "/User/UserList.aspx", Selected = isActivePage });

                    if (requestPath == "/Messages.aspx")
                    {
                        isActivePage = true;
                    }
                    else
                    {
                        isActivePage = false;
                    }

                    menuAccount.Items.Add(new MenuItem() { Text = "Mesajlar", NavigateUrl = "/Messages.aspx", Selected = isActivePage });

                    if (requestPath == "/SliderImages.aspx")
                    {
                        isActivePage = true;
                    }
                    else
                    {
                        isActivePage = false;
                    }

                    menuAccount.Items.Add(new MenuItem() { Text = "Slider Resimleri", NavigateUrl = "/SliderImages.aspx", Selected = isActivePage });
                }



                //MenuItem categoryMenu = new MenuItem();
                //categoryMenu.Text = "Kategoriler";


                //OleDbDataAdapter da = new OleDbDataAdapter("select * from Category", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                //DataTable dt = new DataTable();
                //da.Fill(dt);

                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        categoryMenu.ChildItems.Add(new MenuItem() { Text = dt.Rows[i]["CategoryName"].ToString(), NavigateUrl = "/Home.aspx?CategoryId=" + dt.Rows[i]["Id"].ToString(), Selected = isActivePage });
                //    }

                //}
                //menuHeader.Items.Add(categoryMenu);



                //if (Request.RawUrl == "/About.aspx")
                //{
                //    isActivePage = true;
                //}
                //else
                //{
                //    isActivePage = false;
                //}

                //menuHeader.Items.Add(new MenuItem() { Text = "Hakkımızda", NavigateUrl = "/About.aspx", Selected = isActivePage });


                //if (Request.RawUrl == "/Contact.aspx")
                //{
                //    isActivePage = true;
                //}
                //else
                //{
                //    isActivePage = false;
                //}
                //menuHeader.Items.Add(new MenuItem() { Text = "İletişim", NavigateUrl = "/Contact.aspx", Selected = isActivePage });
            }
        }
    }
}