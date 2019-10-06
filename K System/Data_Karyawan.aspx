<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Data_Karyawan.aspx.cs" Inherits="K_System.Data_Karyawan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="karywan" runat="server">
        <asp:Button ID="Add_Karyawan" runat="server" CssClass="btn bg-green waves-effect btn-lg" Text="Add Karyawan" OnClick="Add_karayawan" />
        <br />
        <br />
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView1" CssClass="gvv table table-bordered table-hover" role="grid" aria-describedby="example2_info" runat="server" AutoGenerateColumns="False"
                                            OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
                                            <Columns>
                                                <asp:TemplateField HeaderText="No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="kode_karyawan" HeaderText="Kd Karyawan" />
                                                <asp:BoundField DataField="nama" HeaderText="Nama Karyawan" />
                                                <asp:BoundField DataField="no_hp" HeaderText="No Hp" />
                                                <asp:BoundField DataField="email" HeaderText="Email" />
                                                <asp:BoundField DataField="alamat" HeaderText="Alamat" />
                                                <asp:BoundField DataField="jk" HeaderText="Jenis Kelamin" />
                                                <asp:BoundField DataField="password" HeaderText="Password" />
                                                <asp:BoundField DataField="bagian" HeaderText="Bagian" />
                                                <asp:TemplateField HeaderText="AKSI">
                                                    <ItemTemplate>
                                                        <%-- <asp:Button ID="Update" runat="server" CommandArgument='<%#Eval("kode_dokter").ToString() %>' Text="Button" />
                                                | 
                                                <asp:Button ID="Delete" runat="server" CommandArgument='<%#Eval("kode_dokter").ToString() %>' Text="Button" OnClientClick="c_val()" />
                                                        --%>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("kode_karyawan").ToString() %>' CommandName="Update"><i class="material-icons">create</i></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("kode_karyawan").ToString() %>' CommandName="Delete" OnClientClick="c_val()"><i class="material-icons">delete</i></asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="form-group">
                                        <div>
                                            <asp:Label ID="label_kode" runat="server" Text="Kode Karyawan"></asp:Label>
                                        </div>

                                        <div class="form-line">
                                            <asp:TextBox ID="tx_kode" CssClass="form-control" runat="server" placeholder="Kode Karyawan" required="Required" enable="true"></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <div>
                                            <asp:Label ID="label_nama_karyawan" runat="server" Text="Nama Karyawan"></asp:Label>
                                        </div>

                                        <div class="form-line">
                                            <asp:TextBox ID="tx_Nama_Karyawan" CssClass="form-control" runat="server" placeholder="Nama Karyawan" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lable_no_hp" runat="server" Text="No Hp"></asp:Label>
                                        <div class="form-line">
                                            <asp:TextBox ID="tx_No_hp" CssClass="form-control" runat="server" placeholder="No Hp" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="label_email" runat="server" Text="Email"></asp:Label>
                                        <div class="form-line">
                                            <asp:TextBox ID="tx_Email" CssClass="form-control" runat="server" type="email" placeholder="Email" required="Required"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="label_alamat" runat="server" Text="Alamat"></asp:Label>
                                        <div class="form-line">
                                            <asp:TextBox ID="tx_Alamat" CssClass="form-control" runat="server" placeholder="Alamat" required="Required"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="Label_Jenis" runat="server" Text="Jenis Kelamin"></asp:Label>
                                        <div class="form-line">
                                            <asp:DropDownList ID="Jk" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="label_pass" runat="server" Text="Kata sandi"></asp:Label>
                                        <div class="form-line">
                                            <asp:TextBox ID="tx_kata_sandi" CssClass="form-control" runat="server" placeholder="Kata Sandi" required="Required"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="label_bagian" runat="server" Text="Penempatan"></asp:Label>
                                        <div class="form-line">
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_klinikConnectionString %>" SelectCommand="SELECT [nama_poli] FROM [tb_poli]"></asp:SqlDataSource>
                                            <asp:DropDownList ID="DropDownBagian" runat="server" DataSourceID="SqlDataSource1" DataTextField="nama_poli" DataValueField="nama_poli"></asp:DropDownList>
                                            <%-- <asp:TextBox ID="" CssClass="form-control" runat="server" placeholder="Penempatan" required="Required"></asp:TextBox>
                                            --%>
                                        </div>
                                    </div>
                                    <asp:Button ID="SAVE" runat="server" CssClass="mt-1 btn btn-success btn-actions-pane-left" Text="SAVE" OnClick="Submit_Click" />
                                    <asp:Button ID="CANCLE" runat="server" CssClass="mt-1 btn btn-warning btn-actions-pane-right" Text="CANCLE" formnovalidate="false" OnClick="Cancle_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </form>

    <script src="BS/veltrix/layouts/vertical/assets/js/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.gvv').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            // $('#GridView1').dataTable();
        });

        function c_val() {
            var tanya = document.createElement("INPUT");
            tanya.type = "hidden";
            tanya.name = "c_tanya";
            if (confirm("Are You  Sure ?")) {
                tanya.value = "Yes";
            }
            else {
                tanya.value = "No";
            }

            document.forms["karywan"].appendChild(tanya);
        }
    </script>
    <script type="text/javascript">

        $('li').removeClass("active");
        $("#Data_Karyawan").addClass("active");
    </script>
</asp:Content>
