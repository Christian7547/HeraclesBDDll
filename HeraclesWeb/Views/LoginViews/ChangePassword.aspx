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
                            <asp:Label runat="server" CssClass="error-class" ID="lblErrorOldPassword" Visible="false" />
                        </div>
                        <div>
                            <asp:TextBox ID="txtNewPassword" runat="server" type="password" placeholder="Nueva contraseña" />
                            <asp:Label runat="server" CssClass="error-class" ID="lblErrorNewPassword" Visible="false" />
                        </div>
                        <div>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" type="password" placeholder="Confirmar contraseña" />
                            <asp:Label runat="server" CssClass="error-class" ID="lblErrorPassword" Visible="false" />
                        </div>
                        <div class="input-container">
                            <asp:Button runat="server" Text="Actualizar" OnClick="btnChange_Click" ID="btnChange" CssClass="button-class"/>
                            <asp:Button runat="server" Text="Atrás" OnClick="btnBack_Click" ID="btnBack" CssClass="button-class"/>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
