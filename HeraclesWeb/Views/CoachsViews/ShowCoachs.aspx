<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowCoachs.aspx.cs" Inherits="HeraclesWeb.Views.CoachsViews.ShowCoachs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3>Coachs</h3>
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
                                <asp:BoundField DataField="ID"/>
                                <asp:BoundField DataField="Name" HeaderText="Nombre"/>
                                <asp:BoundField DataField="LastName" HeaderText="Apellido"/>
                                <asp:BoundField DataField="SecondLastName" HeaderText="Apellido M."/>
                                <asp:BoundField DataField="CI" HeaderText="C.I."/>
                                <asp:BoundField DataField="Phone" HeaderText="Teléfono"/>
                                <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" CommandName="update" ButtonType="Button" Text="Editar"/>
                                <asp:ButtonField runat="server" ControlStyle-CssClass="buttonColumn-class" CommandName="delete" ButtonType="Button" Text="Eliminar" />
                            </Columns>
                        </asp:GridView>
                    </form>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
