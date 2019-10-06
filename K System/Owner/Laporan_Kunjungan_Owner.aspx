<%@ Page Title="" Language="C#" MasterPageFile="~/Owner/Site_Owner.Master" AutoEventWireup="true" CodeBehind="Laporan_Kunjungan_Owner.aspx.cs" Inherits="K_System.Owner.Laporan_Kunjungan_Owner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="laporan_K" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <asp:DropDownList ID="dr_filter_pembayaran" runat="server"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_pembayaran" runat="server" Text="OK" OnClick="btn_pembayaran_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="tx_waktu_awal" runat="server" TextMode="date"></asp:TextBox>
                            <asp:TextBox ID="tx_waktu_akhir" runat="server" TextMode="date"></asp:TextBox>
                            <asp:Button ID="btn_waktu" runat="server" Text="Ok" OnClick="btn_waktu_Click" />

                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" CssClass="gvv table table-bordered table-hover" role="grid" aria-describedby="example2_info" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="kode_kunjungan" HeaderText="Kd Kunjungan " />
                                        <asp:BoundField DataField="tanggal_kunjungan" HeaderText="Tanggal Kunjungan" />
                                        <asp:BoundField DataField="kode_poli" HeaderText="Kd Poli" />
                                        <asp:BoundField DataField="kode_pasien" HeaderText="Kd Pasien" />
                                        <asp:BoundField DataField="kode_dokter" HeaderText="Kd Dokter" />
                                        <asp:BoundField DataField="metode_pembayaran" HeaderText="Metode Pembayaran" />
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../BS/veltrix/layouts/vertical/assets/js/jquery.min.js"></script>
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

            document.forms["Pembayaran"].appendChild(tanya);
        }
    </script>
</asp:Content>
