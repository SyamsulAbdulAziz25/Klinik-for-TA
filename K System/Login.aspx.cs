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
    public partial class Login : System.Web.UI.Page
    {
        Ctl_User ctl = new Ctl_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["akses"] != null)
                {
                    if (Session["akses"].ToString() == "Admin")
                    {
                        Response.Redirect("Home_Admin.aspx");
                    }
                    else if (Session["akses"].ToString() == "Owner")
                    {
                        Response.Redirect("Owner/HomeOwner.aspx");
                    }
                    else if (Session["akses"].ToString() == "Administrasi")
                    {
                        Response.Redirect("Data_Kunjungan.aspx");
                    }
                    else
                    {
                        Response.Redirect("User/Poli.aspx");
                    }
                    showMessage(Session["akses"].ToString());
                }
            }


        }

        protected void Button_karyawan(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (RadioButtonList1.Text == "Karyawan")
            {
                try
                {
                    dt = ctl.Get_User(ID.Text, pass.Text);
                    if (dt.Rows.Count > 0)
                    {
                        Session["nama"] = dt.Rows[0]["nama"].ToString();
                        Session["akses"] = dt.Rows[0]["bagian"].ToString();
                        if (Session["akses"].ToString() == "Administrasi")
                        {
                            Response.Redirect("User/Data_Kunjungan.aspx");

                        }
                        else if (Session["akses"].ToString() == "Pembayaran")
                        {
                            Response.Redirect("User/Data_Pembayaran.aspx");
                        }
                        else
                        {
                            Response.Redirect("User/Poli.aspx");
                        }

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Username atau password salah!.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else if (RadioButtonList1.Text == "Admin")
            {
                try
                {
                    dt = ctl.Get_User(ID.Text, pass.Text);
                    if (dt.Rows.Count > 0)
                    {
                        Session["nama"] = dt.Rows[0]["nama"].ToString();
                        Session["akses"] = dt.Rows[0]["bagian"].ToString();
                        Response.Redirect("Home_Admin.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Username atau password salah!.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else if (RadioButtonList1.Text == "Owner")
            {
                try
                {
                    dt = ctl.Get_Owner(ID.Text, pass.Text);
                    if (dt.Rows.Count > 0)
                    {
                        Session["nama"] = dt.Rows[0]["nama"].ToString();
                        Session["akses"] = "Owner";
                        Response.Redirect("Owner/HomeOwner.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Username atau password salah!.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

        }

        //protected void button_admin(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        dt = ctl.Get_User(nama_admin.Text, "Admin", kata_sandi_admin.Text);
        //        if (dt.Rows.Count > 0)
        //        {
        //            Session["nama"] = dt.Rows[0]["nama"].ToString();
        //            Session["akses"] = "Admin";
        //            Response.Redirect("Home_Admin.aspx");
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Username atau password salah!.');</script>");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        //protected void button_owner(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        dt = ctl.Get_Owner(nama_admin.Text, kata_sandi_admin.Text);
        //        if (dt.Rows.Count > 0)
        //        {
        //            Session["nama"] = dt.Rows[0]["nama"].ToString();
        //            Session["akses"] = "Owner";
        //            Response.Redirect("Home_Admin.aspx");
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Username atau password salah!.');</script>");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}
        public void showMessage(string m)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ALERT", "alert('" + m + "');", true);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

        }




        protected void on_karyawan(object sender, EventArgs e)
        {

        }
    }
}