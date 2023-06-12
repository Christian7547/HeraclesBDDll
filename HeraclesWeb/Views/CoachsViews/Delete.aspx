<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="HeraclesWeb.Views.CoachsViews.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Eliminar Registro?</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <form id="formMembresy" runat="server">
                        <div>
                            <asp:TextBox runat="server" ID="txtId" type="hidden"/>
                        </div>
                        <div>
                            <asp:Label runat="server">Nombre:</asp:Label>
                            <asp:Label runat="server" ID="lblCompleteName"></asp:Label>
                        </div>
                        <div>
                            <asp:Label runat="server">C.I:</asp:Label>
                            <asp:Label runat="server" ID="lblCi"></asp:Label>
                        </div>
                        <div>
                            <asp:Label runat="server">Teléfono:</asp:Label>
                            <asp:Label runat="server" ID="lblPhone"></asp:Label>
                        </div>
                        <div class="col-md-6 mx-auto container">
                            <asp:Button runat="server" Text="Confirmar" ID="btnDelete" OnClick="btnDelete_Click" CssClass="button-class"/>
                            <asp:Button runat="server" Text="Atrás" OnClick="btnBack_Click" ID="btnBack" CssClass="button-class"/>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
