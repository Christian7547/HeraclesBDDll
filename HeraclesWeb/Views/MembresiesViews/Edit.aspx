<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="HeraclesWeb.Views.MembresiesViews.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Editar Membresía</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <form id="formMembresy" runat="server">
                        <div>
                            <asp:TextBox runat="server" ID="txtId" type="hidden"/>
                        </div>
                        <div>
                            <asp:TextBox ID="txtType" runat="server" type="text" placeholder="Tipo" />
                        </div>
                        <div>
                            <asp:TextBox ID="txtPrice" runat="server" type="number" placeholder="Precio" />
                        </div>
                        <div class="input-container">
                            <asp:Button runat="server" Text="Actualizar" ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="button-class"/>
                            <asp:Button runat="server" Text="Volver" ID="btnBack" OnClick="btnBack_Click" CssClass="button-class"/>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
