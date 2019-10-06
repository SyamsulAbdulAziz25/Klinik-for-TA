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
    public partial class Data_Pembayaran : System.Web.UI.Page
    {
        Ctl_Pembayaran ctl = new Ctl_Pembayaran();
        //untuk number format
        // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CultureToUse"]);
        public int total;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                MultiView2.SetActiveView(View1);
                Refresh();

            }

        }

        public void Refresh()
        {
            btn_add_Pembayaran.Visible = true;
            GridView1.DataSource = ctl.Get_Pembayaran();
            GridView1.DataBind();
        }



        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }
        public void clear()
        {
            tx_kode_kunjungan.Text = "";
            tx_Obat.Text = "";
            Tx_Tindakan.Text = "";
            Tx_Biaya_Tindakan.Text = "";
        }
        protected void btn_add_PembayaranClick(object sender, EventArgs e)
        {


            DateTime date = System.DateTime.Today.Date;
            MultiView2.SetActiveView(View2);
            tx_kode_pembayaran.Text = ctl.BuatKode();
            tx_kode_pembayaran.Enabled = false;
            tx_kode_kunjungan.Enabled = true;
            clear();
            Tx_Waktu.Text = DateTime.Today.ToString("yyyy-MM-dd");
            btn_add_Pembayaran.Visible = false;
            SAVE.Text = "SAVE";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {


            if (SAVE.Text == "SAVE")
            {

                Label_Tampil_Total_form_input.Text = ((int.Parse(Dr_tarif.SelectedItem.Value) + int.Parse(tx_Obat.Text) + int.Parse(Tx_Biaya_Tindakan.Text))).ToString("###,###,##0.00");
                MultiView2.SetActiveView(ViewInput);
                btn_add_Pembayaran.Visible = false;
                Ctl_Data_Kunjungan ctlk = new Ctl_Data_Kunjungan();
                DataTable dt = new DataTable();
                dt = ctlk.Get_Kunjungan(tx_kode_kunjungan.Text);
                Dr_metode.Text = dt.Rows[0]["metode_pembayaran"].ToString();

            }
            //else
            //{
            //    if (ctl.Update_Pembayaran(Session["kode_pembayaran"].ToString(), tx_kode_kunjungan.Text, Tx_Waktu.Text, int.Parse(Dr_tarif.SelectedItem.Value), int.Parse(tx_Obat.Text), Tx_Tindakan.Text, int.Parse(Tx_Biaya_Tindakan.Text)))
            //    {
            //        showMessage("Update Succes !!");
            //    }
            //    else
            //    {
            //        showMessage("Update Filed !!");
            //    }
            //}


            // MultiView2.SetActiveView(View3);

        }

        protected void Cancle_Click(object sender, EventArgs e)
        {
            clear();
            Refresh();
            MultiView2.SetActiveView(View1);

        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            if (e.CommandName == "Print")
            {
                //NumberFormatInfo numberFormat = ci.NumberFormat;
                //double nTotal = 123456789.12;
                //numberFormat.NumberDecimalDigits = 2;

                //string sString = nTotal.ToString("N", numberFormat) ; //this will display 123,456,789.12
                //showMessage(nTotal.ToString("###,###,##0.0"));
                dt = new DataTable();
                dt = ctl.Get_Data_Nota(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    label_nota_kode_pembayaran.Text = dt.Rows[0]["kode_pembayaran"].ToString();
                    label_nota_nama_pasien.Text = dt.Rows[0]["kode_pasien"].ToString();
                    Label_tampil_waktu.Text = dt.Rows[0]["waktu"].ToString();
                    label_nota_poli.Text = dt.Rows[0]["nama_poli"].ToString();
                    label_nota_nama_dokter.Text = dt.Rows[0]["nama_dokter"].ToString();
                    label_nota_kode_kunjungan.Text = dt.Rows[0]["kode_kunjungan"].ToString();

                    label_nota_biaya_pemeriksaan.Text = (int.Parse(dt.Rows[0]["tarif_dokter"].ToString()).ToString("###,###,##0.00"));
                    label_nota_harga_obat.Text = (int.Parse(dt.Rows[0]["obat"].ToString()).ToString("###,###,##0.00"));
                    label_nota_nama_tindakan.Text = dt.Rows[0]["tindakan"].ToString();
                    label_nota_biaya_tindakan.Text = (int.Parse(dt.Rows[0]["harga"].ToString()).ToString("###,###,##0.00"));
                    Label_print.Text = "---- Nota Copy ----";


                    label_nota_total.Text = (int.Parse(dt.Rows[0]["total"].ToString()).ToString("###,###,##0.00"));
                    if (dt.Rows[0]["metode"].ToString() == "BPJS")
                    {
                        Label_nota_pembayaran.Text = "BPJS";
                        Label_Kembalian.Text = "-";
                    }
                    else
                    {
                        Label_nota_pembayaran.Text = (int.Parse(dt.Rows[0]["kembalian"].ToString()) + int.Parse(dt.Rows[0]["total"].ToString())).ToString("###,###,##0.00");
                        Label_Kembalian.Text = (int.Parse(dt.Rows[0]["kembalian"].ToString()).ToString("###,###,##0.00"));
                    }

                    btn_add_Pembayaran.Visible = false;

                }
                MultiView2.SetActiveView(View3);
            }

        }

        protected void CANCLE0_Click(object sender, EventArgs e)
        {
            Refresh();
            MultiView2.SetActiveView(View1);
            SAVE0.Visible = true;
            clear();
        }

        protected void SAVE0_Click(object sender, EventArgs e)
        {
            Refresh();
            MultiView2.SetActiveView(View1);
            clear();
        }



        protected void btn_input_pembayaran_Click(object sender, EventArgs e)
        {
            btn_add_Pembayaran.Visible = false;
            int pembayaran = 0;
            total = (int.Parse(Dr_tarif.SelectedItem.Value) + int.Parse(tx_Obat.Text) + int.Parse(Tx_Biaya_Tindakan.Text));
            if (tx_input_pembayaran.Text == "")
            {
                pembayaran = 0;
            }
            else
            {
                pembayaran = int.Parse(tx_input_pembayaran.Text);
            }

            //showMessage(total.ToString() + ">" + pembayaran.ToString() + Dr_metode.SelectedItem.Value);

            if (total > pembayaran && Dr_metode.SelectedItem.Value == "Umum")
            {
                tx_input_pembayaran.Text = "";
                showMessage("Pembayaran kurang");
            }

            else
            {
                Label_nota_pembayaran.Text = tx_input_pembayaran.Text;
                Label_Kembalian.Text = (pembayaran - total).ToString();


                if (ctl.Insert_Pembayaran(tx_kode_pembayaran.Text, tx_kode_kunjungan.Text, Tx_Waktu.Text, int.Parse(Dr_tarif.SelectedItem.Value), int.Parse(tx_Obat.Text), Tx_Tindakan.Text, int.Parse(Tx_Biaya_Tindakan.Text), pembayaran))
                {
                    showMessage("Insert Succes !!");

                }
                else
                {
                    showMessage("Insert Filed !!");
                }

                DataTable dt = new DataTable();
                dt = ctl.Get_Data_Nota(tx_kode_pembayaran.Text);
                if (dt.Rows.Count > 0)
                {
                    label_nota_kode_pembayaran.Text = dt.Rows[0]["kode_pembayaran"].ToString();
                    Label_tampil_waktu.Text = dt.Rows[0]["waktu"].ToString();
                    label_nota_nama_pasien.Text = dt.Rows[0]["kode_pasien"].ToString();
                    label_nota_poli.Text = dt.Rows[0]["nama_poli"].ToString();
                    label_nota_nama_dokter.Text = dt.Rows[0]["nama_dokter"].ToString();
                    label_nota_kode_kunjungan.Text = dt.Rows[0]["kode_kunjungan"].ToString();

                    label_nota_biaya_pemeriksaan.Text = (int.Parse(dt.Rows[0]["tarif_dokter"].ToString()).ToString("###,###,##0.00"));
                    label_nota_harga_obat.Text = (int.Parse(tx_Obat.Text).ToString("###,###,##0.00"));
                    label_nota_nama_tindakan.Text = Tx_Tindakan.Text;
                    label_nota_biaya_tindakan.Text = (int.Parse(Tx_Biaya_Tindakan.Text).ToString("###,###,##0.00"));
                    Label_print.Text = "---- Nota Asli ----";
                    if (dt.Rows[0]["metode"].ToString() == "BPJS")
                    {
                        Label_nota_pembayaran.Text = "BPJS";
                        Label_Kembalian.Text = "-";
                        showMessage("BPJS");
                    }
                    else
                    {
                        Label_nota_pembayaran.Text = (int.Parse(dt.Rows[0]["kembalian"].ToString()) + int.Parse(dt.Rows[0]["total"].ToString())).ToString("###,###,##0.00");
                        Label_Kembalian.Text = (int.Parse(dt.Rows[0]["kembalian"].ToString()).ToString("###,###,##0.00"));
                    }
                    label_nota_total.Text = (int.Parse(dt.Rows[0]["total"].ToString()).ToString("###,###,##0.00"));
                    Label_nota_pembayaran.Text = (int.Parse(dt.Rows[0]["kembalian"].ToString()) + int.Parse(dt.Rows[0]["total"].ToString())).ToString("###,###,##0.00");
                }
                MultiView2.SetActiveView(View3);

            }
        }

        protected void SAVE0_Click1(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
            MultiView2.SetActiveView(View1);
        }
    }
}