<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowCoachs.aspx.cs" Inherits="HeraclesWeb.Views.CoachsViews.ShowCoachs" %>
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
                        <asp:GridView runat="server" ID="gridData" CssClass="table" AutoGenerateColumns="false" OnRowCommand="gridData_RowCommand" OnRowDataBound="gridData_RowDataBound" >
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
                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Button runat="server" ID="btnDelete"/>
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="btnDelete"
                            PopupControlID="pnlConfirmation" BackgroundCssClass="modal-background"
                            CancelControlID="btnCancel" OkControlID="btnOk" />
                        <asp:Panel ID="pnlConfirmation" runat="server" CssClass="modal-panel">
                            <h3>Confirmación</h3>
                            <p>¿Estás seguro de realizar esta acción?</p>
                            <div class="modal-buttons">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" />
                                <asp:Button ID="btnOk" runat="server" Text="Aceptar" />
                            </div>
                        </asp:Panel>--%>
                    </form>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
