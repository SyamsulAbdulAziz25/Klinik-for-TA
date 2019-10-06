<%@ Page Title="" Language="C#" MasterPageFile="~/Owner/Site_Owner.Master" AutoEventWireup="true" CodeBehind="Laporan_Pembayaran_Dokter.aspx.cs" Inherits="K_System.Owner.Laporan_Pembayaran_Dokter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-body">
                                    <asp:DropDownList ID="dr_tindakan" runat="server"></asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_tindakan" runat="server" Text="OK" OnClick="btn_tindakan_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="tx_waktu_awal" runat="server" TextMode="date"></asp:TextBox>
                                    <asp:TextBox ID="tx_waktu_akhir" runat="server" TextMode="date"></asp:TextBox>
                                    <asp:Button ID="btn_waktu" runat="server" Text="Ok" OnClick="btn_waktu_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_tampil_dokter" runat="server" Text="Tampilkan By Dokter" OnClick="btn_tampil_dokter_Click" />
                                    <br/>
                                    <hr />
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView1" CssClass="gvv table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline" role="grid" aria-describedby="example2_info" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="kode_dokter" HeaderText="Kd Dokter" />
                                                <asp:BoundField DataField="nama_dokter" HeaderText="Nama Dokter" />
                                                <asp:BoundField DataField="nama_poli" HeaderText="Nama Poli" />
                                                <asp:BoundField DataField="waktu" HeaderText="Tanggal Penerimaan" />
                                                <asp:BoundField DataField="tindakan" HeaderText="Tindakan" />
                                                <asp:BoundField DataField="tarif" HeaderText="Penerimaan" />
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
                <div class="content">
                    <div class="container-fluid">
                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="tx_waktu_awal2" runat="server" TextMode="date"></asp:TextBox>
                        <asp:TextBox ID="tx_waktu_akhir2" runat="server" TextMode="date"></asp:TextBox>
                        <asp:Button ID="Button2" runat="server" Text="Ok" OnClick="Button2_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="Tampilkan By Dokter" OnClick="btn_tampil_dokter_Click" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView2" CssClass="gvv table table-bordered table-hover" role="grid" aria-describedby="example2_info" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="kode_dokter" HeaderText="Kd Dokter" />
                                    <asp:BoundField DataField="nama_dokter" HeaderText="Nama Dokter" />
                                    <asp:BoundField DataField="nama_poli" HeaderText="Nama Poli" />
                                    <asp:BoundField DataField="tarif" HeaderText="Penerimaan" />
                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </asp:View>
        </asp:MultiView>
    </form>
    <script src="../BS/veltrix/layouts/vertical/assets/js/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.gvv').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            // $('#GridView1').dataTable();
        });
    </script>
</asp:Content>
