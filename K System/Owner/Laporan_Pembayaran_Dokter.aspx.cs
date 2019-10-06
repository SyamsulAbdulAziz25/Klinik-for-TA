using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinesLogic;

namespace K_System.Owner
{
    public partial class Laporan_Pembayaran_Dokter : System.Web.UI.Page
    {
        Ctl_Dokter ctl = new Ctl_Dokter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem pilih = new ListItem("--Pilih Tindakan--", "-1");
                ListItem ya = new ListItem("Ya", "Ya");
                ListItem tidak = new ListItem("Tidak", "Tidak");
                dr_tindakan.Items.Add(pilih);
                dr_tindakan.Items.Add(ya);
                dr_tindakan.Items.Add(tidak);
                DropDownList1.Items.Add(pilih);
                DropDownList1.Items.Add(ya);
                DropDownList1.Items.Add(tidak);
            }
            Refresh();
        }

        public void Refresh()
        {
            MultiView1.SetActiveView(View1);
            GridView1.DataSource = ctl.Get_Laporan_Dokter();
            GridView1.DataBind();
        }

        protected void btn_tindakan_Click(object sender, EventArgs e)
        {
            if (dr_tindakan.SelectedItem.Value == "-1")
            {
                showMessage("Pilih salah satu Item ..!");
            }
            else
            {
                MultiView1.SetActiveView(View1);
                GridView1.DataSource = ctl.Get_Laporan_Dokter_Tindakan(dr_tindakan.SelectedItem.Value);
                GridView1.DataBind();
            }
        }

        protected void btn_waktu_Click(object sender, EventArgs e)
        {
            if (tx_waktu_awal.Text == "" || tx_waktu_akhir.Text == "")
            {
                showMessage("Isi kedua kolom Terlebih dahulu ..!");

            }
            else
            {
                MultiView1.SetActiveView(View1);
                GridView1.DataSource = ctl.Get_Laporan_Dokter_Tanggal(tx_waktu_awal.Text, tx_waktu_akhir.Text);
                GridView1.DataBind();

            }
        }
        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }

        protected void btn_tampil_dokter_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            GridView2.DataSource = ctl.Get_Laporan_Dokter_ByDokter();
            GridView2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Value == "-1")
            {
                showMessage("Pilih salah satu Item ..!");
            }
            else
            {
                MultiView1.SetActiveView(View1);
                GridView1.DataSource = ctl.Get_Laporan_Dokter_Tindakan(dr_tindakan.SelectedItem.Value);
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (tx_waktu_awal2.Text == "" || tx_waktu_akhir2.Text == "")
            {
                showMessage("Isi kedua kolom Terlebih dahulu ..!");

            }
            else
            {
                MultiView1.SetActiveView(View1);
                GridView1.DataSource = ctl.Get_Laporan_Dokter_Tanggal(tx_waktu_awal.Text, tx_waktu_akhir.Text);
                GridView1.DataBind();

            }
        }
    }
}