using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.SessionState;

namespace OdevUI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            OleDbDataAdapter daCheck = new OleDbDataAdapter("select * from [User] where IsAdmin=true", WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            DataTable dtCheck = new DataTable();
            daCheck.Fill(dtCheck);

            if (dtCheck.Rows.Count == 0)
            {
                string insertSql = "insert into [User]([UserName],[Password],[FirstName],[LastName],[Gender],[Email],[PhoneNumber],[Address],[IsAdmin]) "
                                            + " values ('admin','admin','Turan','Beyin','Erkek','admin@email.com','08502222222','Adres',true)";
                OleDbDataAdapter daInsert = new OleDbDataAdapter(insertSql, WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                DataTable dtInsert = new DataTable();
                daInsert.Fill(dtInsert);
            }

        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["init"] = 0;
        }
    }
}