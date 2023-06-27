<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowMembers.aspx.cs" Inherits="HeraclesWeb.Views.MembersViews.ShowMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Miembros inscritos</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="col-md-6 mx-auto">
                <form runat="server">
                    <div>
                        <a href="NewMember" class="link-style">Nuevo miembro</a>
                    </div>
                    <br />
                    <asp:GridView runat="server" ID="gridData" CssClass="table" AutoGenerateColumns="false" OnRowCommand="gridData_RowCommand" OnRowDataBound="gridData_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ID" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" />
                            <asp:BoundField DataField="Names" HeaderText="Apellido" />
                            <asp:BoundField DataField="LastName" HeaderText="Apellido M." />
                            <asp:BoundField DataField="SecondLastName" HeaderText="" />
                            <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" CommandName="update" ButtonType="Button" Text="Editar" />
                            <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" Text="Eliminar" ButtonType="Button" CommandName="delete" />
                        </Columns>
                    </asp:GridView>
                    <div>
                        <asp:Button runat="server" CssClass="button-class" ID="btnBack" OnClick="btnBack_Click" Style="width: 100px" Text="Volver" />
                    </div>
                </form>
            </div>
        </div>
    </section>
</asp:Content>
