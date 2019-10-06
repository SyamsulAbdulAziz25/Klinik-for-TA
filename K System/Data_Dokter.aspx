<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Data_Dokter.aspx.cs" Inherits="K_System.Data_Dokter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="Dokter" runat="server">
        
        <br />
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="container-fluid">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success waves-effect waves-light"" Text="Add Dokter" OnClick="Button1_Click" />
                    <br />
                    <br />
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
                                                <asp:BoundField DataField="kode_dokter" HeaderText="Kd Dokter" />
                                                <asp:BoundField DataField="nama_dokter" HeaderText="Nama Dokter" />
                                                <asp:BoundField DataField="nama_poli" HeaderText="nama_poli" />
                                                <asp:BoundField DataField="tarif" HeaderText="Tarif" />
                                                <asp:TemplateField HeaderText="AKSI">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("kode_dokter").ToString() %>' CommandName="Update"><i class="mdi mdi-pen"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("kode_dokter").ToString() %>' CommandName="Delete" OnClientClick="c_val()"><i class="mdi mdi-delete-sweep-outline"></i></asp:LinkButton>
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
                                    <asp:Label ID="Label_kode" runat="server" Text="Kode Dokter"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Kode_Dokter" CssClass="form-control" runat="server" placeholder="Kode Dokter" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_Nama" runat="server" Text="Nama Dokter"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Nama_Dokter" CssClass="form-control" runat="server" placeholder="Nama Dokter" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_Spesialis" runat="server" Text="Poli"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:DropDownList ID="dr_poli" runat="server" DataSourceID="SqlDataSource1" DataTextField="nama_poli" DataValueField="kode_poli"></asp:DropDownList>

                                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:db_klinikConnectionString3 %>' SelectCommand="SELECT * FROM [tb_poli] WHERE nama_poli <> 'Administrasi'"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_Tarif" runat="server" Text="Tarif Dokter"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Tx_Tarif_Dokter" CssClass="form-control" runat="server" placeholder="Tarif Dokter" required="Required"></asp:TextBox>
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

    <script type="text/javascript">
        $('li').removeClass("active");
        $("#Data_Dokter").addClass("active");
    </script>
</asp:Content>
