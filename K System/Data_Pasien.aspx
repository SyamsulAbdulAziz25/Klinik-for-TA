<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Data_Pasien.aspx.cs" Inherits="K_System.Data_Pasien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="Dokter" runat="server">
        <asp:Button ID="btn_add_pasien" runat="server" CssClass="btn bg-green waves-effect btn-lg" Text="Add Patient" OnClick="btn_add_pasienClick" OnClientClick="un_focused()" />
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
                                                <asp:BoundField DataField="kode_pasien" HeaderText="Kd Pasien " />
                                                <asp:BoundField DataField="nama_pasien" HeaderText="Nama Pasien" />
                                                <asp:BoundField DataField="tanggal_lahir" HeaderText="Tanggal Lahir" />
                                                <asp:BoundField DataField="no_telephon" HeaderText="No.Telp" />
                                                <asp:BoundField DataField="alamat" HeaderText="Alamat" />
                                                <asp:BoundField DataField="jenis_kelamin" HeaderText="Jenis Kelamin" />
                                                <asp:BoundField DataField="keterangan" HeaderText="Keterangan" />
                                                <asp:TemplateField HeaderText="AKSI">
                                                    <ItemTemplate>
                                                        <%-- <asp:Button ID="Update" runat="server" CommandArgument='<%#Eval("kode_dokter").ToString() %>' Text="Button" />
                                                | 
                                                <asp:Button ID="Delete" runat="server" CommandArgument='<%#Eval("kode_dokter").ToString() %>' Text="Button" OnClientClick="c_val()" />
                                                        --%>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("kode_pasien").ToString() %>' CommandName="Update"><i class="material-icons">create</i></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("kode_pasien").ToString() %>' CommandName="Delete" OnClientClick="c_val()"><i class="material-icons">delete</i></asp:LinkButton>
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
                                    <asp:Label ID="Label_id_pasien" runat="server" Text="Id Pasien"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="kode_pasien" CssClass="form-control" runat="server" placeholder="Id Pasien" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_nama_pasien" runat="server" Text="Nama Pasien"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Nama_pasien" CssClass="form-control" runat="server" placeholder="Nama Pasien" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_Tanggal" runat="server" Text="Tanggal Lahir"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Tanggal_Lahir" runat="server" CssClass="form-control" type="date" placeholder="Tangal Lahir" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_nomor" runat="server" Text="Nomor Telephon"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Nomor_telephon" type="number" CssClass="form-control" runat="server" placeholder="Nomor Telephon" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_Alamat" runat="server" Text="Alamat"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Alamat" CssClass="form-control" runat="server" placeholder="Alamat" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_Jenis" runat="server" Text="Jenis Kelamin"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:DropDownList ID="Jk" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_keterangan" runat="server" Text="Keterangan"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Keterangan" CssClass="form-control" runat="server" placeholder="Keterangan" TextMode="MultiLine" required="Required"></asp:TextBox>
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

            document.forms["Dokter"].appendChild(tanya);
        }

    </script>
</asp:Content>
