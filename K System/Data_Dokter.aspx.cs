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
    public partial class Data_Dokter : System.Web.UI.Page
    {
        Ctl_Dokter ctl = new Ctl_Dokter();
        protected void Page_Load(object sender, EventArgs e)
        {

            MultiView1.SetActiveView(View1);
            Refresh();
        }



        public void Refresh()
        {
            Button1.Visible = true;
            GridView1.DataSource = ctl.Get_Dokter();
            GridView1.DataBind();

        }
        public void clear()
        {
            Nama_Dokter.Text = "";
            Tx_Tarif_Dokter.Text = "";
        }
        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            Kode_Dokter.Enabled = false;
            Button1.Visible = false;
            Kode_Dokter.Text = ctl.BuatKode();
            clear();
            SAVE.Text = "SAVE";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (SAVE.Text == "SAVE")
            {
                if (ctl.Insert_Dokter(Kode_Dokter.Text, Nama_Dokter.Text, dr_poli.SelectedItem.Value, Tx_Tarif_Dokter.Text))
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
                if (ctl.Update_Dokter(Session["kode_dokter"].ToString(), Nama_Dokter.Text, dr_poli.SelectedItem.Value, Tx_Tarif_Dokter.Text))
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
                dt = ctl.Get_Dokter(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_dokter"] = dt.Rows[0]["kode_dokter"].ToString();
                    Kode_Dokter.Text = dt.Rows[0]["kode_dokter"].ToString();
                    Kode_Dokter.Enabled = false;
                    Nama_Dokter.Text = dt.Rows[0]["nama_dokter"].ToString();
                    dr_poli.SelectedItem.Value = dt.Rows[0]["kode_poli"].ToString();
                    Tx_Tarif_Dokter.Text = dt.Rows[0]["tarif"].ToString();
                    // Button2.Text = "Update";
                    Button1.Visible = false;

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
            if (ctl.Delete_Dokter(id))
            {

                Refresh();
            }
        }
    }
}