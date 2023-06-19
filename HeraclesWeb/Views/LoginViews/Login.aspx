<%@ Page Title="" Language="C#" MasterPageFile="~/Init.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HeraclesWeb.Views.LoginViews.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Iniciar sesión</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <form id="formMembresy" runat="server">
                        <div>
                            <asp:TextBox ID="txtUsername" runat="server" type="text" placeholder="Usuario" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txtPassword" type="password" placeholder="Contraseña" />
                        </div>
                        <div class="col-md-6 mx-auto container">
                            <asp:Button runat="server" Text="Iniciar sesión" ID="btnLogin" OnClick="btnLogin_Click" CssClass="button-class" type="submit" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
