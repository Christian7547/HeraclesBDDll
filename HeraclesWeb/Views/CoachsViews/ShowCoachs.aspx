<%@ Page Title="Coachs" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowCoachs.aspx.cs" Inherits="HeraclesWeb.Views.CoachsViews.ShowCoachs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Coachs</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="row">
                <div>
                    <a href="NewCoach" class="link-style">Agregar coach</a>
                </div>
                <br />
                <br />
                <div>
                    <form runat="server">
                        <asp:GridView runat="server" ID="gridData" CssClass="table" AutoGenerateColumns="false" OnRowCommand="gridData_RowCommand" OnRowDataBound="gridData_RowDataBound" OnRowDeleting="gridData_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Nombre"/>
                                <asp:BoundField DataField="Name" HeaderText="Apellido"/>
                                <asp:BoundField DataField="LastName" HeaderText="Apellido M."/>
                                <asp:BoundField DataField="SecondLastName" HeaderText="C.I"/>
                                <asp:BoundField DataField="CI" HeaderText="Teléfono"/>
                                <asp:BoundField DataField="Phone"/>
                                <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" CommandName="update" ButtonType="Button" Text="Editar"/>
                                <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" CommandName="delete" ButtonType="Button" Text="Eliminar" />
                            </Columns>
                        </asp:GridView>
                        <div>
                            <asp:Button runat="server" CssClass="button-class" ID="btnBack" OnClick="btnBack_Click" style="width: 100px" Text="Volver" />
                            <asp:Button runat="server" style="display: none" ID="btnPopup" />
                        </div>
                        <asp:ScriptManager runat="server" ID="toolkitManager" ScriptMode="Release"></asp:ScriptManager>
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="btnPopup" PopupControlID="pnlModal" BackgroundCssClass="modal-background" />
                        <asp:Panel runat="server" ID="pnlModal" CssClass="modal-panel" style="display: none">
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
        </div>
    </section>
</asp:Content>
