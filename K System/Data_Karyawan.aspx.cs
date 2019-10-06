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
    public partial class Data_Karyawan : System.Web.UI.Page
    {
        Ctl_User ctl = new Ctl_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem Laki_Laki = new ListItem("Laki Laki", "Laki Laki");
                ListItem Perempuan = new ListItem("Perempuan", "Perempuan");
                Jk.Items.Add(Laki_Laki);
                Jk.Items.Add(Perempuan);
            }
            Refresh();
            MultiView1.SetActiveView(View1);

        }
        public void Refresh()
        {
            GridView1.DataSource = ctl.Get_User();
            GridView1.DataBind();
            Add_Karyawan.Visible = true;
        }


        protected void Add_karayawan(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            MultiView1.SetActiveView(View2);
            clear();
            tx_kode.Text = ctl.BuatKode();
            Session["kode"] = ctl.BuatKode();
            Add_Karyawan.Visible = false;
            showMessage(ctl.BuatKode());
            SAVE.Text = "SAVE";
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
            tx_Nama_Karyawan.Text = "";
            tx_No_hp.Text = "";
            tx_Email.Text = "";
            tx_Alamat.Text = "";
            Jk.Text = "Laki Laki";
            tx_kata_sandi.Text = "";


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            clear();
            tx_kode.Text = ctl.BuatKode();
            Session["kode"] = ctl.BuatKode();
            Add_Karyawan.Visible = false;
            showMessage(ctl.BuatKode());
            SAVE.Text = "SAVE";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ctl.Get_User();
            if (SAVE.Text == "SAVE")
            {
                if (ctl.Insert_User(Session["kode"].ToString(), tx_Nama_Karyawan.Text, tx_No_hp.Text, tx_Email.Text, tx_Alamat.Text, Jk.SelectedItem.Value, tx_kata_sandi.Text, DropDownBagian.SelectedItem.Value))
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

                if (ctl.Update_User(Session["kode"].ToString(), tx_Nama_Karyawan.Text, tx_No_hp.Text, tx_Email.Text, tx_Alamat.Text, Jk.SelectedItem.Value, tx_kata_sandi.Text, DropDownBagian.SelectedItem.Value))
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
                dt = ctl.Get_User(e.CommandArgument.ToString());
                if (dt.Rows.Count > 0)
                {

                    tx_kode.Text = dt.Rows[0]["kode_karyawan"].ToString();
                    Session["kode"] = dt.Rows[0]["kode_karyawan"].ToString();
                    tx_Nama_Karyawan.Text = dt.Rows[0]["nama"].ToString();
                    tx_No_hp.Text = dt.Rows[0]["no_hp"].ToString();
                    tx_Email.Text = dt.Rows[0]["email"].ToString();
                    tx_Alamat.Text = dt.Rows[0]["alamat"].ToString();
                    Jk.Text = dt.Rows[0]["jk"].ToString();
                    tx_kata_sandi.Text = dt.Rows[0]["password"].ToString();
                    DropDownBagian.Text = dt.Rows[0]["bagian"].ToString();

                    // Button2.Text = "Update";

                }
                SAVE.Text = "UPDATE";
                Add_Karyawan.Visible = false;
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
        public void Delete(string kode)
        {
            if (ctl.Delete_User(kode))
            {

            }
        }
    }
}