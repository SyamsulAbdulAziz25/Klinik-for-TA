using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinesLogic;
namespace K_System
{
    public partial class Data_Poli : System.Web.UI.Page
    {
        Ctl_poli ctl = new Ctl_poli();
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
            Button1.Visible = true;

            Refresh();
        }
        public void Refresh()
        {
            GridView1.DataSource = ctl.Get_poli();
            GridView1.DataBind();

        }
        public void clear()
        {
            Kode_poli.Text = "";
            Nama_poli.Text = "";
            Keterangan.Text = "";
        }
        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            Kode_poli.Enabled = false;
            clear();
            Kode_poli.Text = ctl.BuatKode();
            SAVE.Text = "SAVE";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (SAVE.Text == "SAVE")
            {
                if (ctl.Insert_poli(Kode_poli.Text, Nama_poli.Text, Keterangan.Text))
                {
                    showMessage("Insert Succes !!");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    showMessage("Insert Filed !!");
                }
            }
            else
            {
                if (ctl.Update_poli(Session["kode_poli"].ToString(), Nama_poli.Text, Keterangan.Text))
                {
                    showMessage("Update Succes !!");
                }
                else
                {
                    showMessage("Update Filed !!");
                }
            } Refresh();

        }

        protected void Cancle_Click(object sender, EventArgs e)
        {
            clear();


            MultiView1.SetActiveView(View1);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = new DataTable();

            if (e.CommandName == "Update")
            {
                dt = ctl.Get_poli(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_poli"] = dt.Rows[0]["kode_poli"].ToString();
                    Kode_poli.Text = dt.Rows[0]["kode_poli"].ToString();
                    Kode_poli.Enabled = false;
                    Nama_poli.Text = dt.Rows[0]["nama_poli"].ToString();
                    Keterangan.Text = dt.Rows[0]["keterangan"].ToString();

                    Button1.Visible = false;
                    // Button2.Text = "Update";

                }
                SAVE.Text = "UPDATE";
                MultiView1.SetActiveView(View2);

            }
            else
            {
                string tanya = Request.Form["c_tanya"];

                if (tanya == "Yes")
                {
                    Delete(e.CommandArgument.ToString());
                    Refresh();

                }

            }
        }
        public void Delete(string id)
        {
            if (ctl.Delete_poli(id))
            {

                Refresh();
            }
        }
    }
}