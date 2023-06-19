<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="HeraclesWeb.Views.CoachsViews.New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Inscribir Coach</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <form id="formMembresy" runat="server">
                        <div>
                            <asp:TextBox ID="txtName" runat="server" type="text" placeholder="Nombre"/>
                        </div>
                        <div>
                            <asp:TextBox ID="txtLastName" runat="server" type="text" placeholder="Apellido" />
                        </div>
                        <div>
                            <asp:TextBox ID="txtSecondLastName" runat="server" type="text" placeholder="Apellido materno" />
                        </div>
                        <div>
                            <asp:TextBox ID="txtCI" runat="server" type="text" placeholder="C.I." />
                        </div>
                        <div>
                            <asp:TextBox ID="txtPhone" runat="server" type="number" placeholder="Teléfono" />
                        </div>
                        <div class="input-container">
                            <asp:Button runat="server" Text="Añadir" OnClick="btnInsert_Click" ID="btnInsert" CssClass="button-class"/>
                            <asp:Button runat="server" Text="Atrás" OnClick="btnBack_Click"  ID="btnBack" CssClass="button-class"/>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
