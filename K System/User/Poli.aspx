<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site_User.Master" AutoEventWireup="true" CodeBehind="Poli.aspx.cs" Inherits="K_System.User.Poli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="poli" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" CssClass="gvv table table-bordered table-hover" role="grid" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nomor_antrian" HeaderText="NO ANTRIAN" />
                                        <asp:BoundField DataField="kode_kunjungan" HeaderText="KD KUNJUNGAN" />
                                        <asp:BoundField DataField="poli" HeaderText="POLI" />
                                        <asp:BoundField DataField="status" HeaderText="STATUS" />
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

            document.forms["Dokter"].appendChild(tanya);
        }
    </script>
</asp:Content>
