<%@ Page Title="Membresías" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowMembresies.aspx.cs" Inherits="HeraclesWeb.Views.MembresiesViews.ShowMembresies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Membresías</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="col-md-6 mx-auto">
                <form runat="server">
                    <div>
                        <a href="NewMembresy" class="link-style">Nueva membresía</a>
                    </div>
                    <br />
                    <asp:GridView runat="server" ID="gridData" CssClass="table" AutoGenerateColumns="false" OnRowCommand="gridData_RowCommand" OnRowDataBound="gridData_RowDataBound" OnRowDeleting="gridData_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="ID" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo" />
                            <asp:BoundField DataField="Type" HeaderText="Precio" />
                            <asp:BoundField DataField="Price" HeaderText="" />
                            <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" CommandName="update" ButtonType="Button" Text="Editar" />
                            <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" Text="Eliminar" ButtonType="Button" CommandName="delete" />
                        </Columns>
                    </asp:GridView>
                    <div>
                        <asp:Button runat="server" CssClass="button-class" ID="btnBack" OnClick="btnBack_Click" Style="width: 100px" Text="Volver" />
                        <asp:Button runat="server" style="display: none" ID="btnPopup" />
                    </div>
                    <asp:ScriptManager runat="server" ID="toolkitManager" ScriptMode="Release"></asp:ScriptManager>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="btnPopup" PopupControlID="pnlModal" BackgroundCssClass="modal-background" />
                    <asp:Panel runat="server" ID="pnlModal" CssClass="modal-panel" Style="display: none">
                        <h4>Confirmar acción</h4>
                        <label>Desea Eliminar el registro?</label>
                        <div class="input-container">
                            <asp:Button runat="server" CssClass="button-modal" ID="btnDelete" Text="Confirmar" OnClick="btnDelete_Click" />
                            <asp:Button runat="server" CssClass="button-modal" ID="btnCancel" Text="Cancelar" OnClick="btnCancel_Click" />
                        </div>
                    </asp:Panel>
                </form>
            </div>
        </div>
    </section>
</asp:Content>
