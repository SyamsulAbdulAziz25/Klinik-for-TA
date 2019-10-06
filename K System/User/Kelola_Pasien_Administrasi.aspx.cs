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
    public partial class Kelola_Pasien_Administrasi : System.Web.UI.Page
    {

        Ctl_Pasien ctl = new Ctl_Pasien();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                ListItem Laki_Laki = new ListItem("Laki Laki", "Laki Laki");
                ListItem Perempuan = new ListItem("Perempuan", "Perempuan");
                Jk.Items.Add(Laki_Laki);
                Jk.Items.Add(Perempuan);
            }

            MultiView1.SetActiveView(View1);
            Refresh();
        }


        public void Refresh()
        {
            btn_add_pasien.Visible = true;
            GridView1.DataSource = ctl.Get_Pasien();
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
            kode_pasien.Text = "";
            Nama_pasien.Text = "";
            Tanggal_Lahir.Text = "";
            Nomor_telephon.Text = "";
            Alamat.Text = "";
            Jk.Text = "Laki Laki";
            Keterangan.Text = "";

        }

        protected void btn_add_pasienClick(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            kode_pasien.Enabled = false;
            clear();
            btn_add_pasien.Visible = false;
            kode_pasien.Text = ctl.BuatKode();
            SAVE.Text = "SAVE";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (SAVE.Text == "SAVE")
            {
                if (ctl.Insert_Pasien(kode_pasien.Text, Nama_pasien.Text, Tanggal_Lahir.Text, Nomor_telephon.Text, Alamat.Text, Jk.Text, Keterangan.Text))
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
                if (ctl.Update_Pasien(Session["kode_pasien"].ToString(), Nama_pasien.Text, Tanggal_Lahir.Text, Nomor_telephon.Text, Alamat.Text, Jk.Text, Keterangan.Text))
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
                dt = ctl.Get_Pasien(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["kode_pasien"] = dt.Rows[0]["kode_pasien"].ToString();
                    kode_pasien.Text = dt.Rows[0]["kode_pasien"].ToString();
                    kode_pasien.Enabled = false;
                    Nama_pasien.Text = dt.Rows[0]["nama_pasien"].ToString();
                    Tanggal_Lahir.Text = dt.Rows[0]["tanggal_lahir"].ToString();
                    Nomor_telephon.Text = dt.Rows[0]["no_telephon"].ToString();
                    Alamat.Text = dt.Rows[0]["alamat"].ToString();
                    Jk.Text = dt.Rows[0]["jenis_kelamin"].ToString();
                    Keterangan.Text = dt.Rows[0]["keterangan"].ToString();
                    btn_add_pasien.Visible = false;

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

        protected void SAVE0_Click1(object sender, EventArgs e)
        {

        }

        protected void CANCLE0_Click(object sender, EventArgs e)
        {

        }
    }
}