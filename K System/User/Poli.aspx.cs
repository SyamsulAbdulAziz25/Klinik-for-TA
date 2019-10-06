using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinesLogic;

namespace K_System.User
{
    public partial class Poli : System.Web.UI.Page
    {
        Ctl_Antrian ctl = new Ctl_Antrian();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nama"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else if (Session["akses"].ToString() == "admin")
            {
                Response.Redirect("../HomeAdmin.aspx");
            }
            else if (Session["akses"].ToString() == "owner")
            {
                Response.Redirect("../Owner/HomeOwner.aspx");
            }

            Refresh();

        }

        public void Refresh()
        {

            GridView1.DataSource = ctl.Get_Antrian(Session["akses"].ToString());
            GridView1.DataBind();
        }



        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }
    }
}