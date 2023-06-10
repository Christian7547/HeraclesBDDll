<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowMembresies.aspx.cs" Inherits="HeraclesWeb.Views.MembresiesViews.ShowMembresies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3>Membresías
            </h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="row">
                <div>
                    <a href="New.aspx" class="link-style">Nueva membresía</a>
                </div>
                <div class="col-md-6 mx-auto">
                    <form runat="server">
                        <asp:GridView runat="server" ID="gridData" CssClass="table" AutoGenerateColumns="false" OnRowCommand="gridData_RowCommand" OnRowDataBound="gridData_RowDataBound" >
                            <Columns>
                                <asp:BoundField DataField="ID" ItemStyle-HorizontalAlign="Center" HeaderText="ID"/>
                                <asp:BoundField DataField="Type" HeaderText="Tipo"/>
                                <asp:BoundField DataField="Price" HeaderText="Precio"/>
                                <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" CommandName="update" ButtonType="Button" Text="Editar"/>
                                <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" Text="Eliminar" ButtonType="Button" CommandName="delete"/>
                            </Columns>
                        </asp:GridView>
                    </form>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
