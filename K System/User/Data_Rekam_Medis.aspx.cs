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
    public partial class Data_Rekam_Medis : System.Web.UI.Page
    {
        Ctl_Rekam_Medis ctl = new Ctl_Rekam_Medis();
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
            Session["akses"] = "Poli Dalam";
            Refresh();
        }


        public void Refresh()
        {
            btn_Add_Data.Visible = true;
            GridView1.DataSource = ctl.Get_Rekam_Medis_for_poli(Session["akses"].ToString());
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }



        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }
        public void clear()
        {
            Kode.Text = "";
            Kode_kunjungan.Text = "";
            Keluhan.Text = "";
            Diagnosa.Text = "";
            Tindakan.Text = "";
            Resep.Text = "";
        }

        protected void btn_add_data_click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            Kode.Enabled = false;
            clear();
            btn_Add_Data.Visible = false;
            Kode.Text = ctl.BuatKode();
            SAVE.Text = "SAVE";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (SAVE.Text == "SAVE")
            {
                if (ctl.Insert_Rekam_Medis(Kode.Text, Kode_kunjungan.Text, Keluhan.Text, Diagnosa.Text, Tindakan.Text, Resep.Text))
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
                if (ctl.Update_Rekam_Medis(Session["kode"].ToString(), Kode_kunjungan.Text, Keluhan.Text, Diagnosa.Text, Tindakan.Text, Resep.Text))
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


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = new DataTable();

            if (e.CommandName == "Update")
            {
                dt = ctl.Get_Rekam_Medis_for_poli(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode"] = dt.Rows[0]["kode"].ToString();
                    Kode.Text = dt.Rows[0]["kode"].ToString();
                    Kode.Enabled = false;
                    Kode_kunjungan.Text = dt.Rows[0]["kode_kunjungan"].ToString();
                    Keluhan.Text = dt.Rows[0]["keluhan"].ToString();
                    Diagnosa.Text = dt.Rows[0]["diagnosa"].ToString();
                    Tindakan.Text = dt.Rows[0]["tindakan"].ToString();
                    Resep.Text = dt.Rows[0]["resep"].ToString();

                    btn_Add_Data.Visible = false;

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
            if (ctl.Delete_pasien(id))
            {

                Refresh();
            }
        }

    }
}