<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site_User.Master" AutoEventWireup="true" CodeBehind="Data_Rekam_Medis.aspx.cs" Inherits="K_System.User.Data_Rekam_Medis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="rekam" runat="server">
        <asp:Button ID="btn_Add_Data" runat="server" CssClass="btn bg-green waves-effect btn-lg" Text="Add Data" OnClick="btn_add_data_click" />
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
                                                <asp:BoundField DataField="kode" HeaderText="Kode" />
                                                <asp:BoundField DataField="kode_kunjungan" HeaderText="Kode Kunjungan" />
                                                <asp:BoundField DataField="keluhan" HeaderText="Keluhan" />
                                                <asp:BoundField DataField="diagnosa" HeaderText="Diagnosa" />
                                                <asp:BoundField DataField="tindakan" HeaderText="Tindakan" />
                                                <asp:BoundField DataField="resep" HeaderText="Resep" />
                                                <asp:TemplateField HeaderText="AKSI">
                                                    <ItemTemplate>
                                                        <%-- <asp:Button ID="Update" runat="server" CommandArgument='<%#Eval("kode_dokter").ToString() %>' Text="Button" />
                                                | 
                                                <asp:Button ID="Delete" runat="server" CommandArgument='<%#Eval("kode_dokter").ToString() %>' Text="Button" OnClientClick="c_val()" />
                                                        --%>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("kode").ToString() %>' CommandName="Update"><i class="material-icons">create</i></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("kode").ToString() %>' CommandName="Delete" OnClientClick="c_val()"><i class="material-icons">delete</i></asp:LinkButton>
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
                                    <asp:Label ID="Label_kode" runat="server" Text="Kode"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Kode" CssClass="form-control" runat="server" placeholder="Kode" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_kode_kunjungan" runat="server" Text="Kode Kunjungan"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Kode_kunjungan" CssClass="form-control" runat="server" placeholder="Kode Kunjungan" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_Keluhan" runat="server" Text="Keluhan"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Keluhan" CssClass="form-control" runat="server" placeholder="Keluhan" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_diagnosa" runat="server" Text="Diagnosa"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Diagnosa" CssClass="form-control" runat="server" placeholder="Diagnosa" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_tindakan" runat="server" Text="Tindakan"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Tindakan" CssClass="form-control" runat="server" placeholder="Tindakan" required="Required"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Label ID="Label_resep" runat="server" Text="Resep"></asp:Label>
                                    <div class="form-group">
                                        <div class="form-line">
                                            <asp:TextBox ID="Resep" CssClass="form-control" runat="server" placeholder="Resep" required="Required" TextMode="MultiLine"></asp:TextBox>
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

            document.forms["rekam"].appendChild(tanya);
        }
    </script>
</asp:Content>
