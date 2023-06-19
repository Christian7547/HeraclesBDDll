<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HeraclesWeb.Views.LoginViews.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Actualizar Contraseña</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <form id="formMembresy" runat="server">
                        <div>
                            <asp:TextBox ID="txtoldPassword" runat="server" type="password" placeholder="Contraseña actual"/>
                        </div>
                        <div>
                            <asp:TextBox ID="txtNewPassword" runat="server" type="password" placeholder="Nueva contraseña" />
                        </div>
                        <div>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" type="password" placeholder="Confirmar contraseña" />
                        </div>
                        <div class="input-container">
                            <asp:Button runat="server" Text="Actualizar" OnClick="btnChange_Click" ID="btnChange" CssClass="button-class"/>
                            <asp:Button runat="server" Text="Atrás" OnClick="btnBack_Click"  ID="btnBack" CssClass="button-class"/>
                        </div>
                        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
					    <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="btnChange"
						    PopupControlID="pnlConfirmation" BackgroundCssClass="modal-background" OkControlID="btnOk" />
					    <asp:Panel ID="pnlConfirmation" runat="server" CssClass="modal-panel">
						    <h5>Cambio de contraseña</h5>
                            <asp:Label runat="server" ID="lblMessage" Text="..." CssClass="input-modal"></asp:Label>
						    <div class="modal-buttons">
                                <asp:Button runat="server" ID="btnOk" Text="Aceptar" CssClass="button-modal" />
						    </div>
					    </asp:Panel>
                    </form>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
