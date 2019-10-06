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
    public partial class Laporan_Pendapatan : System.Web.UI.Page
    {
        Ctl_Pembayaran ctl = new Ctl_Pembayaran();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem pilih = new ListItem("Pilih Metode ...", "-1");
                ListItem Umum = new ListItem("Umum", "Umum");
                ListItem BPJS = new ListItem("BPJS", "BPJS");
                ListItem semua = new ListItem("Semua ", "semua");
                dr_filter_pembayaran.Items.Add(pilih);
                dr_filter_pembayaran.Items.Add(Umum);
                dr_filter_pembayaran.Items.Add(BPJS);
                dr_filter_pembayaran.Items.Add(semua);
            }
            Refresh();
        }
        public void Refresh()
        {
            GridView1.DataSource = ctl.Get_Pembayaran();
            GridView1.DataBind();
        }

        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }

        protected void btn_pembayaran_Click(object sender, EventArgs e)
        {
            if (dr_filter_pembayaran.SelectedItem.Value == "-1")
            {
                showMessage("Belum memilih !!");
            }
            else if (dr_filter_pembayaran.SelectedItem.Value == "semua")
            {
                GridView1.DataSource = ctl.Get_Pembayaran();
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = ctl.Get_Laporan_Pendapatan(dr_filter_pembayaran.SelectedItem.Value);
                GridView1.DataBind();
            }
        }

        protected void btn_waktu_Click(object sender, EventArgs e)
        {
            if (tx_waktu_awal.Text == "" || tx_waktu_akhir.Text == "")
            {
                showMessage("Isi waktu terlebi dahulu !!");
            }
            else
            {
                GridView1.DataSource = ctl.Get_Laporan_Pendapatan_Waktu(tx_waktu_awal.Text, tx_waktu_akhir.Text);
                GridView1.DataBind();
            }
        }
    }
}