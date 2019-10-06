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
    public partial class Data_Kunjungan : System.Web.UI.Page
    {
        Ctl_Data_Kunjungan ctl = new Ctl_Data_Kunjungan();
        Ctl_Antrian ctl_a = new Ctl_Antrian();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                ListItem Umum = new ListItem("Umum", "Umum");
                ListItem BPJS = new ListItem("BPJS", "BPJS");
                DropDownList_Pembayaran.Items.Add(Umum);
                DropDownList_Pembayaran.Items.Add(BPJS);
            }

            MultiView2.SetActiveView(View1);
            Refresh();
        }
        

        public void Refresh()
        {
            btn_add_Kunjungan.Visible = true;
            GridView1.DataSource = ctl.Get_Kunjungan();
            GridView1.DataBind();
        }



        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }
        public void clear()
        {
            kode_Kunjungan.Text = "";
            Tanggal_Kunjungan.Text = "";

            Kode_Pasien.Text = "";
            DropDownList_Pembayaran.Text = "Umum";

        }

        protected void btn_add_KunjunganClick(object sender, EventArgs e)
        {


            DateTime date = System.DateTime.Today.Date;
            MultiView2.SetActiveView(View2);
            kode_Kunjungan.Enabled = false;
            clear();
            kode_Kunjungan.Text = ctl.BuatKode();
            Tanggal_Kunjungan.Text = DateTime.Today.ToString("yyyy-MM-dd");
            btn_add_Kunjungan.Visible = false;
            SAVE.Text = "SAVE";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (SAVE.Text == "SAVE")
            {
                int nomor_antrian = ctl.Buat_nomor_antrian(Dropdown_Poli.SelectedItem.Text);
                if (Dropdown_Poli.SelectedValue == "-1")
                {
                    showMessage("Poli belum dipilih");
                }
                if (ctl.Insert_Kunjungan(kode_Kunjungan.Text, Tanggal_Kunjungan.Text, Dropdown_Poli.SelectedItem.Value, Kode_Pasien.Text, Dropdown_kode_dokter.SelectedItem.Value, DropDownList_Pembayaran.SelectedItem.Value) && ctl_a.Insert_Antrian(nomor_antrian, kode_Kunjungan.Text, Dropdown_Poli.SelectedItem.Text))
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
                if (ctl.Update_Kunjungan(Session["kode_kunjungan"].ToString(), Tanggal_Kunjungan.Text, Dropdown_Poli.SelectedItem.Value, Kode_Pasien.Text, Dropdown_kode_dokter.SelectedItem.Text, DropDownList_Pembayaran.SelectedItem.Value))
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
            MultiView2.SetActiveView(View1);
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = new DataTable();

            if (e.CommandName == "Update")
            {
                dt = ctl.Get_Kunjungan(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_kunjungan"] = dt.Rows[0]["kode_kunjungan"].ToString();
                    kode_Kunjungan.Text = dt.Rows[0]["kode_kunjungan"].ToString();
                    kode_Kunjungan.Enabled = false;
                    Tanggal_Kunjungan.Text = dt.Rows[0]["tanggal_kunjungan"].ToString();
                    Dropdown_Poli.SelectedValue = dt.Rows[0]["kode_poli"].ToString();
                    Kode_Pasien.Text = dt.Rows[0]["kode_pasien"].ToString();
                    Dropdown_kode_dokter.SelectedValue = dt.Rows[0]["kode_dokter"].ToString();
                    DropDownList_Pembayaran.Text = dt.Rows[0]["metode_pembayaran"].ToString();

                    btn_add_Kunjungan.Visible = false;

                    // Button2.Text = "Update";

                }
                SAVE.Text = "UPDATE";
                MultiView2.SetActiveView(View2);

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
        public void Delete(string kode_kunjungan)
        {
            if (ctl.Delete_Kunjungan(kode_kunjungan))
            {

                Refresh();
            }
        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}